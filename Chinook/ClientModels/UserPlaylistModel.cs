﻿using Chinook.Models;

namespace Chinook.ClientModels
{
    public class UserPlaylistModel
    {
        public string UserId { get; set; }
        public long PlaylistId { get; set; }
        public ChinookUser User { get; set; }
        public PlaylistData Playlist { get; set; }
    }
}
