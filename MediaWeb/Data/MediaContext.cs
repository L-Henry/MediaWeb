using MediaWeb.Domain.Movie;
using MediaWeb.Domain.Music;
using MediaWeb.Domain.Podcast;
using MediaWeb.Domain.Serie;
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
        public DbSet<GenreMovieGenre> GenreMovieCombo { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieGezienStatus> MovieGezienStatus { get; set; }
        public DbSet<MoviePlaylist> MoviePlaylist { get; set; }
        public DbSet<MovieRatingReview> MovieRatingReview { get; set; }
        public DbSet<MovieRegisseur> MovieRegisseur { get; set; }
        public DbSet<UserMovieFav> UserMovieFav { get; set; }
        public DbSet<UserMovieGezienStatus> UserMovieGezienStatus { get; set; }
        public DbSet<UserMoviePlaylist> UserMoviePlaylist { get; set; }
        public DbSet<MovieRegisseurCombo> MovieRegisseurCombo { get; set; }


        public DbSet<GenreMusicGenre> GenreMusicGenre { get; set; }
        public DbSet<Music> Music { get; set; }
        public DbSet<MusicAlbum> MusicAlbum { get; set; }
        public DbSet<MusicArtist> MusicArtist { get; set; }
        public DbSet<MusicBeluisterdStatus> MusicBeluisterdStatus { get; set; }
        public DbSet<MusicGenre> MusicGenre { get; set; }
        public DbSet<MusicPlaylist> MusicPlaylist { get; set; }
        public DbSet<MusicRatingReview> MusicRatingReview { get; set; }
        public DbSet<UserMusicBesluisterdStatus> UserMusicBesluisterdStatus { get; set; }
        public DbSet<UserMusicFav> UserMusicFav { get; set; }
        public DbSet<UserMusicPlaylist> UserMusicPlaylist { get; set; }


        public DbSet<Podcast> Podcast { get; set; }
        public DbSet<PodcastBelsuiterdStatus> PodcastBelsuiterdStatus { get; set; }
        public DbSet<PodcastMaker> PodcastMaker { get; set; }
        public DbSet<PodcastOnderwerpen> PodcastOnderwerpen { get; set; }
        public DbSet<PodcastSerie> PodcastSerie { get; set; }
        public DbSet<UserPodcastBeluisterdStatus> UserPodcastBelsuiterd { get; set; }
        public DbSet<UserPodcastFav> UserPodcastFav { get; set; }
        public DbSet<PodcastRatingReview> PodcastRatingReview { get; set; }
        public DbSet<PodcastOnderwerpPodcast> PodcastOnderwerpPodcast { get; set; }
        public DbSet<PodcastPlaylist> PodcastPlaylist { get; set; }
        public DbSet<UserPodcastPlaylist> UserPodcastPlaylist { get; set; }


        public DbSet<GenreSerieGenre> GenreSerieGenre { get; set; }
        public DbSet<Serie> Serie { get; set; }
        public DbSet<SerieGenre> SerieGenre { get; set; }
        public DbSet<SerieGezienStatus> SerieGezienStatus { get; set; }
        public DbSet<SerieRatingReview> SerieRatingReview { get; set; }
        public DbSet<SeriesEpisodes> SeriesEpisodes { get; set; }
        public DbSet<UserSerieGezienStatus> UserSerieGezienStatus { get; set; }
        public DbSet<SeriesEpisodesInSeries> SeriesEpisodesInSeries { get; set; }
        public DbSet<SeriesEpisodeRatingReview> SeriesEpisodeRatingReview { get; set; }
        public DbSet<UserSeriesEpisodesGezienStatus> UserSeriesEpisodesGezienStatus { get; set; }
        public DbSet<UserSeriesEpisodesPlaylist> UserSeriesEpisodesPlaylist { get; set; }
        public DbSet<SeriesEpisodesPlaylist> SeriesEpisodesPlaylist { get; set; }




        public MediaContext(DbContextOptions<MediaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieRatingReview>().HasKey(rr => new { rr.MovieId, rr.UserId });
            modelBuilder.Entity<UserMovieGezienStatus>().HasKey(umgs => new { umgs.MovieId, umgs.UserId });
            modelBuilder.Entity<GenreMovieGenre>().HasKey(mg => new { mg.MovieId, mg.MovieGenreId });
            modelBuilder.Entity<UserMovieFav>().HasKey(mg => new { mg.MovieId, mg.UserId });
            modelBuilder.Entity<UserMoviePlaylist>().HasKey(mg => new { mg.MoviePlaylistId, mg.UserId });
            modelBuilder.Entity<MovieRegisseurCombo>().HasKey(mg => new { mg.MovieId, mg.MovieRegisseurId });

            modelBuilder.Entity<UserMusicBesluisterdStatus>().HasKey(umgs => new { umgs.MusicId, umgs.UserId });
            modelBuilder.Entity<MusicRatingReview>().HasKey(rr => new { rr.MusicId, rr.UserId });
            modelBuilder.Entity<GenreMusicGenre>().HasKey(rr => new { rr.MusicId, rr.MusicGenreId });
            modelBuilder.Entity<UserMusicPlaylist>().HasKey(mg => new { mg.MusicPlaylistId, mg.UserId });
            modelBuilder.Entity<UserMusicFav>().HasKey(mg => new { mg.MusicId, mg.UserId });

            modelBuilder.Entity<PodcastRatingReview>().HasKey(rr => new { rr.PodcastId, rr.UserId });
            modelBuilder.Entity<UserPodcastBeluisterdStatus>().HasKey(umgs => new { umgs.PodcastId, umgs.UserId });
            modelBuilder.Entity<UserPodcastFav>().HasKey(umgs => new { umgs.PodcastId, umgs.UserId });
            modelBuilder.Entity<PodcastOnderwerpPodcast>().HasKey(umgs => new { umgs.PodcastId, umgs.PodcastOnderwerpId });
            modelBuilder.Entity<UserPodcastPlaylist>().HasKey(umgs => new { umgs.PodcastPlaylistId, umgs.UserId });

            modelBuilder.Entity<SerieRatingReview>().HasKey(rr => new { rr.SerieId, rr.UserId });
            modelBuilder.Entity<UserSerieGezienStatus>().HasKey(umgs => new { umgs.SerieGezienStatus, umgs.UserId });
            modelBuilder.Entity<SeriesEpisodesInSeries>().HasKey(umgs => new { umgs.SerieId, umgs.SeriesEpisodeId });
            modelBuilder.Entity<SeriesEpisodeRatingReview>().HasKey(umgs => new { umgs.SeriesEpisodesId, umgs.UserId });
            modelBuilder.Entity<GenreSerieGenre>().HasKey(umgs => new { umgs.SerieId, umgs.SerieGenreId });
            modelBuilder.Entity<UserSeriesEpisodesGezienStatus>().HasKey(umgs => new { umgs.UserId, umgs.SeriesEpisodeId });
            modelBuilder.Entity<UserSeriesEpisodesPlaylist>().HasKey(umgs => new { umgs.UserId, umgs.SeriesEpisodesPlaylistId });



            base.OnModelCreating(modelBuilder);
        }

    }
}
