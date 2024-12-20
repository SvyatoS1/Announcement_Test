using Microsoft.AspNetCore.Authentication;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.ComponentModel;
using Microsoft.VisualBasic;

namespace TestTask_Backend.Services
{
    public class AnnouncementService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public AnnouncementService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Announcement>> GetAnnouncementsAsync()
        {
            using (var connection = Connection)
            {
                var announcements = await connection.QueryAsync<Announcement>("SelectAnnouncements", commandType: CommandType.StoredProcedure);
                return announcements;
            }
        }

        public async Task<Announcement> GetAnnouncementsByIdAsync(int id)
        {
            using (var connection = Connection)
            {
                var parameters = new {Id = id};
                var announcement = await connection.QueryFirstOrDefaultAsync<Announcement>("SelectAnnouncementsById", parameters, commandType: CommandType.StoredProcedure);
                return announcement;
            }
        }

        public async Task<int> AddAnnouncementsAsync(Announcement announcement)
        {
            using (var connection = Connection)
            {
                var parameters = new
                {
                    announcement.Title,
                    announcement.Description,
                    announcement.Status,
                    announcement.Category,
                    announcement.SubCategory
                };
                var result = await connection.ExecuteAsync("InsertAnnouncement", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> UpdateAnnouncementAsync(Announcement announcement)
        {
            using (var connection = Connection)
            {
                var parameters = new
                {
                    announcement.Id,
                    announcement.Title,
                    announcement.Description,
                    announcement.Status,
                    announcement.Category,
                    announcement.SubCategory
                };
                var result = await connection.ExecuteAsync("UpdateAnnouncement", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> DeleteAnnouncementAsync(int id)
        {
            using (var connection = Connection)
            {
                var parameters = new { Id = id };
                var result = await connection.ExecuteAsync("DeleteAnnouncement", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

    }
}
