using System.ComponentModel.DataAnnotations;

namespace Admin.Models.User.Info
{
    public class AllowedSpecialities
    {
        [Key]
        public int Id { get; set; }
        
        public int SpecialityId { get; set; }
    }
}