using System;
using System.ComponentModel.DataAnnotations;
using IndyBooks.Models;

namespace IndyBooks.ViewModels
{
    public class AddBookViewModel
    {
        public string Title { get; set; }
        public string SKU { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Display(Name = "Author Name")]
        public String Name { get; set; }
    }
}
