using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestTask_Frontend.Models;
using TestTask_Frontend.Services;

namespace TestTask_Frontend.Pages.Announcements
{
    public class IndexModel : PageModel
    {
        private readonly AnnouncementService _announcementService;

        public IndexModel(AnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IEnumerable<Announcement> Announcements { get; private set; }

        public async Task OnGetAsync()
        {
            Announcements = await _announcementService.GetAnnouncementsAsync();
        }
    }
}
