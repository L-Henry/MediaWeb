using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaWeb.Migrations
{
    public partial class initialz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieGezienStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGezienStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoviePlaylist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePlaylist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieRegisseurCombo",
                columns: table => new
                {
                    MovieRegisseurId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRegisseurCombo", x => new { x.MovieId, x.MovieRegisseurId });
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Speelduur = table.Column<int>(nullable: false),
                    Titel = table.Column<string>(nullable: true),
                    Beschrijving = table.Column<string>(nullable: true),
                    Foto = table.Column<byte[]>(nullable: true),
                    Zichtbaar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicAlbum",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicAlbum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicArtist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Artist = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicArtist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicBeluisterdStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicBeluisterdStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicGenre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicGenre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicPlaylist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicPlaylist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PodcastBelsuiterdStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastBelsuiterdStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PodcastMaker",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastMaker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PodcastOnderwerpen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Onderwerp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastOnderwerpen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PodcastPlaylist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastPlaylist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PodcastRatingReview",
                columns: table => new
                {
                    PodcastId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Review = table.Column<string>(nullable: true),
                    Zichtbaar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastRatingReview", x => new { x.PodcastId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "PodcastSerie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true),
                    Zichtbaar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastSerie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Serie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true),
                    Beschrijving = table.Column<string>(nullable: true),
                    Foto = table.Column<byte[]>(nullable: true),
                    Zichtbaar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SerieGezienStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerieGezienStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeriesEpisodeRatingReview",
                columns: table => new
                {
                    SeriesEpisodesId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Review = table.Column<string>(nullable: true),
                    Zichtbaar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesEpisodeRatingReview", x => new { x.SeriesEpisodesId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "SeriesEpisodesInSeries",
                columns: table => new
                {
                    SerieId = table.Column<int>(nullable: false),
                    SeriesEpisodeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesEpisodesInSeries", x => new { x.SerieId, x.SeriesEpisodeId });
                });

            migrationBuilder.CreateTable(
                name: "SeriesEpisodesPlaylist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesEpisodesPlaylist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPodcastBelsuiterd",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    PodcastId = table.Column<int>(nullable: false),
                    PodcastBeluisterdStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPodcastBelsuiterd", x => new { x.PodcastId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "UserPodcastFav",
                columns: table => new
                {
                    PodcastId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPodcastFav", x => new { x.PodcastId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "UserPodcastPlaylist",
                columns: table => new
                {
                    PodcastId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    PodcastPlaylistId = table.Column<int>(nullable: false),
                    Publiek = table.Column<bool>(nullable: false),
                    Zichtbaar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPodcastPlaylist", x => new { x.PodcastPlaylistId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "UserSerieGezienStatus",
                columns: table => new
                {
                    SerieId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    SerieGezienStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSerieGezienStatus", x => new { x.SerieGezienStatus, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "UserSeriesEpisodesGezienStatus",
                columns: table => new
                {
                    SeriesEpisodeId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSeriesEpisodesGezienStatus", x => new { x.UserId, x.SeriesEpisodeId });
                });

            migrationBuilder.CreateTable(
                name: "UserSeriesEpisodesPlaylist",
                columns: table => new
                {
                    SeriesEpisodeId = table.Column<int>(nullable: false),
                    SeriesEpisodesPlaylistId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Publiek = table.Column<bool>(nullable: false),
                    Zichtbaar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSeriesEpisodesPlaylist", x => new { x.UserId, x.SeriesEpisodesPlaylistId });
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMovieCombo",
                columns: table => new
                {
                    MovieGenreId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovieCombo", x => new { x.MovieId, x.MovieGenreId });
                    table.ForeignKey(
                        name: "FK_GenreMovieCombo_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieRatingReview",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Review = table.Column<string>(nullable: true),
                    Zichtbaar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRatingReview", x => new { x.MovieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_MovieRatingReview_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieRegisseur",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true),
                    MovieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRegisseur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieRegisseur_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMovieFav",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMovieFav", x => new { x.MovieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserMovieFav_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMovieGezienStatus",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    MovieGezienStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMovieGezienStatus", x => new { x.MovieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserMovieGezienStatus_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMoviePlaylist",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    MoviePlaylistId = table.Column<int>(nullable: false),
                    Publiek = table.Column<bool>(nullable: false),
                    Zichtbaar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMoviePlaylist", x => new { x.MoviePlaylistId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserMoviePlaylist_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Music",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Speelduur = table.Column<int>(nullable: false),
                    MusicArtistId = table.Column<int>(nullable: false),
                    CoverFoto = table.Column<byte[]>(nullable: true),
                    MusicAlbumId = table.Column<int>(nullable: false),
                    Zichtbaar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Music_MusicAlbum_MusicAlbumId",
                        column: x => x.MusicAlbumId,
                        principalTable: "MusicAlbum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Music_MusicArtist_MusicArtistId",
                        column: x => x.MusicArtistId,
                        principalTable: "MusicArtist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Podcast",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true),
                    PodcastMakerId = table.Column<int>(nullable: false),
                    Speelduur = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    PodcastSerieId = table.Column<int>(nullable: false),
                    Zichtbaar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podcast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Podcast_PodcastMaker_PodcastMakerId",
                        column: x => x.PodcastMakerId,
                        principalTable: "PodcastMaker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Podcast_PodcastSerie_PodcastSerieId",
                        column: x => x.PodcastSerieId,
                        principalTable: "PodcastSerie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreSerieGenre",
                columns: table => new
                {
                    SerieId = table.Column<int>(nullable: false),
                    SerieGenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreSerieGenre", x => new { x.SerieId, x.SerieGenreId });
                    table.ForeignKey(
                        name: "FK_GenreSerieGenre_Serie_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Serie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SerieRatingReview",
                columns: table => new
                {
                    SerieId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Review = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerieRatingReview", x => new { x.SerieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_SerieRatingReview_Serie_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Serie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesEpisodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true),
                    Beschijving = table.Column<string>(nullable: true),
                    Zichtbaar = table.Column<bool>(nullable: false),
                    SerieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesEpisodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeriesEpisodes_Serie_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Serie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GenreMusicGenre",
                columns: table => new
                {
                    MusicId = table.Column<int>(nullable: false),
                    MusicGenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMusicGenre", x => new { x.MusicId, x.MusicGenreId });
                    table.ForeignKey(
                        name: "FK_GenreMusicGenre_Music_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Music",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicRatingReview",
                columns: table => new
                {
                    MusicId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Review = table.Column<string>(nullable: true),
                    Zichtbaar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicRatingReview", x => new { x.MusicId, x.UserId });
                    table.ForeignKey(
                        name: "FK_MusicRatingReview_Music_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Music",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMusicBesluisterdStatus",
                columns: table => new
                {
                    MusicId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    MusicBeluisterdId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMusicBesluisterdStatus", x => new { x.MusicId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserMusicBesluisterdStatus_Music_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Music",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMusicFav",
                columns: table => new
                {
                    MusicId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMusicFav", x => new { x.MusicId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserMusicFav_Music_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Music",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMusicPlaylist",
                columns: table => new
                {
                    MusicId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    MusicPlaylistId = table.Column<int>(nullable: false),
                    Publiek = table.Column<bool>(nullable: false),
                    Zichtbaar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMusicPlaylist", x => new { x.MusicPlaylistId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserMusicPlaylist_Music_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Music",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PodcastOnderwerpPodcast",
                columns: table => new
                {
                    PodcastId = table.Column<int>(nullable: false),
                    PodcastOnderwerpId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastOnderwerpPodcast", x => new { x.PodcastId, x.PodcastOnderwerpId });
                    table.ForeignKey(
                        name: "FK_PodcastOnderwerpPodcast_Podcast_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "Podcast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SerieGenre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true),
                    SeriesEpisodesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerieGenre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SerieGenre_SeriesEpisodes_SeriesEpisodesId",
                        column: x => x.SeriesEpisodesId,
                        principalTable: "SeriesEpisodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRegisseur_MovieId",
                table: "MovieRegisseur",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Music_MusicAlbumId",
                table: "Music",
                column: "MusicAlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Music_MusicArtistId",
                table: "Music",
                column: "MusicArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Podcast_PodcastMakerId",
                table: "Podcast",
                column: "PodcastMakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Podcast_PodcastSerieId",
                table: "Podcast",
                column: "PodcastSerieId");

            migrationBuilder.CreateIndex(
                name: "IX_SerieGenre_SeriesEpisodesId",
                table: "SerieGenre",
                column: "SeriesEpisodesId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesEpisodes_SerieId",
                table: "SeriesEpisodes",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMoviePlaylist_MovieId",
                table: "UserMoviePlaylist",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMusicPlaylist_MusicId",
                table: "UserMusicPlaylist",
                column: "MusicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "GenreMovieCombo");

            migrationBuilder.DropTable(
                name: "GenreMusicGenre");

            migrationBuilder.DropTable(
                name: "GenreSerieGenre");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "MovieGezienStatus");

            migrationBuilder.DropTable(
                name: "MoviePlaylist");

            migrationBuilder.DropTable(
                name: "MovieRatingReview");

            migrationBuilder.DropTable(
                name: "MovieRegisseur");

            migrationBuilder.DropTable(
                name: "MovieRegisseurCombo");

            migrationBuilder.DropTable(
                name: "MusicBeluisterdStatus");

            migrationBuilder.DropTable(
                name: "MusicGenre");

            migrationBuilder.DropTable(
                name: "MusicPlaylist");

            migrationBuilder.DropTable(
                name: "MusicRatingReview");

            migrationBuilder.DropTable(
                name: "PodcastBelsuiterdStatus");

            migrationBuilder.DropTable(
                name: "PodcastOnderwerpen");

            migrationBuilder.DropTable(
                name: "PodcastOnderwerpPodcast");

            migrationBuilder.DropTable(
                name: "PodcastPlaylist");

            migrationBuilder.DropTable(
                name: "PodcastRatingReview");

            migrationBuilder.DropTable(
                name: "SerieGenre");

            migrationBuilder.DropTable(
                name: "SerieGezienStatus");

            migrationBuilder.DropTable(
                name: "SerieRatingReview");

            migrationBuilder.DropTable(
                name: "SeriesEpisodeRatingReview");

            migrationBuilder.DropTable(
                name: "SeriesEpisodesInSeries");

            migrationBuilder.DropTable(
                name: "SeriesEpisodesPlaylist");

            migrationBuilder.DropTable(
                name: "UserMovieFav");

            migrationBuilder.DropTable(
                name: "UserMovieGezienStatus");

            migrationBuilder.DropTable(
                name: "UserMoviePlaylist");

            migrationBuilder.DropTable(
                name: "UserMusicBesluisterdStatus");

            migrationBuilder.DropTable(
                name: "UserMusicFav");

            migrationBuilder.DropTable(
                name: "UserMusicPlaylist");

            migrationBuilder.DropTable(
                name: "UserPodcastBelsuiterd");

            migrationBuilder.DropTable(
                name: "UserPodcastFav");

            migrationBuilder.DropTable(
                name: "UserPodcastPlaylist");

            migrationBuilder.DropTable(
                name: "UserSerieGezienStatus");

            migrationBuilder.DropTable(
                name: "UserSeriesEpisodesGezienStatus");

            migrationBuilder.DropTable(
                name: "UserSeriesEpisodesPlaylist");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Podcast");

            migrationBuilder.DropTable(
                name: "SeriesEpisodes");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Music");

            migrationBuilder.DropTable(
                name: "PodcastMaker");

            migrationBuilder.DropTable(
                name: "PodcastSerie");

            migrationBuilder.DropTable(
                name: "Serie");

            migrationBuilder.DropTable(
                name: "MusicAlbum");

            migrationBuilder.DropTable(
                name: "MusicArtist");
        }
    }
}
