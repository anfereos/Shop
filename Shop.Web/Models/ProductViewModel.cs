namespace Shop.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using Data.Entities;

    public class ProductViewModel : Product
    {
        [Display(Name = "image")]
        public IFormFile ImageFile { get; set; }
    }
}
