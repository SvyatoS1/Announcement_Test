using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestTask_Frontend.Models;
using TestTask_Frontend.Services;

namespace TestTask_Frontend.Pages.Announcements
{
    public class CreateModel : PageModel
    {
        private readonly AnnouncementService _announcementService;

        [BindProperty]
        public Announcement Announcement { get; set; }

        public CreateModel(AnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _announcementService.CreateAnnouncementAsync(Announcement);
            return RedirectToPage("Index");
        }
    }
}
