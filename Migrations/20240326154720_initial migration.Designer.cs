﻿// <auto-generated />
using System;
using BloggingSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BloggingSite.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240326154720_initial migration")]
    partial class initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("BloggingSite.Models.AdminAction", b =>
                {
                    b.Property<int>("ActionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ActionId"));

                    b.Property<DateTime>("ActionDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ActionName")
                        .HasColumnType("longtext");

                    b.Property<string>("ActionType")
                        .HasColumnType("longtext");

                    b.Property<int>("AdminUserId")
                        .HasColumnType("int");

                    b.HasKey("ActionId");

                    b.HasIndex("AdminUserId");

                    b.ToTable("adminactions");
                });

            modelBuilder.Entity("BloggingSite.Models.AdminSignup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConfirmPassword")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("adminsignup");
                });

            modelBuilder.Entity("BloggingSite.Models.BlogPostCreateDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("PostedDate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UFileName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("BloggingSite.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .HasColumnType("longtext");

                    b.HasKey("CategoryId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("BloggingSite.Models.Comments", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<string>("CommentContent")
                        .HasColumnType("longtext");

                    b.Property<int>("PostCreateDtoId")
                        .HasColumnType("int");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("PostCreateDtoId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("BloggingSite.Models.ImageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<DateTime>("UploadedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("BloggingSite.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("login");
                });

            modelBuilder.Entity("BloggingSite.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PostId"));

                    b.Property<int>("AuthorUserId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("PostId");

                    b.HasIndex("AuthorUserId");

                    b.HasIndex("CategoryId");

                    b.ToTable("posts");
                });

            modelBuilder.Entity("BloggingSite.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TagId"));

                    b.Property<string>("TagName")
                        .HasColumnType("longtext");

                    b.HasKey("TagId");

                    b.ToTable("tags");
                });

            modelBuilder.Entity("BloggingSite.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserId"));

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("BloggingSite.Models.UserSignup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConfirmPassword")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("userSignup");
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.Property<int>("PostsPostId")
                        .HasColumnType("int");

                    b.Property<int>("TagsTagId")
                        .HasColumnType("int");

                    b.HasKey("PostsPostId", "TagsTagId");

                    b.HasIndex("TagsTagId");

                    b.ToTable("PostTag");
                });

            modelBuilder.Entity("BloggingSite.Models.AdminAction", b =>
                {
                    b.HasOne("BloggingSite.Models.User", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("BloggingSite.Models.Comments", b =>
                {
                    b.HasOne("BloggingSite.Models.BlogPostCreateDto", "PostCreateDto")
                        .WithMany()
                        .HasForeignKey("PostCreateDtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloggingSite.Models.Post", null)
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.HasOne("BloggingSite.Models.User", null)
                        .WithMany("Comments")
                        .HasForeignKey("UserId");

                    b.Navigation("PostCreateDto");
                });

            modelBuilder.Entity("BloggingSite.Models.Post", b =>
                {
                    b.HasOne("BloggingSite.Models.User", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloggingSite.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.HasOne("BloggingSite.Models.Post", null)
                        .WithMany()
                        .HasForeignKey("PostsPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloggingSite.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BloggingSite.Models.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("BloggingSite.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
