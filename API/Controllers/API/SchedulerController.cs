using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Database;
using Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Admin.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchedulerController : ControllerBase
    {
        private readonly SchedulerContext _db;

        public SchedulerController(SchedulerContext context)
        {
            _db = context;

            if (_db.Schedulers.Any()) return;

            _db.Schedulers.Add(new Scheduler
            {
                FacultyAndGroup = "fis-sp12",
                SchedulerDays = new List<SchedulerDay>()
                {
                    new SchedulerDay()
                    {
                        ScheduleWeekDay = ScheduleWeekDay.Monday,
                        ClassSubjects = new List<ClassSubject>
                        {
                            new ClassSubject
                            {
                                EndTime = DateTime.Now,
                                Index = 1,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "Math",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            },
                            new ClassSubject()
                            {
                                EndTime = DateTime.Now,
                                Index = 2,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "English",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            }
                        }
                    },
                    new SchedulerDay()
                    {
                        ScheduleWeekDay = ScheduleWeekDay.Tuesday,
                        ClassSubjects = new List<ClassSubject>
                        {
                            new ClassSubject
                            {
                                EndTime = DateTime.Now,
                                Index = 1,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "Math",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            },
                            new ClassSubject()
                            {
                                EndTime = DateTime.Now,
                                Index = 2,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "English",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            }
                        }
                    },
                    new SchedulerDay()
                    {
                        ScheduleWeekDay = ScheduleWeekDay.Wednesday,
                        ClassSubjects = new List<ClassSubject>
                        {
                            new ClassSubject
                            {
                                EndTime = DateTime.Now,
                                Index = 1,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "Math",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            },
                            new ClassSubject()
                            {
                                EndTime = DateTime.Now,
                                Index = 2,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "English",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            }
                        }
                    },
                    new SchedulerDay()
                    {
                        ScheduleWeekDay = ScheduleWeekDay.Thursday,
                        ClassSubjects = new List<ClassSubject>
                        {
                            new ClassSubject
                            {
                                EndTime = DateTime.Now,
                                Index = 1,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "Math",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            },
                            new ClassSubject()
                            {
                                EndTime = DateTime.Now,
                                Index = 2,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "English",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            }
                        }
                    },
                    new SchedulerDay()
                    {
                        ScheduleWeekDay = ScheduleWeekDay.Friday,
                        ClassSubjects = new List<ClassSubject>
                        {
                            new ClassSubject
                            {
                                EndTime = DateTime.Now,
                                Index = 1,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "Math",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            },
                            new ClassSubject()
                            {
                                EndTime = DateTime.Now,
                                Index = 2,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "English",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            }
                        }
                    },
                    new SchedulerDay()
                    {
                        ScheduleWeekDay = ScheduleWeekDay.Saturday,
                        ClassSubjects = new List<ClassSubject>
                        {
                            new ClassSubject
                            {
                                EndTime = DateTime.Now,
                                Index = 1,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "Math",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            },
                            new ClassSubject()
                            {
                                EndTime = DateTime.Now,
                                Index = 2,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "English",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            }
                        }
                    }
                }
            });
                
            _db.Schedulers.Add(new Scheduler
            {
                FacultyAndGroup = "fis-sp11",
                SchedulerDays = new List<SchedulerDay>()
                {
                    new SchedulerDay()
                    {
                        ScheduleWeekDay = ScheduleWeekDay.Monday,
                        ClassSubjects = new List<ClassSubject>
                        {
                            new ClassSubject
                            {
                                EndTime = DateTime.Now,
                                Index = 1,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "OP",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            },
                            new ClassSubject()
                            {
                                EndTime = DateTime.Now,
                                Index = 2,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "Math",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            }
                        }
                    },
                    new SchedulerDay()
                    {
                        ScheduleWeekDay = ScheduleWeekDay.Tuesday,
                        ClassSubjects = new List<ClassSubject>
                        {
                            new ClassSubject
                            {
                                EndTime = DateTime.Now,
                                Index = 1,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "XZ",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            },
                            new ClassSubject()
                            {
                                EndTime = DateTime.Now,
                                Index = 2,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "XZ2",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            }
                        }
                    },
                    new SchedulerDay()
                    {
                        ScheduleWeekDay = ScheduleWeekDay.Wednesday,
                        ClassSubjects = new List<ClassSubject>
                        {
                            new ClassSubject
                            {
                                EndTime = DateTime.Now,
                                Index = 1,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "WD1",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            },
                            new ClassSubject()
                            {
                                EndTime = DateTime.Now,
                                Index = 2,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "WD2",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            }
                        }
                    },
                    new SchedulerDay()
                    {
                        ScheduleWeekDay = ScheduleWeekDay.Thursday,
                        ClassSubjects = new List<ClassSubject>
                        {
                            new ClassSubject
                            {
                                EndTime = DateTime.Now,
                                Index = 1,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "Math",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            },
                            new ClassSubject()
                            {
                                EndTime = DateTime.Now,
                                Index = 2,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "English",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            }
                        }
                    },
                    new SchedulerDay()
                    {
                        ScheduleWeekDay = ScheduleWeekDay.Friday,
                        ClassSubjects = new List<ClassSubject>
                        {
                            new ClassSubject
                            {
                                EndTime = DateTime.Now,
                                Index = 1,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "Math",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            },
                            new ClassSubject()
                            {
                                EndTime = DateTime.Now,
                                Index = 2,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "English",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            }
                        }
                    },
                    new SchedulerDay()
                    {
                        ScheduleWeekDay = ScheduleWeekDay.Saturday,
                        ClassSubjects = new List<ClassSubject>
                        {
                            new ClassSubject
                            {
                                EndTime = DateTime.Now,
                                Index = 1,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "Math",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            },
                            new ClassSubject()
                            {
                                EndTime = DateTime.Now,
                                Index = 2,
                                LessonContext = LessonContext.Lecture,
                                LessonType = LessonType.Physical,
                                Link = "https://google.com",
                                Name = "English",
                                StartTime = DateTime.Now,
                                SubjectSubGroup = SubGroup.Second
                            }
                        }
                    }
                }
            });

            _db.SaveChanges();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scheduler>>> GetSchedulers()
        {
            return await _db.Schedulers.ToListAsync();
        }
        
        [HttpGet("{facultygroup}")]
        public async Task<ActionResult<Scheduler>> GetByFacultyAndGroup(string facultygroup)
        {
            return await _db.Schedulers.FirstOrDefaultAsync(
                x => x.FacultyAndGroup == facultygroup);
        }

        /*[HttpPost]
        public async Task<string> SetScheduler()
        {
            await _db.Schedulers.AddAsync(new )
        }*/
    }
}