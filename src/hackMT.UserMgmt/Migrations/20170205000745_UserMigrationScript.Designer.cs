﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using hackMT.UserMgmt;

namespace hackMT.UserMgmt.Migrations
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20170205000745_UserMigrationScript")]
    partial class UserMigrationScript
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("hackMT.UserMgmt.model.User", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("api_token");

                    b.Property<string>("avatar_url");

                    b.Property<string>("email");

                    b.Property<string>("new_password");

                    b.Property<string>("old_password");

                    b.Property<string>("password");

                    b.Property<string>("username");

                    b.HasKey("user_id");

                    b.ToTable("User");
                });
        }
    }
}
