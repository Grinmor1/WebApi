using System.ComponentModel.DataAnnotations;

namespace WebApiDataLayer.Models
{
    public class User: IDataBaseModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
       // [Required(ErrorMessage = "Name must be filled")]
        public string Name { get; set; }
        public string Surname { get; set; }
       // [Required(ErrorMessage = "Password must be filled")]
        public string Password { get; set; }
        //[Required(ErrorMessage = "Email must be filled")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Age must be filled")]
        public int Age { get; set; }
    }
}
