using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories
{
	[BindProperties]
	public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
			if (Category?.Name == Category?.DisplayOrder.ToString())
			{
				ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name.");
			}

            if (ModelState.IsValid)
            {
                _db.categories.Add(Category);
                _db.SaveChanges();
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
