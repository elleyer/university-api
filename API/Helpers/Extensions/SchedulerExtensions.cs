using System.Linq;
using System.Threading.Tasks;
using Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace Admin.Helpers.Extensions
{
    internal static class SchedulerExtensions
    {
        #region ById
        public static async Task<Faculty> GetFaculty(this DbSet<Faculty> db, int id)
        {
            Faculty faculty = null;

            await Task.Run(() => 
            {
                faculty = db.FirstOrDefaultAsync(x => x.Id == id).Result;
            });
            
            return faculty;
        }

        #endregion
        
        #region byRaw
        public static async Task<Faculty> GetFaculty(this DbSet<Faculty> db, string name)
        {
            Faculty faculty = null;

            await Task.Run(() => 
            {
                faculty = db.FirstOrDefaultAsync(x => x.NameEn == name.ToLower()).Result;
            });
            
            return faculty;
        }
        
        public static async Task<Speciality> GetSpeciality(this Faculty faculty, int code)
        {
            Speciality speciality = null;

            await Task.Run(() =>
            {
                speciality = faculty.Specialities.FirstOrDefault(x => x.Code == code);
            });
            
            return speciality;
        }
        
        public static async Task<Group> GetGroup(this Speciality speciality, string name, int code)
        {
            Group group = null;

            await Task.Run(() =>
            {
                group = speciality.Groups.FirstOrDefault(x => x.NameEn == name.ToLower() && x.Code == code);
            });
            
            return group;
        }
        
        public static async Task<SubGroup> GetSubGroup(this Group group, int code)
        {
            SubGroup sub = null;

            await Task.Run(() =>
            {
                sub = group.SubGroups.FirstOrDefault(x => x.Code == code);
            });
            
            return sub;
        }
        
        public static async Task<SubGroup> GetSubGroup(this DbSet<Faculty> db, string fcName, int specCode,
            string groupName, int groupCode, int subCode)
        {
            SubGroup sub = null;

            var faculty = await db.GetFaculty(fcName);
            var speciality = await faculty.GetSpeciality(specCode);
            var group = await speciality.GetGroup(groupName, groupCode);

            await Task.Run(() =>
            {
                sub = group.SubGroups.FirstOrDefault(x => x.Id == subCode);
            });
            
            return sub;
        }
        #endregion
    }
}