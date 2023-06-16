using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace myProject.Models.Customer
{
    public class CustomerModel
    {
        //Fields
        private int id;
        private string name;
        private string email;
        private string phone;

        //Properties - Validations
        [DisplayName("Customer ID")]
        public int Id
        {
            get => id; set => id = value;
        }

        [DisplayName("Customer Name")]
        [Required(ErrorMessage = "Customer Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Customer name must be between 3 and 50 characters")]
        public string Name
        {
            get => name; set => name = value;
        }

        [DisplayName("Customer Email")]
        [Required(ErrorMessage = "Customer Email is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Customer Email must be between 3 and 50 characters")]
        public string Email
        {
            get => email; set => email = value;
        }

        [DisplayName("Customer Phone")]
        [Required(ErrorMessage = "Customer Phone is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Customer Phone must be between 3 and 50 characters")]
        public string Phone
        {
            get => phone; set => phone = value;
        }
    }
}
