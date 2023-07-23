using Chinook.ClientModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Chinook.Managers
{
    /// <summary>
    /// Manager for getting, setting tracks
    /// </summary>
    public class TracksManager
    {
        private readonly ChinookContext _dbContext;

        /// <summary>
        /// Injecting the db context using DI - Constructor injection
        /// </summary>
        /// <param name="dbContext"></param>
        public TracksManager(ChinookContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get tracks based on Artist id and current user id
        /// </summary>
        /// <param name="ArtistId"></param>
        /// <param name="CurrentUserId"></param>
        /// <returns></returns>
        public List<PlaylistTrack> GetTracks(long ArtistId, string CurrentUserId)
        {
            try
            {
                var tracks = _dbContext.Tracks;
                return tracks.Where(a => a.Album.ArtistId == ArtistId)
                .Include(a => a.Album)
                .Select(t => new PlaylistTrack()
                {
                    AlbumTitle = (t.Album == null ? "-" : t.Album.Title),
                    TrackId = t.TrackId,
                    TrackName = t.Name,
                    IsFavorite = t.Playlists.Where(p => p.UserPlaylists.Any(up => up.UserId == CurrentUserId && up.Playlist.Name == Constants.FavouriteListName)).Any()
                })
                .ToList();
            }
            catch (Exception ex)
            {
                return new List<PlaylistTrack>();
            }

        }
    }
}
