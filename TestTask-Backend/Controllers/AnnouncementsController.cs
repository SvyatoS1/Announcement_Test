using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using TestTask_Backend.Services;

namespace TestTask_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly AnnouncementService _announcementService;

        public AnnouncementsController(AnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Announcement>>> GetAnnouncements()
        {
            var announcements = await _announcementService.GetAnnouncementsAsync();
            return Ok(announcements);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Announcement>>> GetAnnouncementsById(int id)
        {
            var announcement = await _announcementService.GetAnnouncementsByIdAsync(id);
            if (announcement == null)
            {
                return NotFound();
            }
            return Ok(announcement);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAnnouncement(Announcement announcement)
        {
            await _announcementService.AddAnnouncementsAsync(announcement);
            return CreatedAtAction(nameof(GetAnnouncements), new {id = announcement.Id});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAnnouncement(int id, Announcement announcement)
        {
            if (id != announcement.Id)
            {
                return BadRequest();
            }

            await _announcementService.UpdateAnnouncementAsync(announcement);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAnnouncement(int id)
        {
            await _announcementService.DeleteAnnouncementAsync(id);
            return NoContent();
        }
    }
}
