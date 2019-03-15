namespace Shop.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using Data.Entities;
    using Microsoft.AspNetCore.Http;

    public class ProductViewModel : Product
    {
        [Display(Name = "image")]

        public IFormFile ImageFile { get; set; }
    }
}
