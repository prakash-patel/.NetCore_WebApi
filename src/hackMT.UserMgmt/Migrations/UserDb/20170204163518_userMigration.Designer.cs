using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using hackMT.UserMgmt;

namespace hackMT.UserMgmt.Migrations.UserDb
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20170204163518_userMigration")]
    partial class userMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("hackMT.UserMgmt.model.user", b =>
                {
                    b.Property<string>("user_id");

                    b.Property<string>("avatar_url");

                    b.Property<string>("email");

                    b.Property<string>("new_password");

                    b.Property<string>("old_password");

                    b.Property<string>("password");

                    b.Property<string>("username");

                    b.HasKey("user_id");

                    b.ToTable("TodoItems");
                });
        }
    }
}
