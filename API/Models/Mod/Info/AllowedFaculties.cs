using System.ComponentModel.DataAnnotations;

namespace Admin.Models.Mod.Info
{
    public class AllowedFaculties
    {
        [Key]
        public int Id { get; set; }
        
        public int FacultyId { get; set; }
    }
}