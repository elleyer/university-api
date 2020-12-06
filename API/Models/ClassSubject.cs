using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Admin.Models
{
    public class ClassSubject
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        
        public int Index { get; set; }
        
        public string Name { get; set; }
        
        public string Link { get; set; }
        
        public DateTime StartTime { get; set; }
        
        public DateTime EndTime { get; set; }

        public LessonType LessonType { get; set; }
        
        public LessonContext LessonContext { get; set; }
    }
}