using System.ComponentModel.DataAnnotations;

namespace Admin.Models.User.Info
{
    public class AllowedSubgroups
    {
        [Key]
        public int Id { get; set; }
        
        public int SubgroupId { get; set; }
    }
}