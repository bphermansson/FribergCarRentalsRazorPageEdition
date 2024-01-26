using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCarRentals.DataAccess.Data;
using Car = FribergsCarRentals.DataAccess.Data.Car;

namespace FribergCarRentalsRazorPageEdition.Pages.Cars
{
    public class DeleteModel : PageModel
    {
        private ICarsRepository _carsRepository;

        public DeleteModel(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carsRepository.Get(id);

            if (car == null)
            {
                return NotFound();
            }
            else
            {
                Car = car;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var car = _carsRepository.Get(id);
            if (car != null)
            {
                _carsRepository.Delete(car);
            }
            return RedirectToPage("./Index");
        }
    }
}
