using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GymOrganizer.Data.Db;

namespace GymOrganizer.Data.Migrations
{
    [DbContext(typeof(GymOrganizerContext))]
    partial class GymOrganizerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GymOrganizer.Data.Model.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("GymOrganizer.Data.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Address");

                    b.Property<int?>("Age");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GymOrganizer.Data.Model.Schedule", b =>
                {
                    b.HasOne("GymOrganizer.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
