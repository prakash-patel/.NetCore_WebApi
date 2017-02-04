using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using hackMT.UserMgmt;

namespace hackMT.UserMgmt.Migrations
{
    [DbContext(typeof(TodoDbContext))]
    [Migration("20170204034352_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("hackMT.UserMgmt.TodoItem", b =>
                {
                    b.Property<int>("TodoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("DueDate");

                    b.HasKey("TodoId");

                    b.ToTable("TodoItems");
                });
        }
    }
}
