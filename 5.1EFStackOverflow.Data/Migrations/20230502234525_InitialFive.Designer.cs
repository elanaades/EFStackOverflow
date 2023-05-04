﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _5._1EFStackOverflow.Data;

#nullable disable

namespace _5._1EFStackOverflow.Data.Migrations
{
    [DbContext(typeof(QADBContext))]
    [Migration("20230502234525_InitialFive")]
    partial class InitialFive
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("_5._1EFStackOverflow.Data.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("_5._1EFStackOverflow.Data.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("_5._1EFStackOverflow.Data.QuestionsAndMore", b =>
                {
                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<int>("AnswerId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("QuestionId", "TagId", "AnswerId", "UserId");

                    b.HasIndex("AnswerId");

                    b.HasIndex("TagId");

                    b.HasIndex("UserId");

                    b.ToTable("QuestionsAndMore");
                });

            modelBuilder.Entity("_5._1EFStackOverflow.Data.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("_5._1EFStackOverflow.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("_5._1EFStackOverflow.Data.Answer", b =>
                {
                    b.HasOne("_5._1EFStackOverflow.Data.Question", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("_5._1EFStackOverflow.Data.QuestionsAndMore", b =>
                {
                    b.HasOne("_5._1EFStackOverflow.Data.Answer", null)
                        .WithMany("QuestionsAndMore")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("_5._1EFStackOverflow.Data.Question", "Question")
                        .WithMany("QuestionsAndMore")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("_5._1EFStackOverflow.Data.Tag", "Tag")
                        .WithMany("QuestionsAndMore")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("_5._1EFStackOverflow.Data.User", "User")
                        .WithMany("QuestionsAndMore")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Tag");

                    b.Navigation("User");
                });

            modelBuilder.Entity("_5._1EFStackOverflow.Data.Answer", b =>
                {
                    b.Navigation("QuestionsAndMore");
                });

            modelBuilder.Entity("_5._1EFStackOverflow.Data.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("QuestionsAndMore");
                });

            modelBuilder.Entity("_5._1EFStackOverflow.Data.Tag", b =>
                {
                    b.Navigation("QuestionsAndMore");
                });

            modelBuilder.Entity("_5._1EFStackOverflow.Data.User", b =>
                {
                    b.Navigation("QuestionsAndMore");
                });
#pragma warning restore 612, 618
        }
    }
}
