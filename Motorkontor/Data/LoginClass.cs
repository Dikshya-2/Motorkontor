using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Motorkontor.Data
{
    public class LoginClass
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Name is too long.")]
        public string UserName { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Password is too long.")]
        public string Password { get; set; }
    }
}
