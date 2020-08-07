using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelloMvc.Models
{
    public class Customer
    {
        public string Id { get; set; }

        [Required]
        [DisplayName("Enter Your Name")]
        [StringLength(10,ErrorMessage="Your string is too long!")]
        public string Name { get; set; }

        [Required]
        [StringLength(10,ErrorMessage="It Should be only 10 digits")]
        public string Telephone { get; set; }

        internal object Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}