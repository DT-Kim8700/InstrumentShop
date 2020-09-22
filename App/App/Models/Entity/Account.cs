using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entity
{
    public partial class Account : IdentityUser
    {
        // IdentityUser에 id, password, Email, UserName, PhoneNumber 를 사용한다.
        [Required]
        public string Address { get; set; }

        [Required]
        public string Gender { get; set; }
    }

    public partial class Account
    {
        [ForeignKey("Id")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
