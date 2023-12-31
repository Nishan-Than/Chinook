﻿using Chinook.Models;

namespace Chinook.ClientModels
{
    public class ArtistModel
    {
        public long ArtistId { get; set; }
        public string? Name { get; set; }

        public ICollection<Album> Albums { get; set; }
    }
}
