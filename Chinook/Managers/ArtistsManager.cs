using Chinook.ClientModels;
using Chinook.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Chinook.Managers
{
    /// <summary>
    /// Manager for Artist related operations
    /// </summary>
    public class ArtistsManager
    {
        private readonly ChinookContext _dbContext;
        private readonly ILogger _logger;


        /// <summary>
        /// Injecting the db context class using DI - Constructor injection
        /// </summary>
        /// <param name="dbContext"></param>
        public ArtistsManager(ChinookContext dbContext, ILogger<ArtistsManager> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Get All artists
        /// </summary>
        /// <returns>ArtistModel client model is returing here</returns>
        public async Task<List<ArtistModel>> GetArtists(string searchTerm = "")
        {
            try
            {
                var users = _dbContext.Users.Include(a => a.UserPlaylists).ToList();
                var artists = searchTerm.IsNullOrEmpty() ? _dbContext.Artists.Include(x => x.Albums).ToList() : _dbContext.Artists.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())).Include(x => x.Albums).ToList();
                var artistModel = artists.Select(x => new ArtistModel
                {
                    ArtistId = x.ArtistId,
                    Name = x.Name,
                    Albums = x.Albums,
                }).ToList();

                return artistModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);               
            }
            return new List<ArtistModel>();

        }

        /// <summary>
        /// Get Albums of an artist based on artistId
        /// </summary>
        /// <param name="artistId"></param>
        /// <returns>AlbumModel client model is returing here</returns>
        public async Task<List<AlbumModel>> GetAlbumsForArtist(int artistId)
        {
            try
            {
                return _dbContext.Albums.Where(a => a.ArtistId == artistId).Select(x => new AlbumModel()
                {
                    AlbumId = x.AlbumId,
                    Title = x.Title,
                    ArtistId = x.ArtistId,
                    Artist = x.Artist,
                    Tracks = x.Tracks
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);               
            }
            return new List<AlbumModel>();
        }
    }
}
