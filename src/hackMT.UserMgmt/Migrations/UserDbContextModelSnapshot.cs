using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using hackMT.UserMgmt;

namespace hackMT.UserMgmt.Migrations
{
    [DbContext(typeof(UserDbContext))]
    partial class UserDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("hackMT.UserMgmt.model.User", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("api_token");

                    b.Property<string>("avatar_url");

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("new_password");

                    b.Property<string>("old_password");

                    b.Property<string>("password")
                        .IsRequired();

                    b.Property<string>("username")
                        .IsRequired();

                    b.HasKey("user_id");

                    b.ToTable("User");
                });
        }
    }
}
