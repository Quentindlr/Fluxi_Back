﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using back_Fluxi.Services;

#nullable disable

namespace back_Fluxi.Migrations
{
    [DbContext(typeof(DataContextService))]
    partial class DataContextServiceModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("back_Fluxi.Models.Acteur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("acteur");
                });

            modelBuilder.Entity("back_Fluxi.Models.Categorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("categorie");
                });

            modelBuilder.Entity("back_Fluxi.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("Mdp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.ToTable("client");
                });

            modelBuilder.Entity("back_Fluxi.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("url_image");

                    b.Property<string>("UrlImageBack")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("url_image_back");

                    b.Property<string>("UrlVideo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("url_video");

                    b.Property<int>("VideoId")
                        .HasColumnType("int")
                        .HasColumnName("video_id");

                    b.HasKey("Id");

                    b.ToTable("film");
                });

            modelBuilder.Entity("back_Fluxi.Models.Serie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Episode")
                        .HasColumnType("int")
                        .HasColumnName("episode");

                    b.Property<int>("Saison")
                        .HasColumnType("int")
                        .HasColumnName("saison");

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("url_image");

                    b.Property<string>("UrlImageBack")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("url_image_back");

                    b.Property<string>("UrlVideo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("url_video");

                    b.Property<int>("VideoId")
                        .HasColumnType("int")
                        .HasColumnName("video_id");

                    b.HasKey("Id");

                    b.HasIndex("VideoId");

                    b.ToTable("serie");
                });

            modelBuilder.Entity("back_Fluxi.Models.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategorieId")
                        .HasColumnType("int")
                        .HasColumnName("categorie_id");

                    b.Property<int>("FilmId")
                        .HasColumnType("int")
                        .HasColumnName("film_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.HasIndex("FilmId")
                        .IsUnique();

                    b.ToTable("video");
                });

            modelBuilder.Entity("back_Fluxi.Models.VideoActeur", b =>
                {
                    b.Property<int>("VideoID")
                        .HasColumnType("int");

                    b.Property<int>("ActeurId")
                        .HasColumnType("int");

                    b.HasKey("VideoID", "ActeurId");

                    b.HasIndex("ActeurId");

                    b.ToTable("VideoActeur");
                });

            modelBuilder.Entity("back_Fluxi.Models.Serie", b =>
                {
                    b.HasOne("back_Fluxi.Models.Video", "Video")
                        .WithMany("Series")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Video");
                });

            modelBuilder.Entity("back_Fluxi.Models.Video", b =>
                {
                    b.HasOne("back_Fluxi.Models.Categorie", "Categorie")
                        .WithMany()
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("back_Fluxi.Models.Film", "Film")
                        .WithOne("Video")
                        .HasForeignKey("back_Fluxi.Models.Video", "FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("back_Fluxi.Models.VideoActeur", b =>
                {
                    b.HasOne("back_Fluxi.Models.Acteur", "acteur")
                        .WithMany("VideoActeurs")
                        .HasForeignKey("ActeurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("back_Fluxi.Models.Video", "Video")
                        .WithMany("VideoActeurs")
                        .HasForeignKey("VideoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Video");

                    b.Navigation("acteur");
                });

            modelBuilder.Entity("back_Fluxi.Models.Acteur", b =>
                {
                    b.Navigation("VideoActeurs");
                });

            modelBuilder.Entity("back_Fluxi.Models.Film", b =>
                {
                    b.Navigation("Video")
                        .IsRequired();
                });

            modelBuilder.Entity("back_Fluxi.Models.Video", b =>
                {
                    b.Navigation("Series");

                    b.Navigation("VideoActeurs");
                });
#pragma warning restore 612, 618
        }
    }
}
