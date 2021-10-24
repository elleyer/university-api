using System.ComponentModel.DataAnnotations;

namespace Admin.Models.Mod.Info
{
    public class AllowedSpecialities
    {
        [Key]
        public int Id { get; set; }
        
        public int SpecialityId { get; set; }
    }
}