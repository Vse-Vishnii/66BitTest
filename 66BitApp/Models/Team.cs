using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _66BitApp.Models
{
    public class Team : DbEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
