using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Hospital_Manager.Entities
{
    public class User : IdentityUser<Guid>
    {
        [Required, StringLength(10, MinimumLength = 3)]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(10, MinimumLength = 3)]
        public string LastName { get; set; }

        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }
    }
}
