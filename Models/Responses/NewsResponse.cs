using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Admin.Models
{
    public class NewsResponse
    {
        public virtual string Title { get; set; }
        
        public virtual string Data { get; set; } //own class with all markup and other stuff
        
        public virtual DateTime DateTime { get; set; }
        
        public virtual string Author { get; set; } //User class
    }
}