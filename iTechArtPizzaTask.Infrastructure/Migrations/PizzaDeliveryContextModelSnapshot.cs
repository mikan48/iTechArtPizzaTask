// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using iTechArtPizzaTask.Infrastructure.Context;

namespace iTechArtPizzaTask.Infrastructure.Migrations
{
    [DbContext(typeof(PizzaDeliveryContext))]
    partial class PizzaDeliveryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("iTechArtPizzaTask.Core.Models.Ingridient", b =>
                {
                    b.Property<int>("IngridientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IngridientName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IngridientId");

                    b.ToTable("Ingridients");

                    b.HasData(
                        new
                        {
                            IngridientId = 1,
                            IngridientName = "Cheese"
                        },
                        new
                        {
                            IngridientId = 2,
                            IngridientName = "Bacon"
                        },
                        new
                        {
                            IngridientId = 3,
                            IngridientName = "Sauce"
                        },
                        new
                        {
                            IngridientId = 4,
                            IngridientName = "Pepperoni"
                        },
                        new
                        {
                            IngridientId = 5,
                            IngridientName = "Pineapple"
                        });
                });

            modelBuilder.Entity("iTechArtPizzaTask.Core.Models.IngridientPizza", b =>
                {
                    b.Property<int>("IngridientId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int?>("IngridientId1")
                        .HasColumnType("int");

                    b.Property<int?>("PizzaId1")
                        .HasColumnType("int");

                    b.HasKey("IngridientId", "PizzaId");

                    b.HasIndex("IngridientId1");

                    b.HasIndex("PizzaId");

                    b.HasIndex("PizzaId1");

                    b.ToTable("IngridientPizzas");

                    b.HasData(
                        new
                        {
                            IngridientId = 1,
                            PizzaId = 1
                        },
                        new
                        {
                            IngridientId = 2,
                            PizzaId = 1
                        },
                        new
                        {
                            IngridientId = 3,
                            PizzaId = 1
                        },
                        new
                        {
                            IngridientId = 1,
                            PizzaId = 2
                        },
                        new
                        {
                            IngridientId = 3,
                            PizzaId = 2
                        },
                        new
                        {
                            IngridientId = 4,
                            PizzaId = 2
                        });
                });

            modelBuilder.Entity("iTechArtPizzaTask.Core.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("OrderCost")
                        .HasColumnType("money");

                    b.Property<int?>("PromoCodeId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("PromoCodeId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("iTechArtPizzaTask.Core.Models.OrderPizza", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId1")
                        .HasColumnType("int");

                    b.Property<int?>("PizzaId1")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "PizzaId");

                    b.HasIndex("OrderId1");

                    b.HasIndex("PizzaId");

                    b.HasIndex("PizzaId1");

                    b.ToTable("OrderPizzas");
                });

            modelBuilder.Entity("iTechArtPizzaTask.Core.Models.Pizza", b =>
                {
                    b.Property<int>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("PizzaCost")
                        .HasColumnType("money");

                    b.Property<string>("PizzaName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PizzaId");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            PizzaId = 1,
                            PizzaCost = 0m,
                            PizzaName = "Carbonara"
                        },
                        new
                        {
                            PizzaId = 2,
                            PizzaCost = 0m,
                            PizzaName = "Pepperoni"
                        });
                });

            modelBuilder.Entity("iTechArtPizzaTask.Core.Models.PromoCode", b =>
                {
                    b.Property<int>("PromoCodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.HasKey("PromoCodeId");

                    b.ToTable("PromoCodes");
                });

            modelBuilder.Entity("iTechArtPizzaTask.Core.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            UserName = "Anton"
                        },
                        new
                        {
                            UserId = 2,
                            UserName = "Kate"
                        });
                });

            modelBuilder.Entity("iTechArtPizzaTask.Core.Models.IngridientPizza", b =>
                {
                    b.HasOne("iTechArtPizzaTask.Core.Models.Ingridient", "Ingridient")
                        .WithMany()
                        .HasForeignKey("IngridientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("iTechArtPizzaTask.Core.Models.Ingridient", null)
                        .WithMany("IngridientPizzas")
                        .HasForeignKey("IngridientId1");

                    b.HasOne("iTechArtPizzaTask.Core.Models.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("iTechArtPizzaTask.Core.Models.Pizza", null)
                        .WithMany("IngridientPizzas")
                        .HasForeignKey("PizzaId1");

                    b.Navigation("Ingridient");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("iTechArtPizzaTask.Core.Models.Order", b =>
                {
                    b.HasOne("iTechArtPizzaTask.Core.Models.PromoCode", null)
                        .WithMany("Orders")
                        .HasForeignKey("PromoCodeId");

                    b.HasOne("iTechArtPizzaTask.Core.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("iTechArtPizzaTask.Core.Models.OrderPizza", b =>
                {
                    b.HasOne("iTechArtPizzaTask.Core.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("iTechArtPizzaTask.Core.Models.Order", null)
                        .WithMany("OrderPizzas")
                        .HasForeignKey("OrderId1");

                    b.HasOne("iTechArtPizzaTask.Core.Models.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("iTechArtPizzaTask.Core.Models.Pizza", null)
                        .WithMany("OrderPizzas")
                        .HasForeignKey("PizzaId1");

                    b.Navigation("Order");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("iTechArtPizzaTask.Core.Models.Ingridient", b =>
                {
                    b.Navigation("IngridientPizzas");
                });

            modelBuilder.Entity("iTechArtPizzaTask.Core.Models.Order", b =>
                {
                    b.Navigation("OrderPizzas");
                });

            modelBuilder.Entity("iTechArtPizzaTask.Core.Models.Pizza", b =>
                {
                    b.Navigation("IngridientPizzas");

                    b.Navigation("OrderPizzas");
                });

            modelBuilder.Entity("iTechArtPizzaTask.Core.Models.PromoCode", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("iTechArtPizzaTask.Core.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
