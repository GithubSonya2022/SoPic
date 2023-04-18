using System;
using System.ComponentModel.DataAnnotations;

namespace SoPic.Data.Models
{
    public class Photo:BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Price, BGN")]
        [Range(20, 100000, ErrorMessage = "Price should be greater than 20 BGN")]
        public int Price { get; set; }

        [Display(Name = "Buyer Name")]
        public string BuyerName { get; set; }

        [Display(Name = "Buyer Address")]
       public string BuyerAddress { get; set; }
        
        [Display(Name = "Buyer Phone")]
        public string BuyerPhone { get; set; }
       
        [Display(Name = "Purchse Date")]
        public DateTime PurchseDate { get; set; }

        [Display(Name = "Genre")]
        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public Guid GenreId { get; set; }

        internal object Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
