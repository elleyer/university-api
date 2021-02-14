using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Admin.Models.Scheduler
{
    public class SubjectModel
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        
        [JsonProperty("index")]
        public int Index { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("link")]
        public string Link { get; set; }
        
        [JsonProperty("startTime")]
        public DateTime StartTime { get; set; }
        
        [JsonProperty("endTime")]
        public DateTime EndTime { get; set; }

        [JsonProperty("lessonType")]
        public LessonType LessonType { get; set; }
        
        [JsonProperty("lessonContext")]
        public LessonContext LessonContext { get; set; }
    }
}