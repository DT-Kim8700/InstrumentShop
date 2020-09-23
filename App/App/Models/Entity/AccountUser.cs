using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entity
{
    public partial class AccountUser : IdentityUser
    {
        // IdentityUser에 id, password, Email, UserName, PhoneNumber 를 사용한다.

        // 1. UserName에 Email 값을 받아낸다. 로그인할 때 UserName값으로 인증을 하고 로그인할 떄 아이디 대신 Email을 입력하기 때문.
        // 2. IdentityUser의 UserName은 한글은 인식하지 못한다.

        [Key]
        public string AccountId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Gender { get; set; }
    }

    public partial class AccountUser
    {
        [ForeignKey("AccountId")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
