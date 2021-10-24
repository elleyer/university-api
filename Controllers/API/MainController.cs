using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Database;
using Admin.Exceptions;
using Admin.Helpers.Extensions;
using Admin.Models;
using Admin.Models.Requests;
using Admin.Models.Scheduler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Admin.Controllers.API
{
    //[Authorize]
    [ApiController]
    [Route("api")]
    public sealed class MainController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public MainController(ApplicationContext facultyContext)
        {
            _db = facultyContext;
        }
        
        [AllowAnonymous]
        [Route("faculties/get")]
        public async Task<ActionResult<List<FacultyResponse>>> GetFaculties()
        {
            try
            {
                var faculties = await _db.Faculties.ToListAsync();
                
                var model = new List<FacultyResponse>();

                if (faculties == null) return model;
                model.AddRange(
                    faculties.Select(faculty => new FacultyResponse()
                    {
                        NameEn = faculty.NameEn,
                        NameUa = faculty.NameUa
                    }));

                return model;
            }
            
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        
        [AllowAnonymous]
        [Route("specialities/get")]
        public async Task<ActionResult<List<SpecialityResponse>>> GetSpecialities(string faculty)
        {
            try
            {
                var fac = await _db.Faculties.FirstOrDefaultAsync
                    (x => x.NameEn == faculty);

                var specialities = fac.Specialities;
                
                var model = new List<SpecialityResponse>();
                
                if (specialities == null) return model;
                model.AddRange(
                    specialities.Select(speciality => new SpecialityResponse
                    {
                        Code = speciality.Code,
                        DescriptionUa = speciality.DescriptionUa
                    }));

                return model;
            }
            
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        
        [AllowAnonymous]
        [Route("groups/get")]
        public async Task<ActionResult<List<GroupResponse>>> GetSpecialities(string faculty, int spec)
        {
            try
            {
                var fac = await _db.Faculties.FirstOrDefaultAsync
                    (x => x.NameEn == faculty);

                var specialities = fac.Specialities;

                var groups = specialities.FirstOrDefault(x => x.Code == spec)?.Groups;
                
                var model = new List<GroupResponse>();

                if (groups == null) return model;
                model.AddRange(
                    groups.Select(group => new GroupResponse()
                    {
                        NameEn = group.NameEn,
                        NameUa = group.NameUa,
                        Code = group.Code
                    }));

                return model;
            }
            
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        
        [AllowAnonymous]
        [Route("subgroups/get")]
        public async Task<ActionResult<List<SubGroupResponse>>> GetSubgroups(string faculty, int spec, 
            string gname, int gcode)
        {
            try
            {
                var fac = await _db.Faculties.FirstOrDefaultAsync
                    (x => x.NameEn == faculty);

                var specialities = fac.Specialities;

                var groups = specialities.FirstOrDefault(x => x.Code == spec)?.Groups;

                var subGroups = groups?.FirstOrDefault(x => x.Code == gcode && x.NameEn == gname)?.SubGroups;

                var model = new List<SubGroupResponse>();

                if (subGroups == null) return model;
                model.AddRange(
                    subGroups.Select(subGroup => new SubGroupResponse
                    {
                        Code = subGroup.Code
                    }));

                return model;
            }
            
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("scheduler/get")]
        public async Task<ActionResult<SchedulerModelResponse>> GetByFacultyAndGroup(string faculty, int spec, 
            string gname, int gcode, int scode)
        {
            try
            {
                var subGroup = await _db.Faculties.GetSubGroup(faculty, spec,
                    gname, gcode, scode);

                var scheduler = subGroup.Scheduler;

                var model = new SchedulerModelResponse
                {
                    SchedulerDays = scheduler.SchedulerDays
                };

                return model;
            }
            
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        
        [Authorize]
        [HttpPost("scheduler/day/create")]
        public async Task<IActionResult> CreateNewDay([FromBody] AddSchedulerDayRequest request)
        {
            try
            {
                var subGroup = await _db.Faculties.GetSubGroup(request.FacultyName,
                    request.SpecialityCode, request.GroupName, request.GroupCode,
                    request.SubgroupCode);

                subGroup?.Scheduler.SchedulerDays.CreateNew(request.WeekDay);

                await _db.SaveChangesAsync();

                return Ok($"{request.WeekDay.ToString()} scheduler for id {subGroup?.Id} has been created");
            }

            catch (AlreadyExistsException e)
            {
                return Conflict(e.Message);
            }

            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
        
        [Authorize]
        [HttpPost("scheduler/day/subjects/add")]
        public async Task<IActionResult> AddSubject([FromBody] AddSchedulerSubjectRequest request)
        {
            /*if (User.IsInRole(Role.ADMIN) || User.IsInRole(Role.MOD))
                return Forbid();*/
            try
            {
                var faculty = await _db.Faculties.GetFaculty(request.FacultyName);

                var speciality = await faculty.GetSpeciality(request.SpecialityCode);

                var group = await speciality.GetGroup(request.GroupName, request.GroupCode);

                var subGroup = await group.GetSubGroup(request.SubgroupCode);

                var schedulerDay = subGroup?.Scheduler.SchedulerDays.FirstOrDefault(
                    x => x.ScheduleWeekDay == request.WeekDay);

                schedulerDay?.ClassSubjects.CreateNew(request.ClassSubject);

                await _db.SaveChangesAsync();

                return Ok($"{request.ClassSubject.Name} subject has been created on {faculty.NameEn} => " +
                          $"{group.NameUa}" +
                          $"-{group.Code} ({subGroup?.Code} sub)");
            }

            catch (AlreadyExistsException e)
            {
                return Conflict(e.Message);
            }

            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}