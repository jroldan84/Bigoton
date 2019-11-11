using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Bigoton.Web.Data.Entities
{
    public class DiscountVoucher
    {

        public int Id { get; set; }

        [Display(Name = "Discount")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Discount { get; set; }

        public ICollection<Payment> Payments { get; set; }



    }
}
