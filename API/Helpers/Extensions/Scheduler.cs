using System.Linq;
using System.Threading.Tasks;
using Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace Admin.Helpers.Extensions
{
    internal static class Scheduler
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
        
        public static async Task<Speciality> GetSpeciality(this Faculty faculty, int specialityId)
        {
            Speciality speciality = null;

            await Task.Run(() =>
            {
                speciality = faculty.Specialities.FirstOrDefault(x => x.Id == specialityId);
            });
            
            return speciality;
        }
        
        public static async Task<Group> GetGroup(this Speciality speciality, int groupId)
        {
            Group group = null;

            await Task.Run(() =>
            {
                group = speciality.Groups.FirstOrDefault(x => x.Id == groupId);
            });
            
            return group;
        }
        
        public static async Task<SubGroup> GetSubGroup(this Group group, int subId)
        {
            SubGroup sub = null;

            await Task.Run(() =>
            {
                sub = group.SubGroups.FirstOrDefault(x => x.Id == subId);
            });
            
            return sub;
        }
        
        public static async Task<SubGroup> GetSubGroup(this DbSet<Faculty> db, int facultyId, int specId,
            int groupId, int subId)
        {
            SubGroup sub = null;

            var faculty = await db.GetFaculty(facultyId);
            var speciality = await faculty.GetSpeciality(specId);
            var group = await speciality.GetGroup(groupId);

            await Task.Run(() =>
            {
                sub = group.SubGroups.FirstOrDefault(x => x.Id == subId);
            });
            
            return sub;
        }
        
        #endregion
    }
}