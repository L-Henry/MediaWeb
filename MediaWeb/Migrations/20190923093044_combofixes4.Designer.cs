﻿// <auto-generated />
using System;
using MediaWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MediaWeb.Migrations
{
    [DbContext(typeof(MediaContext))]
    [Migration("20190923093044_combofixes4")]
    partial class combofixes4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MediaWeb.Domain.MovieDomain.GenreMovieCombo", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<int>("MovieGenreId");

                    b.HasKey("MovieId", "MovieGenreId");

                    b.ToTable("GenreMovieCombo");
                });

            modelBuilder.Entity("MediaWeb.Domain.MovieDomain.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beschrijving");

                    b.Property<byte[]>("Foto");

                    b.Property<int>("Speelduur");

                    b.Property<string>("Titel");

                    b.Property<bool>("Zichtbaar");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MediaWeb.Domain.MovieDomain.MovieGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam");

                    b.HasKey("Id");

                    b.ToTable("MovieGenres");
                });

            modelBuilder.Entity("MediaWeb.Domain.MovieDomain.MovieGezienStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("MovieGezienStatus");
                });

            modelBuilder.Entity("MediaWeb.Domain.MovieDomain.MoviePlaylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("MoviePlaylist");
                });

            modelBuilder.Entity("MediaWeb.Domain.MovieDomain.MoviePlaylistCombo", b =>
                {
                    b.Property<int>("MoviePlaylistId");

                    b.Property<int>("MovieId");

                    b.Property<bool>("Publiek");

                    b.Property<bool>("Zichtbaar");

                    b.HasKey("MoviePlaylistId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MoviePlaylistCombo");
                });

            modelBuilder.Entity("MediaWeb.Domain.MovieDomain.MovieRatingReview", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<string>("UserId");

                    b.Property<int>("Rating");

                    b.Property<string>("Review");

                    b.Property<bool>("Zichtbaar");

                    b.HasKey("MovieId", "UserId");

                    b.ToTable("MovieRatingReview");
                });

            modelBuilder.Entity("MediaWeb.Domain.MovieDomain.MovieRegisseur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam");

                    b.HasKey("Id");

                    b.ToTable("MovieRegisseur");
                });

            modelBuilder.Entity("MediaWeb.Domain.MovieDomain.MovieRegisseurCombo", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<int>("MovieRegisseurId");

                    b.HasKey("MovieId", "MovieRegisseurId");

                    b.ToTable("MovieRegisseurCombo");
                });

            modelBuilder.Entity("MediaWeb.Domain.MovieDomain.UserMovieFav", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<string>("UserId");

                    b.HasKey("MovieId", "UserId");

                    b.ToTable("UserMovieFav");
                });

            modelBuilder.Entity("MediaWeb.Domain.MovieDomain.UserMovieGezienStatus", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<string>("UserId");

                    b.Property<int>("MovieGezienStatusId");

                    b.HasKey("MovieId", "UserId");

                    b.ToTable("UserMovieGezienStatus");
                });

            modelBuilder.Entity("MediaWeb.Domain.MusicDomain.GenreMusicCombo", b =>
                {
                    b.Property<int>("MusicId");

                    b.Property<int>("MusicGenreId");

                    b.HasKey("MusicId", "MusicGenreId");

                    b.ToTable("GenreMusicCombo");
                });

            modelBuilder.Entity("MediaWeb.Domain.MusicDomain.Music", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("CoverFoto");

                    b.Property<int>("MusicAlbumId");

                    b.Property<int>("MusicArtistId");

                    b.Property<int>("Speelduur");

                    b.Property<bool>("Zichtbaar");

                    b.HasKey("Id");

                    b.HasIndex("MusicAlbumId");

                    b.HasIndex("MusicArtistId");

                    b.ToTable("Music");
                });

            modelBuilder.Entity("MediaWeb.Domain.MusicDomain.MusicAlbum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Naam");

                    b.HasKey("Id");

                    b.ToTable("MusicAlbum");
                });

            modelBuilder.Entity("MediaWeb.Domain.MusicDomain.MusicArtist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Artist");

                    b.HasKey("Id");

                    b.ToTable("MusicArtist");
                });

            modelBuilder.Entity("MediaWeb.Domain.MusicDomain.MusicBeluisterdStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("MusicBeluisterdStatus");
                });

            modelBuilder.Entity("MediaWeb.Domain.MusicDomain.MusicGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam");

                    b.HasKey("Id");

                    b.ToTable("MusicGenre");
                });

            modelBuilder.Entity("MediaWeb.Domain.MusicDomain.MusicPlaylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("MusicPlaylist");
                });

            modelBuilder.Entity("MediaWeb.Domain.MusicDomain.MusicPlaylistCombo", b =>
                {
                    b.Property<int>("MusicPlaylistId");

                    b.Property<int>("MusicId");

                    b.Property<bool>("Publiek");

                    b.Property<bool>("Zichtbaar");

                    b.HasKey("MusicPlaylistId", "MusicId");

                    b.HasIndex("MusicId");

                    b.ToTable("MusicPlaylistCombo");
                });

            modelBuilder.Entity("MediaWeb.Domain.MusicDomain.MusicRatingReview", b =>
                {
                    b.Property<int>("MusicId");

                    b.Property<string>("UserId");

                    b.Property<int>("Rating");

                    b.Property<string>("Review");

                    b.Property<bool>("Zichtbaar");

                    b.HasKey("MusicId", "UserId");

                    b.ToTable("MusicRatingReview");
                });

            modelBuilder.Entity("MediaWeb.Domain.MusicDomain.UserMusicBesluisterdStatus", b =>
                {
                    b.Property<int>("MusicId");

                    b.Property<string>("UserId");

                    b.Property<int>("MusicBeluisterdId");

                    b.HasKey("MusicId", "UserId");

                    b.ToTable("UserMusicBesluisterdStatus");
                });

            modelBuilder.Entity("MediaWeb.Domain.MusicDomain.UserMusicFav", b =>
                {
                    b.Property<int>("MusicId");

                    b.Property<string>("UserId");

                    b.HasKey("MusicId", "UserId");

                    b.ToTable("UserMusicFav");
                });

            modelBuilder.Entity("MediaWeb.Domain.PodcastDomain.Podcast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum");

                    b.Property<int>("PodcastMakerId");

                    b.Property<int>("PodcastSerieId");

                    b.Property<int>("Speelduur");

                    b.Property<string>("Titel");

                    b.Property<bool>("Zichtbaar");

                    b.HasKey("Id");

                    b.HasIndex("PodcastMakerId");

                    b.HasIndex("PodcastSerieId");

                    b.ToTable("Podcast");
                });

            modelBuilder.Entity("MediaWeb.Domain.PodcastDomain.PodcastBelsuiterdStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("PodcastBelsuiterdStatus");
                });

            modelBuilder.Entity("MediaWeb.Domain.PodcastDomain.PodcastMaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam");

                    b.HasKey("Id");

                    b.ToTable("PodcastMaker");
                });

            modelBuilder.Entity("MediaWeb.Domain.PodcastDomain.PodcastOnderwerpCombo", b =>
                {
                    b.Property<int>("PodcastId");

                    b.Property<int>("PodcastOnderwerpId");

                    b.HasKey("PodcastId", "PodcastOnderwerpId");

                    b.ToTable("PodcastOnderwerpCombo");
                });

            modelBuilder.Entity("MediaWeb.Domain.PodcastDomain.PodcastOnderwerpen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Onderwerp");

                    b.HasKey("Id");

                    b.ToTable("PodcastOnderwerpen");
                });

            modelBuilder.Entity("MediaWeb.Domain.PodcastDomain.PodcastPlaylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Titel");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PodcastPlaylist");
                });

            modelBuilder.Entity("MediaWeb.Domain.PodcastDomain.PodcastPlaylistCombo", b =>
                {
                    b.Property<int>("PodcastPlaylistId");

                    b.Property<int>("PodcastId");

                    b.Property<bool>("Publiek");

                    b.Property<bool>("Zichtbaar");

                    b.HasKey("PodcastPlaylistId", "PodcastId");

                    b.ToTable("PodcastPlaylistCombo");
                });

            modelBuilder.Entity("MediaWeb.Domain.PodcastDomain.PodcastRatingReview", b =>
                {
                    b.Property<int>("PodcastId");

                    b.Property<string>("UserId");

                    b.Property<int>("Rating");

                    b.Property<string>("Review");

                    b.Property<bool>("Zichtbaar");

                    b.HasKey("PodcastId", "UserId");

                    b.ToTable("PodcastRatingReview");
                });

            modelBuilder.Entity("MediaWeb.Domain.PodcastDomain.PodcastSerie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Titel");

                    b.Property<bool>("Zichtbaar");

                    b.HasKey("Id");

                    b.ToTable("PodcastSerie");
                });

            modelBuilder.Entity("MediaWeb.Domain.PodcastDomain.PodcastSerieCombo", b =>
                {
                    b.Property<int>("PodcastId");

                    b.Property<int>("PodcastSerieId");

                    b.HasKey("PodcastId", "PodcastSerieId");

                    b.HasIndex("PodcastSerieId");

                    b.ToTable("PodcastSerieCombo");
                });

            modelBuilder.Entity("MediaWeb.Domain.PodcastDomain.UserPodcastBeluisterdStatus", b =>
                {
                    b.Property<int>("PodcastId");

                    b.Property<string>("UserId");

                    b.Property<int>("PodcastBeluisterdStatusId");

                    b.HasKey("PodcastId", "UserId");

                    b.ToTable("UserPodcastBelsuiterd");
                });

            modelBuilder.Entity("MediaWeb.Domain.PodcastDomain.UserPodcastFav", b =>
                {
                    b.Property<int>("PodcastId");

                    b.Property<string>("UserId");

                    b.HasKey("PodcastId", "UserId");

                    b.ToTable("UserPodcastFav");
                });

            modelBuilder.Entity("MediaWeb.Domain.SerieDomain.GenreSerieCombo", b =>
                {
                    b.Property<int>("SerieId");

                    b.Property<int>("SerieGenreId");

                    b.HasKey("SerieId", "SerieGenreId");

                    b.ToTable("GenreSerieCombo");
                });

            modelBuilder.Entity("MediaWeb.Domain.SerieDomain.Serie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beschrijving");

                    b.Property<byte[]>("Foto");

                    b.Property<string>("Titel");

                    b.Property<bool>("Zichtbaar");

                    b.HasKey("Id");

                    b.ToTable("Serie");
                });

            modelBuilder.Entity("MediaWeb.Domain.SerieDomain.SerieGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam");

                    b.HasKey("Id");

                    b.ToTable("SerieGenre");
                });

            modelBuilder.Entity("MediaWeb.Domain.SerieDomain.SerieGezienStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam");

                    b.HasKey("Id");

                    b.ToTable("SerieGezienStatus");
                });

            modelBuilder.Entity("MediaWeb.Domain.SerieDomain.SerieRatingReview", b =>
                {
                    b.Property<int>("SerieId");

                    b.Property<string>("UserId");

                    b.Property<int>("Rating");

                    b.Property<string>("Review");

                    b.HasKey("SerieId", "UserId");

                    b.ToTable("SerieRatingReview");
                });

            modelBuilder.Entity("MediaWeb.Domain.SerieDomain.SeriesEpisodeRatingReview", b =>
                {
                    b.Property<int>("SeriesEpisodesId");

                    b.Property<string>("UserId");

                    b.Property<int>("Rating");

                    b.Property<string>("Review");

                    b.Property<bool>("Zichtbaar");

                    b.HasKey("SeriesEpisodesId", "UserId");

                    b.ToTable("SeriesEpisodeRatingReview");
                });

            modelBuilder.Entity("MediaWeb.Domain.SerieDomain.SeriesEpisodes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beschijving");

                    b.Property<string>("Titel");

                    b.Property<bool>("Zichtbaar");

                    b.HasKey("Id");

                    b.ToTable("SeriesEpisodes");
                });

            modelBuilder.Entity("MediaWeb.Domain.SerieDomain.SeriesEpisodesCombo", b =>
                {
                    b.Property<int>("SerieId");

                    b.Property<int>("SeriesEpisodeId");

                    b.HasKey("SerieId", "SeriesEpisodeId");

                    b.ToTable("SeriesEpisodesCombo");
                });

            modelBuilder.Entity("MediaWeb.Domain.SerieDomain.SeriesEpisodesPlaylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Titel");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SeriesEpisodesPlaylist");
                });

            modelBuilder.Entity("MediaWeb.Domain.SerieDomain.SeriesEpisodesPlaylistCombo", b =>
                {
                    b.Property<int>("SeriesEpisodeId");

                    b.Property<int>("SeriesEpisodesPlaylistId");

                    b.Property<bool>("Publiek");

                    b.Property<bool>("Zichtbaar");

                    b.HasKey("SeriesEpisodeId", "SeriesEpisodesPlaylistId");

                    b.ToTable("SeriesEpisodesPlaylistCombo");
                });

            modelBuilder.Entity("MediaWeb.Domain.SerieDomain.UserSerieGezienStatus", b =>
                {
                    b.Property<int>("SerieGezienStatus");

                    b.Property<string>("UserId");

                    b.Property<int>("SerieId");

                    b.HasKey("SerieGezienStatus", "UserId");

                    b.ToTable("UserSerieGezienStatus");
                });

            modelBuilder.Entity("MediaWeb.Domain.SerieDomain.UserSeriesEpisodesGezienStatus", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("SeriesEpisodeId");

                    b.HasKey("UserId", "SeriesEpisodeId");

                    b.ToTable("UserSeriesEpisodesGezienStatus");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MediaWeb.Domain.MovieDomain.GenreMovieCombo", b =>
                {
                    b.HasOne("MediaWeb.Domain.MovieDomain.Movie")
                        .WithMany("Genres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MediaWeb.Domain.MovieDomain.MoviePlaylist", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MediaWeb.Domain.MovieDomain.MoviePlaylistCombo", b =>
                {
                    b.HasOne("MediaWeb.Domain.MovieDomain.Movie")
                        .WithMany("UserMoviePlaylists")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MediaWeb.Domain.MovieDomain.MovieRatingReview", b =>
                {
                    b.HasOne("MediaWeb.Domain.MovieDomain.Movie")
                        .WithMany("RatingReviews")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MediaWeb.Domain.MovieDomain.MovieRegisseurCombo", b =>
                {
                    b.HasOne("MediaWeb.Domain.MovieDomain.Movie")
                        .WithMany("Regisseurs")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MediaWeb.Domain.MovieDomain.UserMovieFav", b =>
                {
                    b.HasOne("MediaWeb.Domain.MovieDomain.Movie")
                        .WithMany("UserMovieFav")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MediaWeb.Domain.MovieDomain.UserMovieGezienStatus", b =>
                {
                    b.HasOne("MediaWeb.Domain.MovieDomain.Movie")
                        .WithMany("UserMovieGezienStatus")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MediaWeb.Domain.MusicDomain.GenreMusicCombo", b =>
                {
                    b.HasOne("MediaWeb.Domain.MusicDomain.Music")
                        .WithMany("MuziekGenres")
                        .HasForeignKey("MusicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MediaWeb.Domain.MusicDomain.Music", b =>
                {
                    b.HasOne("MediaWeb.Domain.MusicDomain.MusicAlbum", "MusicAlbum")
                        .WithMany()
                        .HasForeignKey("MusicAlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MediaWeb.Domain.MusicDomain.MusicArtist", "MusicArtist")
                        .WithMany()
                        .HasForeignKey("MusicArtistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MediaWeb.Domain.MusicDomain.MusicPlaylist", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MediaWeb.Domain.MusicDomain.MusicPlaylistCombo", b =>
                {
                    b.HasOne("MediaWeb.Domain.MusicDomain.Music")
                        .WithMany("UserMusicPlaylists")
                        .HasForeignKey("MusicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MediaWeb.Domain.MusicDomain.MusicRatingReview", b =>
                {
                    b.HasOne("MediaWeb.Domain.MusicDomain.Music")
                        .WithMany("MusicRatingReview")
                        .HasForeignKey("MusicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MediaWeb.Domain.MusicDomain.UserMusicBesluisterdStatus", b =>
                {
                    b.HasOne("MediaWeb.Domain.MusicDomain.Music")
                        .WithMany("UserMusicBeluisterdStatus")
                        .HasForeignKey("MusicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MediaWeb.Domain.MusicDomain.UserMusicFav", b =>
                {
                    b.HasOne("MediaWeb.Domain.MusicDomain.Music")
                        .WithMany("UserMusicFavs")
                        .HasForeignKey("MusicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MediaWeb.Domain.PodcastDomain.Podcast", b =>
                {
                    b.HasOne("MediaWeb.Domain.PodcastDomain.PodcastMaker", "PodcastMaker")
                        .WithMany()
                        .HasForeignKey("PodcastMakerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MediaWeb.Domain.PodcastDomain.PodcastSerie", "PostcastSerie")
                        .WithMany()
                        .HasForeignKey("PodcastSerieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MediaWeb.Domain.PodcastDomain.PodcastOnderwerpCombo", b =>
                {
                    b.HasOne("MediaWeb.Domain.PodcastDomain.Podcast")
                        .WithMany("Onderwerpen")
                        .HasForeignKey("PodcastId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MediaWeb.Domain.PodcastDomain.PodcastPlaylist", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MediaWeb.Domain.PodcastDomain.PodcastSerieCombo", b =>
                {
                    b.HasOne("MediaWeb.Domain.PodcastDomain.PodcastSerie")
                        .WithMany("Podcasts")
                        .HasForeignKey("PodcastSerieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MediaWeb.Domain.SerieDomain.GenreSerieCombo", b =>
                {
                    b.HasOne("MediaWeb.Domain.SerieDomain.Serie")
                        .WithMany("SerieGenres")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MediaWeb.Domain.SerieDomain.SerieRatingReview", b =>
                {
                    b.HasOne("MediaWeb.Domain.SerieDomain.Serie")
                        .WithMany("SerieRatingReview")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MediaWeb.Domain.SerieDomain.SeriesEpisodesCombo", b =>
                {
                    b.HasOne("MediaWeb.Domain.SerieDomain.Serie")
                        .WithMany("SeriesEpisodes")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MediaWeb.Domain.SerieDomain.SeriesEpisodesPlaylist", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
