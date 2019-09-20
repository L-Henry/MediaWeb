using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Music
{
    public class Music
    {
        public int Id { get; set; }
        public int Speelduur { get; set; }
        public ICollection<GenreMusicGenre> MuziekGenres { get; set; }
        public int MusicArtistId { get; set; }
        public MusicArtist MusicArtist { get; set; }
        public byte[] CoverFoto { get; set; }
        public int MusicAlbumId { get; set; }
        public MusicAlbum MusicAlbum { get; set; }
        public ICollection<UserMusicPlaylist> UserMusicPlaylists { get; set; }
        public ICollection<UserMusicFav> UserMusicFavs { get; set; }
        public ICollection<MusicRatingReview> MusicRatingReview { get; set; }
        public ICollection<UserMusicBesluisterdStatus> UserMusicBeluisterdStatus { get; set; }

        public bool Zichtbaar { get; set; } = true;
    }
}
