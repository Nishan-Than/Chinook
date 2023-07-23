using Chinook.Models;
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


        /// <summary>
        /// Injecting the db context class using DI - Constructor injection
        /// </summary>
        /// <param name="dbContext"></param>
        public ArtistsManager(ChinookContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get All artists
        /// </summary>
        /// <returns></returns>
        public async Task<List<Artist>> GetArtists(string searchTerm = "")
        {
            try
            {
                var users = _dbContext.Users.Include(a => a.UserPlaylists).ToList();
                var artists = searchTerm.IsNullOrEmpty() ? _dbContext.Artists.Include(x => x.Albums).ToList() : _dbContext.Artists.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())).Include(x => x.Albums).ToList();

                return artists;
            }
            catch (Exception ex)
            {
                return new List<Artist>();
            }

        }

        /// <summary>
        /// Get Albums of an artist based on artistId
        /// </summary>
        /// <param name="artistId"></param>
        /// <returns></returns>
        public async Task<List<Album>> GetAlbumsForArtist(int artistId)
        {
            try
            {
                return _dbContext.Albums.Where(a => a.ArtistId == artistId).ToList();
            }
            catch (Exception ex)
            {
                return new List<Album>();
            }
        }
    }
}
