using System.ComponentModel.DataAnnotations;

namespace Admin.Models.Mod.Info
{
    public class AllowedGroups
    {
        [Key]
        public int Id { get; set; }
        
        public int GroupId { get; set; }
    }
}