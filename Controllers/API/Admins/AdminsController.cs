using System;
using System.Linq;
using System.Threading.Tasks;
using Admin.Database;
using Admin.Exceptions;
using Admin.Helpers.Extensions;
using Admin.Models;
using Admin.Models.Mod.Info;
using Admin.Models.Requests;
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
            await _db.Faculties.AddAsync(new Faculty(request.NameEn.ToLower(), 
                request.NameUa.ToLower()));
            await _db.SaveChangesAsync();

            return Ok($"Successfully created a new faculty '{request.NameEn}'.");
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
            try
            {
                var faculty = await _db.Faculties.GetFaculty(request.FacultyName);
                faculty?.Specialities.Add(new Speciality(request.Code, request.DescriptionUa));

                await _db.SaveChangesAsync();
                
                return Ok($"Successfully created a new speciality '{request.Code}' to '{request.FacultyName}'");
            }
            
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
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
            try
            {
                var speciality = await _db.Faculties.GetFaculty(request.FacultyName.ToLower()).Result
                    .GetSpeciality(request.SpecialityCode);
                
                speciality?.Groups.Add(new Group(request.NameEn, 
                    request.NameUa, request.Code));
            
                await _db.SaveChangesAsync();
                
                return Ok($"Successfully added a new Group to '{speciality?.Code} - {speciality?.DescriptionUa}'");
            }
            
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
        
        [HttpPost("groups/remove")]
        public Task<IActionResult> RemoveGroup()
        {
            return null;
        }
        
        [HttpPost("subgroups/add")]
        public async Task<IActionResult> UpdateSubgroup([FromBody] AddSubgroupRequest request)
        {
            try
            {
                var group = await _db.Faculties.GetFaculty(request.FacultyName).Result
                    .GetSpeciality(request.SpecialityCode).Result
                    .GetGroup(request.GroupName, request.GroupCode);
            
                group?.SubGroups.CreateNew(request.Code);
            
                await _db.SaveChangesAsync();

                return Ok($"Successfully added a new SubGroup to '{request.GroupName}-{group?.Code}'");
            }
            
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
        
        [HttpPost("subgroup/remove")]
        public Task<IActionResult> RemoveSubgroup()
        {
            return null;
        }
    }
}