﻿// <auto-generated />
using Menu.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Menu.Migrations
{
    [DbContext(typeof(MenuDbContext))]
    partial class MenuDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Menu.Classes_Interfaces.rezMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("itemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("itemPrice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("menu");

                    b.HasDiscriminator<string>("Discriminator").HasValue("rezMenu");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Menu.Classes_Interfaces.Drinks", b =>
                {
                    b.HasBaseType("Menu.Classes_Interfaces.rezMenu");

                    b.HasDiscriminator().HasValue("Drinks");
                });

            modelBuilder.Entity("Menu.Classes_Interfaces.Food", b =>
                {
                    b.HasBaseType("Menu.Classes_Interfaces.rezMenu");

                    b.HasDiscriminator().HasValue("Food");
                });
#pragma warning restore 612, 618
        }
    }
}