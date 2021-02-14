using System.Linq;
using System.Threading.Tasks;
using Admin.Database;
using Admin.Helpers.Extensions;
using Admin.Models.Requests;
using Admin.Models.Scheduler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [AllowAnonymous] //By raw data
        [Route("get")]
        public async Task<ActionResult<SchedulerModel>> GetByFacultyAndGroup(string faculty, int spec, 
            string gname, int gcode, int scode)
        {
            var subGroup = await _db.Faculties.GetSubGroup(faculty, spec,
                gname, gcode, scode);

            var scheduler = subGroup.Scheduler;

            if (scheduler == null)
                return Forbid();
            
            return scheduler;
        }
        
        //[Authorize]
        [HttpPost("day/create")]
        public async Task<IActionResult> AddNewDay([FromBody] AddSchedulerDayRequest request)
        {
            /*if (User.IsInRole(Role.ADMIN) || User.IsInRole(Role.MOD))
                return Forbid();*/

            var subGroup = await _db.Faculties.GetSubGroup(request.FacultyName, request.SpecialityCode,
                request.GroupName, request.GroupCode, request.SubgroupCode);

            subGroup?.Scheduler.SchedulerDays.Add(new SchedulerDayModel
            {
                ScheduleWeekDay = request.WeekDay,
                ClassSubjects = null
            });

            await _db.SaveChangesAsync();

            return Ok($"{request.WeekDay.ToString()} scheduler for id {subGroup?.Id} has been updated");
        }
        
        [HttpPost("day/subjects/add")]
        public async Task<IActionResult> AddSubject([FromBody] AddSchedulerSubjectRequest request)
        {
            /*if (User.IsInRole(Role.ADMIN) || User.IsInRole(Role.MOD))
                return Forbid();*/

            var faculty = await _db.Faculties.GetFaculty(request.FacultyName);

            var speciality = await faculty.GetSpeciality(request.SpecialityCode);

            if (speciality == null) 
                return BadRequest("Bad request at 'speciality'");
            
            var group = await speciality.GetGroup(request.GroupName, request.GroupCode);

            if (group == null) 
                return BadRequest("Bad request at 'group'");
            
            var subGroup = await group.GetSubGroup(request.SubgroupCode);

            var schedulerDay = subGroup?.Scheduler.SchedulerDays.FirstOrDefault(
                x => x.ScheduleWeekDay == request.WeekDay);
            
            schedulerDay?.ClassSubjects.Add(request.ClassSubject); //TODO: Check if already exists.

            await _db.SaveChangesAsync();

            return Ok($"{request.ClassSubject.Name} subject has been created on {faculty.NameEn} => " +
                      $"{group.NameUa}" +
                      $"-{group.Code} ({subGroup?.Code} sub)");
        }
        // Endpoint -> api/scheduler/fis/sp/21/2
    }
}