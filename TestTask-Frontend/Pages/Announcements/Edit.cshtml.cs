using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestTask_Frontend.Models;
using TestTask_Frontend.Services;

namespace TestTask_Frontend.Pages.Announcements
{
    public class EditModel : PageModel
    {
        private readonly AnnouncementService _announcementService;

        public EditModel(AnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [BindProperty]
        public Announcement Announcement { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Announcement = await _announcementService.GetAnnouncementByIdAsync(id);

            if (Announcement == null)
            {
                return NotFound();
            }

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _announcementService.UpdateAnnouncementAsync(Announcement);
            return RedirectToPage("Index");
        }
    }
}
