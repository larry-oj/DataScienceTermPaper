using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Etl.Data
{
    public partial class termpaperContext : DbContext
    {
        public termpaperContext()
        {
        }

        public termpaperContext(DbContextOptions<termpaperContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActorCombo> ActorCombos { get; set; }
        public virtual DbSet<ActorGroupDim> ActorGroupDims { get; set; }
        public virtual DbSet<CategoryDim> CategoryDims { get; set; }
        public virtual DbSet<Fact> Facts { get; set; }
        public virtual DbSet<FilmDim> FilmDims { get; set; }
        public virtual DbSet<GenreCombo> GenreCombos { get; set; }
        public virtual DbSet<GenreDim> GenreDims { get; set; }
        public virtual DbSet<GenreGroupDim> GenreGroupDims { get; set; }
        public virtual DbSet<ImdbTop1000> ImdbTop1000s { get; set; }
        public virtual DbSet<ImdbTop250> ImdbTop250s { get; set; }
        public virtual DbSet<MoviesImdb> MoviesImdbs { get; set; }
        public virtual DbSet<OsacarDim> OsacarDims { get; set; }
        public virtual DbSet<OscarCombo> OscarCombos { get; set; }
        public virtual DbSet<OscarGroupDim> OscarGroupDims { get; set; }
        public virtual DbSet<PersonDim> PersonDims { get; set; }
        public virtual DbSet<TheOscarAward> TheOscarAwards { get; set; }
        public virtual DbSet<TimeDim> TimeDims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=109.86.65.216;database=termpaper;uid=root;pwd=rootuserpass;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorCombo>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.ToTable("actor_combo");

                entity.HasIndex(e => e.ActorGroupId, "FK_118");

                entity.HasIndex(e => e.PersonId, "FK_137");

                entity.Property(e => e.ActorGroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("actor_group_id");

                entity.Property(e => e.PersonId)
                    .HasColumnType("int(11)")
                    .HasColumnName("person_id");

                entity.HasOne(d => d.ActorGroup)
                    .WithMany()
                    .HasForeignKey(d => d.ActorGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_116");

                entity.HasOne(d => d.Person)
                    .WithMany()
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_135");
            });

            modelBuilder.Entity<ActorGroupDim>(entity =>
            {
                entity.ToTable("actor_group_dim");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<CategoryDim>(entity =>
            {
                entity.ToTable("category_dim");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Fact>(entity =>
            {
                entity.ToTable("facts");

                entity.HasIndex(e => e.GenreGroupId, "FK_108");

                entity.HasIndex(e => e.FilmId, "FK_111");

                entity.HasIndex(e => e.ActorGroupId, "FK_124");

                entity.HasIndex(e => e.DirectorId, "FK_127");

                entity.HasIndex(e => e.TimeDim, "FK_134");

                entity.HasIndex(e => e.OscarGroupId, "FK_177");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ActorGroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("actor_group_id");

                entity.Property(e => e.DirectorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("director_id");

                entity.Property(e => e.FilmId)
                    .HasColumnType("int(11)")
                    .HasColumnName("film_id");

                entity.Property(e => e.GenreGroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("genre_group_id");

                entity.Property(e => e.Gross)
                    .HasColumnType("int(11)")
                    .HasColumnName("gross");

                entity.Property(e => e.OscarGroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("oscar_group_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Runtime)
                    .HasColumnType("int(11)")
                    .HasColumnName("runtime");

                entity.Property(e => e.Score)
                    .HasColumnType("int(11)")
                    .HasColumnName("score");

                entity.Property(e => e.TimeDim)
                    .HasColumnType("int(11)")
                    .HasColumnName("time_dim");

                entity.Property(e => e.Votes)
                    .HasColumnType("int(11)")
                    .HasColumnName("votes");

                entity.HasOne(d => d.ActorGroup)
                    .WithMany(p => p.Facts)
                    .HasForeignKey(d => d.ActorGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_122");

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Facts)
                    .HasForeignKey(d => d.DirectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_125");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.Facts)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_109");

                entity.HasOne(d => d.GenreGroup)
                    .WithMany(p => p.Facts)
                    .HasForeignKey(d => d.GenreGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_106");

                entity.HasOne(d => d.OscarGroup)
                    .WithMany(p => p.Facts)
                    .HasForeignKey(d => d.OscarGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_175");

                entity.HasOne(d => d.TimeDimNavigation)
                    .WithMany(p => p.Facts)
                    .HasForeignKey(d => d.TimeDim)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_132");
            });

            modelBuilder.Entity<FilmDim>(entity =>
            {
                entity.ToTable("film_dim");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(82)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<GenreCombo>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.ToTable("genre_combo");

                entity.HasIndex(e => e.GenreId, "FK_105");

                entity.HasIndex(e => e.GenreGroupId, "FK_98");

                entity.Property(e => e.GenreGroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("genre_group_id");

                entity.Property(e => e.GenreId)
                    .HasColumnType("int(11)")
                    .HasColumnName("genre_id");

                entity.HasOne(d => d.GenreGroup)
                    .WithMany()
                    .HasForeignKey(d => d.GenreGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_96");

                entity.HasOne(d => d.Genre)
                    .WithMany()
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_103");
            });

            modelBuilder.Entity<GenreDim>(entity =>
            {
                entity.ToTable("genre_dim");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<GenreGroupDim>(entity =>
            {
                entity.ToTable("genre_group_dim");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<ImdbTop1000>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("imdb_top_1000");

                entity.Property(e => e.Certificate).HasMaxLength(8);

                entity.Property(e => e.Director)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasMaxLength(29);

                entity.Property(e => e.Gross).HasMaxLength(11);

                entity.Property(e => e.ImdbRating)
                    .HasPrecision(3, 1)
                    .HasColumnName("IMDB_Rating");

                entity.Property(e => e.MetaScore)
                    .HasColumnType("int(11)")
                    .HasColumnName("Meta_score");

                entity.Property(e => e.NoOfVotes)
                    .HasColumnType("int(11)")
                    .HasColumnName("No_of_Votes");

                entity.Property(e => e.Overview)
                    .IsRequired()
                    .HasMaxLength(313);

                entity.Property(e => e.PosterLink)
                    .IsRequired()
                    .HasMaxLength(161)
                    .HasColumnName("Poster_Link");

                entity.Property(e => e.ReleasedYear)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("Released_Year");

                entity.Property(e => e.Runtime)
                    .IsRequired()
                    .HasMaxLength(7);

                entity.Property(e => e.SeriesTitle)
                    .IsRequired()
                    .HasMaxLength(68)
                    .HasColumnName("Series_Title");

                entity.Property(e => e.Star1)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Star2)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Star3)
                    .IsRequired()
                    .HasMaxLength(27);

                entity.Property(e => e.Star4)
                    .IsRequired()
                    .HasMaxLength(27);
            });

            modelBuilder.Entity<ImdbTop250>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("imdb_top_250");

                entity.Property(e => e.Cast1)
                    .IsRequired()
                    .HasMaxLength(26);

                entity.Property(e => e.Cast2)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Cast3).HasMaxLength(29);

                entity.Property(e => e.Cast4).HasMaxLength(29);

                entity.Property(e => e.Date).HasColumnType("int(11)");

                entity.Property(e => e.Director)
                    .IsRequired()
                    .HasMaxLength(187);

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasMaxLength(28);

                entity.Property(e => e.Gross).HasPrecision(6, 2);

                entity.Property(e => e.Imdblink)
                    .IsRequired()
                    .HasMaxLength(18)
                    .HasColumnName("IMDBlink");

                entity.Property(e => e.Imdbyear)
                    .HasColumnType("int(11)")
                    .HasColumnName("IMDByear");

                entity.Property(e => e.Rating).HasPrecision(3, 1);

                entity.Property(e => e.RatingId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Rating_Id");

                entity.Property(e => e.RunTime).HasColumnType("int(11)");

                entity.Property(e => e.Score).HasPrecision(5, 1);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(68);

                entity.Property(e => e.Votes).HasColumnType("int(11)");
            });

            modelBuilder.Entity<MoviesImdb>(entity =>
            {
                entity.ToTable("movies_IMDB");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasMaxLength(41)
                    .HasColumnName("genre");

                entity.Property(e => e.Imdb)
                    .HasPrecision(3, 1)
                    .HasColumnName("imdb");

                entity.Property(e => e.Metascore)
                    .IsRequired()
                    .HasMaxLength(17)
                    .HasColumnName("metascore");

                entity.Property(e => e.MovieName)
                    .IsRequired()
                    .HasMaxLength(54)
                    .HasColumnName("movie_name");

                entity.Property(e => e.TimeMin)
                    .HasColumnType("int(11)")
                    .HasColumnName("timeMin");

                entity.Property(e => e.UsGrossMillions)
                    .IsRequired()
                    .HasMaxLength(17)
                    .HasColumnName("us_grossMillions");

                entity.Property(e => e.Votes)
                    .HasColumnType("int(11)")
                    .HasColumnName("votes");

                entity.Property(e => e.Year)
                    .HasColumnType("int(11)")
                    .HasColumnName("year");
            });

            modelBuilder.Entity<OsacarDim>(entity =>
            {
                entity.ToTable("osacar_dim");

                entity.HasIndex(e => e.CategoryId, "FK_162");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("category_id");

                entity.Property(e => e.Winner).HasColumnName("winner");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.OsacarDims)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_160");
            });

            modelBuilder.Entity<OscarCombo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("oscar_combo");

                entity.HasIndex(e => e.OsacrGroupId, "FK_171");

                entity.HasIndex(e => e.OscarDimId, "FK_174");

                entity.Property(e => e.OsacrGroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("osacr_group_id");

                entity.Property(e => e.OscarDimId)
                    .HasColumnType("int(11)")
                    .HasColumnName("oscar_dim_id");

                entity.HasOne(d => d.OsacrGroup)
                    .WithMany()
                    .HasForeignKey(d => d.OsacrGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_169");

                entity.HasOne(d => d.OscarDim)
                    .WithMany()
                    .HasForeignKey(d => d.OscarDimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_172");
            });

            modelBuilder.Entity<OscarGroupDim>(entity =>
            {
                entity.ToTable("oscar_group_dim");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<PersonDim>(entity =>
            {
                entity.ToTable("person_dim");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TheOscarAward>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("the_oscar_award");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(137)
                    .HasColumnName("category");

                entity.Property(e => e.Ceremony)
                    .HasColumnType("int(11)")
                    .HasColumnName("ceremony");

                entity.Property(e => e.Film)
                    .HasMaxLength(82)
                    .HasColumnName("film");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(280)
                    .HasColumnName("name");

                entity.Property(e => e.Winner)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("winner");

                entity.Property(e => e.YearCeremony)
                    .HasColumnType("int(11)")
                    .HasColumnName("year_ceremony");

                entity.Property(e => e.YearFilm)
                    .HasColumnType("int(11)")
                    .HasColumnName("year_film");
            });

            modelBuilder.Entity<TimeDim>(entity =>
            {
                entity.ToTable("time_dim");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Year)
                    .HasColumnType("int(11)")
                    .HasColumnName("year");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
