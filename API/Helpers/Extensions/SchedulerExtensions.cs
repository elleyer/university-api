using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Exceptions;
using Admin.Models;
using Admin.Models.Scheduler;
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
        
        #region GetByRaw
        
        public static async Task<Faculty> GetFaculty(this DbSet<Faculty> db, string name)
        {
            Faculty faculty = null;

            await Task.Run(() => 
            {
                faculty = db.FirstOrDefaultAsync(x => x.NameEn == name.ToLower())?.Result;
            });
            
            if (faculty == null)
                throw new NotFoundException($"Can't find a faculty '{name}'");
            
            return faculty;
        }
        
        public static async Task<Speciality> GetSpeciality(this Faculty faculty, int code)
        {
            Speciality speciality = null;

            await Task.Run(() =>
            {
                speciality = faculty?.Specialities.FirstOrDefault(x => x.Code == code);
            });

            if (speciality == null)
                throw new NotFoundException($"Can't find a speciality with code '{code}' on '{faculty.NameEn}'");
            
            return speciality;
        }
        
        public static async Task<Group> GetGroup(this Speciality speciality, string name, int code)
        {
            Group group = null;

            await Task.Run(() =>
            {
                group = speciality.Groups?.FirstOrDefault(x => x.NameEn == name.ToLower() && x.Code == code);
            });
            
            if(group == null)
                throw new NotFoundException($"Can't find group '{name}-{code}' " +
                                            $"on speciality '{speciality.Code}'");
            
            return group;
        }
        
        public static async Task<SubGroup> GetSubGroup(this Group group, int code)
        {
            SubGroup sub = null;

            await Task.Run(() =>
            {
                sub = group.SubGroups?.FirstOrDefault(x => x.Code == code);
            });
            
            if(sub == null)
                throw new NotFoundException($"Can't find subgroup with code " +
                                            $"{code} on {group.NameEn} - {group.Code}");
            
            return sub;
        }
        
        public static async Task<SubGroup> GetSubGroup(this DbSet<Faculty> db, string fcName, int specCode,
            string groupName, int groupCode, int subCode)
        {
            var faculty = await db.GetFaculty(fcName);
            
            var speciality = await faculty.GetSpeciality(specCode);
            
            var group = await speciality.GetGroup(groupName, groupCode);

            return await group.GetSubGroup(subCode);
        }
        
        #endregion

        #region Add

        public static void CreateNew(this List<SchedulerDayModel> data, ScheduleWeekDay day)
        {
            if (data.Exists(schedulerModel => 
                schedulerModel.ScheduleWeekDay == day))
            {
                throw new AlreadyExistsException(
                    $"'{day.ToString()}' scheduler already exists.");
            }
            data.Add(new SchedulerDayModel()
            {
                ScheduleWeekDay = day
            });
        }
        
        public static void CreateNew(this List<SubjectModel> data, SubjectModel model)
        {
            if (data.Exists(subjectModel => subjectModel.Index == model.Index))
            {
                throw new AlreadyExistsException(
                    $"Subject with index '{model.Index}' already exists.");
            }
            data.Add(model);
        }
        
        public static void CreateNew(this List<SubGroup> data, int code)
        {
            if (data.Exists(subgroupModel => subgroupModel.Code == code))
            {
                throw new AlreadyExistsException(
                    $"Subgroup with id '{code}' already exists.");
            }
            data.Add(new SubGroup(code));
        }

        #endregion
    }
}