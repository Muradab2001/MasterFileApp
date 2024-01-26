using System.ComponentModel.DataAnnotations;

namespace MasterFile.ViewModels
{
    public class LoginVM
    {
        [Required, StringLength(30)]
        public string UserName { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
