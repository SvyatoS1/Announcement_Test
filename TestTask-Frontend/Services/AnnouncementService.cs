using TestTask_Frontend.Models;

namespace TestTask_Frontend.Services
{
    public class AnnouncementService
    {
        private readonly HttpClient _httpClient;

        public AnnouncementService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Announcement>> GetAnnouncementsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Announcement>>("https://test-task-backend-a2gjcegjbmamatbd.westeurope-01.azurewebsites.net/api/announcements");
        }

        public async Task<Announcement> GetAnnouncementByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Announcement>($"https://test-task-backend-a2gjcegjbmamatbd.westeurope-01.azurewebsites.net/api/announcements/{id}");
        }

        public async Task CreateAnnouncementAsync(Announcement announcement)
        {
            await _httpClient.PostAsJsonAsync("https://test-task-backend-a2gjcegjbmamatbd.westeurope-01.azurewebsites.net/api/announcements", announcement);
        }

        public async Task UpdateAnnouncementAsync(Announcement announcement)
        {
            await _httpClient.PutAsJsonAsync($"https://test-task-backend-a2gjcegjbmamatbd.westeurope-01.azurewebsites.net/api/announcements/{announcement.Id}", announcement);
        }

        public async Task DeleteAnnouncementAsync(int id)
        {
            await _httpClient.DeleteAsync($"https://test-task-backend-a2gjcegjbmamatbd.westeurope-01.azurewebsites.net/api/announcements/{id}");
        }
    }
}
