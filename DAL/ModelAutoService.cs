using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace DAL
{
    public partial class ModelAutoService : IdentityDbContext<User, IdentityRole<int>, int>
    {
        //protected readonly IConfiguration configuration;

        //public ModelAutoService(DbContextOptions<ModelAutoService> options)
        //    : base(options)
        //{
        //    this.ChangeTracker.LazyLoadingEnabled = false;
        //}
        public ModelAutoService()
        {
            //this.configuration = configuration;
        }

        public virtual DbSet<Breakdown> Breakdowns { get; set; }

        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Discount> Discounts { get; set; }

        public virtual DbSet<Mechanic> Mechanics { get; set; }

        public virtual DbSet<MechanicBreakdown> MechanicBreakdowns { get; set; }

        public virtual DbSet<Registration> Registrations { get; set; }

        public virtual DbSet<Slot> Slots { get; set; }

        public virtual DbSet<Status> Statuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Server=ThinkPad_Nikita\\SQLEXPRESS;Database=AutoServiceDb;Trusted_Connection=True;Encrypt=False;", b => b.MigrationsAssembly("DAL"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.UseTpcMappingStrategy();
                //entity.HasOne(e => e.Mechanic).WithMany().OnDelete(DeleteBehavior.NoAction);
                //entity.HasOne(e => e.Client).WithMany().OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Breakdown>(entity =>
            {
                entity.ToTable("Breakdown");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Info)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("info");
                entity.Property(e => e.Price).HasColumnName("price");
                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");
                entity.Property(e => e.Warranty).HasColumnName("warranty");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_CAR");

                entity.ToTable("Car");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("brand");
                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("color");
                entity.Property(e => e.Mileage).HasColumnName("mileage");
                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("model");
                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.HasOne(d => d.Owner).WithMany(p => p.Cars)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CAR_Client");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client"/*, e => e.Property(e=>e.Id).UseIdentityColumn(1, 2)*/);
                //entity.UseTptMappingStrategy();
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");
                entity.Property(e => e.DiscountId).HasColumnName("discount_id");
                entity.Property(e => e.DiscountPoints).HasColumnName("discount_points");
                entity.Property(e => e.Midname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("midname");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.HasOne(d => d.Discount).WithMany(p => p.Clients)
                    .HasForeignKey(d => d.DiscountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Discount");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("Discount");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
                entity.Property(e => e.Sale).HasColumnName("sale");
            });

            modelBuilder.Entity<Mechanic>(entity =>
            {
                entity.ToTable("Mechanic"/*, e => e.Property(e => e.Id).UseIdentityColumn(2, 2)*/);
                //entity.UseTptMappingStrategy();
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Midname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("midname");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("surname");
            });

            modelBuilder.Entity<MechanicBreakdown>(entity =>
            {
                entity.ToTable("Mechanic-Breakdown");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.BreakdownId).HasColumnName("breakdown_id");
                entity.Property(e => e.MechanicId).HasColumnName("mechanic_id");

                entity.HasOne(d => d.Breakdown).WithMany(p => p.MechanicBreakdowns)
                    .HasForeignKey(d => d.BreakdownId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mechanic-Breakdown_Breakdown");

                entity.HasOne(d => d.Mechanic).WithMany(p => p.MechanicBreakdowns)
                    .HasForeignKey(d => d.MechanicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mechanic-Breakdown_Mechanic");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.ToTable("Registration");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CarId).HasColumnName("car_id");
                entity.Property(e => e.Info)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("info");
                entity.Property(e => e.RegDate)
                    .HasColumnType("date")
                    .HasColumnName("reg_date");
                entity.Property(e => e.RegPrice).HasColumnName("reg_price");
                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Car).WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Registration_CAR");

                entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Registration_Status");
            });

            modelBuilder.Entity<Slot>(entity =>
            {
                entity.ToTable("Slot");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.BreakdownId).HasColumnName("breakdown_id");
                entity.Property(e => e.FinishDate)
                    .HasColumnType("date")
                    .HasColumnName("finish_date");
                entity.Property(e => e.FinishTime)
                    .HasPrecision(0)
                    .HasColumnName("finish_time");
                entity.Property(e => e.MechanicId).HasColumnName("mechanic_id");
                entity.Property(e => e.RegistrationId).HasColumnName("registration_id");
                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");
                entity.Property(e => e.StartTime)
                    .HasPrecision(0)
                    .HasColumnName("start_time");

                entity.HasOne(d => d.Breakdown).WithMany(p => p.Slots)
                    .HasForeignKey(d => d.BreakdownId)
                    .HasConstraintName("FK_Slot_Breakdown");

                entity.HasOne(d => d.Mechanic).WithMany(p => p.Slots)
                    .HasForeignKey(d => d.MechanicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Slot_Mechanic");

                entity.HasOne(d => d.Registration).WithMany(p => p.Slots)
                    .HasForeignKey(d => d.RegistrationId)
                    .HasConstraintName("FK_Slot_Registration");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
