using System.ComponentModel.DataAnnotations;

namespace Admin.Models.Mod.Info
{
    public class AllowedSubgroups
    {
        [Key]
        public int Id { get; set; }
        
        public int SubgroupId { get; set; }
    }
}