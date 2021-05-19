using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommercePortfolio.Models
{
    public class Order
    {
        //This defines the order details users will use to place their order details. 
        [BindNever]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Please Enter Your First Name")]
        [Display(Name = "First Name")]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Last Name")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Address")]
        [Display(Name = "Street Address")]
        [StringLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter Your City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter Your State")]
        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }

        [Required(ErrorMessage = "Please Enter Your Zip")]
        [StringLength(5, MinimumLength = 5)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Please Enter Your Phonenumber")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        [BindNever]
        public decimal OrderTotal { get; set; }

        //the time when the order is placed
        [BindNever]
        public DateTime OrderPlaced { get; set; }
    }
}
