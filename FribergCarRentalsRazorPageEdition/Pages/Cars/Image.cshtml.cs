using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FribergCarRentalsRazorPageEdition.Pages.Cars
{
    public class ImageModel : PageModel
    {
        public string ImageLink { get; set; }

        public void OnGet(string imageLink)
        {
            ImageLink = imageLink;
        }

    }
}
