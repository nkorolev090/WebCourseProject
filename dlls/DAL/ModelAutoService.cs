using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using DomainModel;

namespace DAL
{
    public partial class ModelAutoService : DbContext
    {
        public ModelAutoService()
            : base("name=ModelAutoService")
        {
        }

        public virtual DbSet<Breakdown> Breakdowns { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Mechanic> Mechanics { get; set; }
        public virtual DbSet<Mechanic_Breakdown> Mechanic_Breakdown { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<Repair_Review> Repair_Review { get; set; }
        public virtual DbSet<Slot> Slots { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breakdown>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Breakdown>()
                .Property(e => e.info)
                .IsUnicode(false);

            modelBuilder.Entity<Breakdown>()
                .HasMany(e => e.Mechanic_Breakdown)
                .WithRequired(e => e.Breakdown)
                .HasForeignKey(e => e.breakdown_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Breakdown>()
                .HasMany(e => e.Slots)
                .WithOptional(e => e.Breakdown)
                .HasForeignKey(e => e.breakdown_id);

            modelBuilder.Entity<Car>()
                .Property(e => e.model)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.color)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.brand)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.Registrations)
                .WithRequired(e => e.Car)
                .HasForeignKey(e => e.car_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.name)
                .IsUnicode(false);

            //modelBuilder.Entity<Client>()
            //    .Property(e => e.discount_points)
            //    .IsFixedLength();

            modelBuilder.Entity<Client>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.midname)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Cars)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.owner_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Discount>()
                .HasMany(e => e.Clients)
                .WithRequired(e => e.Discount)
                .HasForeignKey(e => e.discount_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mechanic>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Mechanic>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<Mechanic>()
                .Property(e => e.midname)
                .IsUnicode(false);

            modelBuilder.Entity<Mechanic>()
                .HasMany(e => e.Mechanic_Breakdown)
                .WithRequired(e => e.Mechanic)
                .HasForeignKey(e => e.mechanic_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mechanic>()
                .HasMany(e => e.Slots)
                .WithRequired(e => e.Mechanic)
                .HasForeignKey(e => e.mechanic_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Registration>()
                .Property(e => e.info)
                .IsUnicode(false);

            modelBuilder.Entity<Registration>()
                .HasMany(e => e.Slots)
                .WithOptional(e => e.Registration)
                .HasForeignKey(e => e.registration_id);

            modelBuilder.Entity<Repair_Review>()
                .Property(e => e.review_message)
                .IsUnicode(false);

            modelBuilder.Entity<Repair_Review>()
                .HasMany(e => e.Registrations)
                .WithOptional(e => e.Repair_Review)
                .HasForeignKey(e => e.review_id);

            modelBuilder.Entity<Slot>()
                .Property(e => e.start_time)
                .HasPrecision(0);

            modelBuilder.Entity<Slot>()
                .Property(e => e.finish_time)
                .HasPrecision(0);

            modelBuilder.Entity<Status>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Registrations)
                .WithRequired(e => e.Status1)
                .HasForeignKey(e => e.status)
                .WillCascadeOnDelete(false);
        }
    }
}
