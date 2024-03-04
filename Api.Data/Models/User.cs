using System.ComponentModel.DataAnnotations;

namespace Api.Data.Models
{
    public class User : UserAccount
    {
        [Key]
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime DateCreate { get; set; }
        public bool isAdmin { get; set; }
    }
}
