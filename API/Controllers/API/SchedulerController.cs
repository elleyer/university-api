using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Database;
using Admin.Models;
using Admin.Models.Requests;
using Admin.Models.User;
using Admin.Models.User.Info;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Admin.Controllers.API
{
    //[Authorize]
    [ApiController]
    [Route("api/scheduler")]
    public sealed class SchedulerController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public SchedulerController(ApplicationContext facultyContext)
        {
            _db = facultyContext;
        }

        [AllowAnonymous]
        [HttpGet("byFaculty")]
        public async Task<ActionResult<Scheduler>> GetByFacultyAndGroup(string fc, int spec, 
            string gr, int grCode, int sub)
        {
            var faculty = await _db.Faculties.FirstOrDefaultAsync(p => p.NameEn == fc);
            
            var speciality = faculty.Specialities.FirstOrDefault(p => p.Code == spec);

            var group = speciality?.Groups.FirstOrDefault(p => p.NameEn == gr && p.Code == grCode);
            
            return group?.SubGroups.FirstOrDefault(p => p.Code == sub)?.Scheduler;
        }
        
        //[Authorize]
        [HttpPost("day/create")]
        public async Task<IActionResult> AddNewDay([FromBody] AddSchedulerDayRequest request)
        {
            /*if (User.IsInRole(Role.ADMIN) || User.IsInRole(Role.MOD))
                return Forbid();*/

            var faculty = await _db.Faculties.FirstOrDefaultAsync(p => p.Id == request.FacultyId);
            
            var speciality = faculty.Specialities.FirstOrDefault(p => p.Id == request.SpecialityId);

            var group = speciality?.Groups.FirstOrDefault(p => p.Id == request.GroupId);

            var subGroup = group?.SubGroups.FirstOrDefault(p => p.Id == request.SubgroupId);

            subGroup?.Scheduler.SchedulerDays.Add(new SchedulerDay
            {
                ScheduleWeekDay = request.WeekDay,
                ClassSubjects = null
            });

            await _db.SaveChangesAsync();

            return Ok($"{request.WeekDay.ToString()} scheduler for {faculty.NameUa} " +
                      $"{group?.NameEn}-{group?.Code} was created");
        }
        
        [HttpPost("day/subjects/add")]
        public async Task<IActionResult> AddSubject([FromBody] AddSchedulerSubjectRequest request)
        {
            /*if (User.IsInRole(Role.ADMIN) || User.IsInRole(Role.MOD))
                return Forbid();*/

            var faculty = await _db.Faculties.FirstOrDefaultAsync(p => p.Id == request.FacultyId);
            
            var speciality = faculty.Specialities.FirstOrDefault(p => p.Id == request.SpecialityId);

            var group = speciality?.Groups.FirstOrDefault(p => p.Id == request.GroupId);

            var subGroup = group?.SubGroups.FirstOrDefault(p => p.Id == request.SubgroupId);

            var schedulerDay = subGroup?.Scheduler.SchedulerDays.FirstOrDefault(
                    x => x.ScheduleWeekDay == request.WeekDay);
            
            schedulerDay?.ClassSubjects.Add(request.ClassSubject); //TODO: Check if already exists.

            await _db.SaveChangesAsync();

            return Ok($"{request.ClassSubject.Name} subject has been created on {faculty.NameEn} => {group?.NameUa}" +
                      $"-{group?.Code} ({subGroup?.Code} sub)");
        }
        // Endpoint -> api/scheduler/fis/sp/21/2
    }
}