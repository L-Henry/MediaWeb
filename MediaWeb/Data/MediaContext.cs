using MediaWeb.Domain.MovieDomain;
using MediaWeb.Domain.MusicDomain;
using MediaWeb.Domain.PodcastDomain;
using MediaWeb.Domain.SerieDomain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Data
{
    public class MediaContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<GenreMovieCombo> GenreMovieCombo { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieGezienStatus> MovieGezienStatus { get; set; }
        public DbSet<MoviePlaylist> MoviePlaylist { get; set; }
        public DbSet<MovieRatingReview> MovieRatingReview { get; set; }
        public DbSet<MovieRegisseur> MovieRegisseur { get; set; }
        public DbSet<UserMovieFav> UserMovieFav { get; set; }
        public DbSet<UserMovieGezienStatus> UserMovieGezienStatus { get; set; }
        public DbSet<MoviePlaylistCombo> MoviePlaylistCombo { get; set; }
        public DbSet<MovieRegisseurCombo> MovieRegisseurCombo { get; set; }


        public DbSet<GenreMusicCombo> GenreMusicCombo { get; set; }
        public DbSet<Music> Music { get; set; }
        public DbSet<MusicAlbum> MusicAlbum { get; set; }
        public DbSet<MusicArtist> MusicArtist { get; set; }
        public DbSet<MusicBeluisterdStatus> MusicBeluisterdStatus { get; set; }
        public DbSet<MusicGenre> MusicGenre { get; set; }
        public DbSet<MusicPlaylist> MusicPlaylist { get; set; }
        public DbSet<MusicRatingReview> MusicRatingReview { get; set; }
        public DbSet<UserMusicBesluisterdStatus> UserMusicBesluisterdStatus { get; set; }
        public DbSet<UserMusicFav> UserMusicFav { get; set; }
        public DbSet<MusicPlaylistCombo> MusicPlaylistCombo { get; set; }


        public DbSet<Podcast> Podcast { get; set; }
        public DbSet<PodcastBelsuiterdStatus> PodcastBelsuiterdStatus { get; set; }
        public DbSet<PodcastMaker> PodcastMaker { get; set; }
        public DbSet<PodcastOnderwerpen> PodcastOnderwerpen { get; set; }
        public DbSet<PodcastSerie> PodcastSerie { get; set; }
        public DbSet<UserPodcastBeluisterdStatus> UserPodcastBelsuiterd { get; set; }
        public DbSet<UserPodcastFav> UserPodcastFav { get; set; }
        public DbSet<PodcastRatingReview> PodcastRatingReview { get; set; }
        public DbSet<PodcastOnderwerpCombo> PodcastOnderwerpCombo { get; set; }
        public DbSet<PodcastPlaylist> PodcastPlaylist { get; set; }
        public DbSet<PodcastPlaylistCombo> PodcastPlaylistCombo { get; set; }
        public DbSet<PodcastSerieCombo> PodcastSerieCombo { get; set; }


        public DbSet<GenreSerieCombo> GenreSerieCombo { get; set; }
        public DbSet<Serie> Serie { get; set; }
        public DbSet<SerieGenre> SerieGenre { get; set; }
        public DbSet<SerieGezienStatus> SerieGezienStatus { get; set; }
        public DbSet<SerieRatingReview> SerieRatingReview { get; set; }
        public DbSet<SeriesEpisodes> SeriesEpisodes { get; set; }
        public DbSet<UserSerieGezienStatus> UserSerieGezienStatus { get; set; }
        public DbSet<SeriesEpisodesCombo> SeriesEpisodesCombo { get; set; }
        public DbSet<SeriesEpisodeRatingReview> SeriesEpisodeRatingReview { get; set; }
        public DbSet<UserSeriesEpisodesGezienStatus> UserSeriesEpisodesGezienStatus { get; set; }
        public DbSet<SeriesEpisodesPlaylistCombo> SeriesEpisodesPlaylistCombo { get; set; }
        public DbSet<SeriesEpisodesPlaylist> SeriesEpisodesPlaylist { get; set; }




        public MediaContext(DbContextOptions<MediaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieRatingReview>().HasKey(rr => new { rr.MovieId, rr.UserId });
            modelBuilder.Entity<UserMovieGezienStatus>().HasKey(umgs => new { umgs.MovieId, umgs.UserId });
            modelBuilder.Entity<GenreMovieCombo>().HasKey(mg => new { mg.MovieId, mg.MovieGenreId });
            modelBuilder.Entity<UserMovieFav>().HasKey(mg => new { mg.MovieId, mg.UserId });
            modelBuilder.Entity<MoviePlaylistCombo>().HasKey(mg => new { mg.MoviePlaylistId, mg.MovieId });
            modelBuilder.Entity<MovieRegisseurCombo>().HasKey(mg => new { mg.MovieId, mg.MovieRegisseurId });

            modelBuilder.Entity<UserMusicBesluisterdStatus>().HasKey(umgs => new { umgs.MusicId, umgs.UserId });
            modelBuilder.Entity<MusicRatingReview>().HasKey(rr => new { rr.MusicId, rr.UserId });
            modelBuilder.Entity<GenreMusicCombo>().HasKey(rr => new { rr.MusicId, rr.MusicGenreId });
            modelBuilder.Entity<MusicPlaylistCombo>().HasKey(mg => new { mg.MusicPlaylistId, mg.MusicId });
            modelBuilder.Entity<UserMusicFav>().HasKey(mg => new { mg.MusicId, mg.UserId });

            modelBuilder.Entity<PodcastRatingReview>().HasKey(rr => new { rr.PodcastId, rr.UserId });
            modelBuilder.Entity<UserPodcastBeluisterdStatus>().HasKey(umgs => new { umgs.PodcastId, umgs.UserId });
            modelBuilder.Entity<UserPodcastFav>().HasKey(umgs => new { umgs.PodcastId, umgs.UserId });
            modelBuilder.Entity<PodcastOnderwerpCombo>().HasKey(umgs => new { umgs.PodcastId, umgs.PodcastOnderwerpId });
            modelBuilder.Entity<PodcastPlaylistCombo>().HasKey(umgs => new { umgs.PodcastPlaylistId, umgs.PodcastId });
            modelBuilder.Entity<PodcastSerieCombo>().HasKey(ps => new { ps.PodcastId, ps.PodcastSerieId });

            modelBuilder.Entity<SerieRatingReview>().HasKey(rr => new { rr.SerieId, rr.UserId });
            modelBuilder.Entity<UserSerieGezienStatus>().HasKey(umgs => new { umgs.SerieId, umgs.UserId });
            modelBuilder.Entity<SeriesEpisodesCombo>().HasKey(umgs => new { umgs.SerieId, umgs.SeriesEpisodeId });
            modelBuilder.Entity<SeriesEpisodeRatingReview>().HasKey(umgs => new { umgs.SeriesEpisodesId, umgs.UserId });
            modelBuilder.Entity<GenreSerieCombo>().HasKey(umgs => new { umgs.SerieId, umgs.SerieGenreId });
            modelBuilder.Entity<UserSeriesEpisodesGezienStatus>().HasKey(umgs => new { umgs.UserId, umgs.SeriesEpisodeId });
            modelBuilder.Entity<SeriesEpisodesPlaylistCombo>().HasKey(umgs => new { umgs.SeriesEpisodeId, umgs.SeriesEpisodesPlaylistId });



            base.OnModelCreating(modelBuilder);
        }

    }
}
