﻿using Chinook.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Managers
{
    /// <summary>
    /// Manager for refresh the Nav menu with the whole page reload
    /// </summary>
    public class NavMenuManager
    {
        private readonly ChinookContext _dbContext;
        public event EventHandler OnMenuUpdated;
        private readonly ILogger _logger;


        /// <summary>
        /// Injecting the DB context object using DI - Constructor injection
        /// </summary>
        /// <param name="dbContext"></param>
        public NavMenuManager(ChinookContext dbContext, ILogger<NavMenuManager> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }


        /// <summary>
        /// Use this method to refersh the Nav Menu without the page releoad
        /// </summary>
        public void GetUpdatedMenuByUser(string userId)
        {
            try
            {
                var list = _dbContext.UserPlaylists.Where(x => x.UserId == userId)
                                .Include(x => x.Playlist)
                                .ThenInclude(x => x.Tracks)
                                .OrderBy(x => x.PlaylistId)
                                .ToList();

                list.Add(AddDefaultPlayList());
                list.OrderBy(x => x.PlaylistId).ToList();

                OnMenuUpdated?.Invoke(this, EventArgs.Empty);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

        }

        private UserPlaylist AddDefaultPlayList()
        {
            var defaultPlayList = new UserPlaylist();
            defaultPlayList.Playlist = new PlaylistData();
            defaultPlayList.PlaylistId = Constants.DefaultPlayListId;
            defaultPlayList.Playlist.Name = Constants.DefaultPlayListName;

            return defaultPlayList;
        }
    }
}
