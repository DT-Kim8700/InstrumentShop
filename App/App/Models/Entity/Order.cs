using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entity
{
    public partial class Order
    {
        public enum EStatus
        {
            배송준비,
            배송중,
            배송완료,
            주문취소
        }

        [Key]
        public int OrderNumber { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public EStatus Status { get; set; }

        [Required]
        public int Id { get; set; }
    }

    public partial class Order
    {
        [ForeignKey("OrderNumber")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
