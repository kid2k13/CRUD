using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace myProject.Models.Product
{
    public class ProductModel
    {
        //Fields
        private int prodId;
        private string prodName;
        private decimal prodPrice;

        //Properties - Validations
        [DisplayName("Product ID")]
        public int Id
        {
            get => prodId; set => prodId = value;
        }

        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Product Name is required")]
        public string Name
        {
            get => prodName; set => prodName = value;
        }

        [DisplayName("Product Price")]
        [Required(ErrorMessage = "Product Price is required")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Invalid price input")]
        public decimal Price
        {
            get => prodPrice; set => prodPrice = value;
        }
    }
}
