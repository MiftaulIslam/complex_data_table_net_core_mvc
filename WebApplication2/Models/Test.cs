using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Test
    {
        [Key]
        public int Id{ get; set; }

        [Required]
        public string RegionalOffice { get; set; }
        public string RegionalStore { get; set; }
        public string DscCtgA { get; set; }
        
        public List<string> DscCtgAarray { get; set; }
        
        public string DscCtgB { get; set; }
        
        public List<string> DscCtgBarray { get; set; }

        public string UscCtgB { get; set; }
        
        public List<string> UscCtgBarray { get; set; }
        
    }
}
