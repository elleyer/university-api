using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Database;
using Admin.Models;
using Admin.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Admin.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchedulerController : ControllerBase
    {
        private readonly FacultyContext _db;
        private readonly SchedulerContext _schedulerDb;

        public SchedulerController(FacultyContext facultyContext, SchedulerContext schedulerContext)
        {
            _db = facultyContext;

            _schedulerDb = schedulerContext;

            if (!_db.Faculties.Any())
            {
                _db.Faculties.Add(new Faculty
                {
                    NameEn = "fis",
                    NameUa = "фіс",
                    Specialities = new List<Speciality>
                    {
                        new Speciality
                        {
                            Code = 121,
                            DescriptionUa = "Інженерія програмного забезпечення",
                            Groups = new List<Group>
                            {
                                new Group
                                {
                                    Code = 11,
                                    NameEn = "sp",
                                    NameUa = "сп",
                                    SubGroups = new List<SubGroup>
                                    {
                                        new SubGroup
                                        {
                                            Code = 1,
                                            Scheduler = new Scheduler
                                            {
                                                SchedulerDays = new List<SchedulerDay>
                                                {
                                                    new SchedulerDay
                                                    {
                                                        ScheduleWeekDay = ScheduleWeekDay.Monday,
                                                        ClassSubjects = new List<ClassSubject>
                                                        {
                                                            new ClassSubject
                                                            {
                                                                StartTime = DateTime.Now,
                                                                EndTime = DateTime.Now,
                                                                Index = 1,
                                                                LessonContext = LessonContext.Lecture,
                                                                LessonType = LessonType.Physical,
                                                                Link = "google.com",
                                                                Name = "test",
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        },
                                        
                                        new SubGroup
                                        {
                                            Code = 2,
                                            Scheduler = new Scheduler
                                            {
                                                SchedulerDays = new List<SchedulerDay>
                                                {
                                                    new SchedulerDay
                                                    {
                                                        ScheduleWeekDay = ScheduleWeekDay.Monday,
                                                        ClassSubjects = new List<ClassSubject>
                                                        {
                                                            new ClassSubject
                                                            {
                                                                StartTime = DateTime.Now,
                                                                EndTime = DateTime.Now,
                                                                Index = 1,
                                                                LessonContext = LessonContext.Lecture,
                                                                LessonType = LessonType.Physical,
                                                                Link = "google.com",
                                                                Name = "test2sub",
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                },
                                
                                new Group
                                {
                                    Code = 12,
                                    NameEn = "sp",
                                    NameUa = "сп",
                                    SubGroups = new List<SubGroup>
                                    {
                                        new SubGroup
                                        {
                                            Code = 1,
                                            Scheduler = new Scheduler
                                            {
                                                SchedulerDays = new List<SchedulerDay>
                                                {
                                                    new SchedulerDay
                                                    {
                                                        ScheduleWeekDay = ScheduleWeekDay.Monday,
                                                        ClassSubjects = new List<ClassSubject>
                                                        {
                                                            new ClassSubject
                                                            {
                                                                StartTime = DateTime.Now,
                                                                EndTime = DateTime.Now,
                                                                Index = 1,
                                                                LessonContext = LessonContext.Lecture,
                                                                LessonType = LessonType.Physical,
                                                                Link = "google.com",
                                                                Name = "test",
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        },
                                        
                                        new SubGroup
                                        {
                                            Code = 2,
                                            Scheduler = new Scheduler
                                            {
                                                SchedulerDays = new List<SchedulerDay>
                                                {
                                                    new SchedulerDay
                                                    {
                                                        ScheduleWeekDay = ScheduleWeekDay.Monday,
                                                        ClassSubjects = new List<ClassSubject>
                                                        {
                                                            new ClassSubject
                                                            {
                                                                StartTime = DateTime.Now,
                                                                EndTime = DateTime.Now,
                                                                Index = 1,
                                                                LessonContext = LessonContext.Lecture,
                                                                LessonType = LessonType.Physical,
                                                                Link = "google.com",
                                                                Name = "test2sub",
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        
                        new Speciality
                        {
                            Code = 122,
                            DescriptionUa = "Інженерія програмного забезпечення",
                            Groups = new List<Group>
                            {
                                new Group
                                {
                                    Code = 11,
                                    NameEn = "sp",
                                    NameUa = "сп",
                                    SubGroups = new List<SubGroup>
                                    {
                                        new SubGroup
                                        {
                                            Code = 1,
                                            Scheduler = new Scheduler
                                            {
                                                SchedulerDays = new List<SchedulerDay>
                                                {
                                                    new SchedulerDay
                                                    {
                                                        ScheduleWeekDay = ScheduleWeekDay.Monday,
                                                        ClassSubjects = new List<ClassSubject>
                                                        {
                                                            new ClassSubject
                                                            {
                                                                StartTime = DateTime.Now,
                                                                EndTime = DateTime.Now,
                                                                Index = 1,
                                                                LessonContext = LessonContext.Lecture,
                                                                LessonType = LessonType.Physical,
                                                                Link = "google.com",
                                                                Name = "test",
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        },
                                        
                                        new SubGroup
                                        {
                                            Code = 2,
                                            Scheduler = new Scheduler
                                            {
                                                SchedulerDays = new List<SchedulerDay>
                                                {
                                                    new SchedulerDay
                                                    {
                                                        ScheduleWeekDay = ScheduleWeekDay.Monday,
                                                        ClassSubjects = new List<ClassSubject>
                                                        {
                                                            new ClassSubject
                                                            {
                                                                StartTime = DateTime.Now,
                                                                EndTime = DateTime.Now,
                                                                Index = 1,
                                                                LessonContext = LessonContext.Lecture,
                                                                LessonType = LessonType.Physical,
                                                                Link = "google.com",
                                                                Name = "test2sub",
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                },
                                
                                new Group
                                {
                                    Code = 12,
                                    NameEn = "sp",
                                    NameUa = "сп",
                                    SubGroups = new List<SubGroup>
                                    {
                                        new SubGroup
                                        {
                                            Code = 1,
                                            Scheduler = new Scheduler
                                            {
                                                SchedulerDays = new List<SchedulerDay>
                                                {
                                                    new SchedulerDay
                                                    {
                                                        ScheduleWeekDay = ScheduleWeekDay.Monday,
                                                        ClassSubjects = new List<ClassSubject>
                                                        {
                                                            new ClassSubject
                                                            {
                                                                StartTime = DateTime.Now,
                                                                EndTime = DateTime.Now,
                                                                Index = 1,
                                                                LessonContext = LessonContext.Lecture,
                                                                LessonType = LessonType.Physical,
                                                                Link = "google.com",
                                                                Name = "test",
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        },
                                        
                                        new SubGroup
                                        {
                                            Code = 2,
                                            Scheduler = new Scheduler
                                            {
                                                SchedulerDays = new List<SchedulerDay>
                                                {
                                                    new SchedulerDay
                                                    {
                                                        ScheduleWeekDay = ScheduleWeekDay.Monday,
                                                        ClassSubjects = new List<ClassSubject>
                                                        {
                                                            new ClassSubject
                                                            {
                                                                StartTime = DateTime.Now,
                                                                EndTime = DateTime.Now,
                                                                Index = 1,
                                                                LessonContext = LessonContext.Lecture,
                                                                LessonType = LessonType.Physical,
                                                                Link = "google.com",
                                                                Name = "test2sub",
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                });
            };

            _db.SaveChanges();
        }
        
        [HttpGet("byFaculty")]
        public async Task<ActionResult<Scheduler>> GetByFacultyAndGroup(string fc, int spec, 
            string gr, int grCode, int sub)
        {
            var faculty = await _db.Faculties.FirstOrDefaultAsync(p => p.NameEn == fc);
            
            var speciality = faculty.Specialities.FirstOrDefault(p => p.Code == spec);

            var group = speciality?.Groups.FirstOrDefault(p => p.NameEn == gr && p.Code == grCode);
            
            return group?.SubGroups.FirstOrDefault(p => p.Code == sub)?.Scheduler;
        }

        [HttpPost("update")]
        public async Task<string> Update([FromBody] UpdateRequest request)
        {
            var faculty = await _db.Faculties.FirstOrDefaultAsync(p => p.NameEn == request.Faculty);
            
            var speciality = faculty.Specialities.FirstOrDefault(p => p.Code == request.Speciality);

            var group = speciality?.Groups.FirstOrDefault(p => p.NameEn == request.Group
                                                               && p.Code == request.GroupCode);

            var requested = group?.SubGroups.FirstOrDefault(p => p.Code == request.SubGroup)
                ?.Scheduler.SchedulerDays
                .FirstOrDefault(x => x.ScheduleWeekDay == request.SchedulerDay.ScheduleWeekDay);

            if (requested != null)
            {
                requested.ClassSubjects = request.SchedulerDay.ClassSubjects;
                requested.ScheduleWeekDay = request.SchedulerDay.ScheduleWeekDay;
            }
            
            await _db.SaveChangesAsync();
            
            return requested?.Id.ToString();
        }
        
        // Endpoint -> api/scheduler/fis/sp/21/2
    }
}