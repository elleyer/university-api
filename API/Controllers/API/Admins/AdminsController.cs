using System.Linq;
using System.Threading.Tasks;
using Admin.Database;
using Admin.Models;
using Admin.Models.Requests;
using Admin.Models.User.Info;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Admin.Controllers.API.Admins
{
    [ApiController]
    [Route("api/admin")]
    //[Authorize(Roles = Role.ADMIN)]
    public sealed class AdminsController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public AdminsController(ApplicationContext db)
        {
            _db = db;
        }
        
        [HttpPost("faculties/add")]
        public async Task<IActionResult> AddFaculty([FromBody] AddFacultyRequest request)
        {
            await _db.Faculties.AddAsync(new Faculty(request.NameEn, request.NameUa));
            await _db.SaveChangesAsync();

            return Ok("Successfully added a new faculty.");
        }
        
        [HttpPost("faculties/update")]
        public Task<IActionResult> UpdateFaculty()
        {
            return null;
        }
        
        [HttpPost("faculties/remove")]
        public Task<IActionResult> RemoveFaculty()
        {
            return null;
        } 
        
        [HttpPost("specialities/add")]
        public async Task<IActionResult> AddSpeciality([FromBody] AddSpecialityRequest request)
        {
            var faculty = await _db.Faculties.FirstOrDefaultAsync(x => x.Id == request.FacultyId);
            faculty?.Specialities.Add(new Speciality(request.Code, request.DescriptionUa));

            await _db.SaveChangesAsync();

            return Ok($"Successfully added a new speciality to {faculty?.NameEn}");
        }
        
        [HttpPost("specialities/update")]
        public Task<IActionResult> UpdateSpeciality()
        {
            return null;
        }
        
        [HttpPost("specialities/remove")]
        public Task<IActionResult> RemoveSpeciality()
        {
            return null;
        }
        
        [HttpPost("groups/add")]
        public async Task<IActionResult> UpdateGroup([FromBody] AddGroupRequest request)
        {
            var faculty = await _db.Faculties.FirstOrDefaultAsync(x => x.Id == request.FacultyId);

            var speciality = faculty?.Specialities.FirstOrDefault(x => x.Id == request.SpecialityId);
            speciality?.Groups.Add(new Group(request.NameEn, request.NameUa, request.Code));
            
            await _db.SaveChangesAsync();

            return Ok($"Successfully added a new Group to {speciality?.Code} - {speciality?.DescriptionUa}");
        }
        
        [HttpPost("groups/remove")]
        public Task<IActionResult> RemoveGroup()
        {
            return null;
        }
        
        [HttpPost("subgroups/add")]
        public async Task<IActionResult> UpdateSubgroup([FromBody] AddSubgroupRequest request)
        {
            var faculty = await _db.Faculties.FirstOrDefaultAsync(x => x.Id == request.FacultyId);

            var speciality = faculty?.Specialities.FirstOrDefault(x => x.Id == request.SpecialityId);
            
            var group = speciality?.Groups.FirstOrDefault(x => x.Id == request.GroupId);
            group?.SubGroups.Add(new SubGroup(request.Code));
            
            await _db.SaveChangesAsync();

            return Ok($"Successfully added a new SubGroup to {group?.NameUa}-{group?.Code}");
        }
        
        [HttpPost("subgroup/remove")]
        public Task<IActionResult> RemoveSubgroup()
        {
            return null;
        }
    }
}