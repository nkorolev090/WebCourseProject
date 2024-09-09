using DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DAL
{
    public partial class ModelAutoService : IdentityDbContext<User>
    {
        public ModelAutoService()
        {
        }
        #region DbSets 
        public virtual DbSet<Breakdown> Breakdowns { get; set; }

        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Discount> Discounts { get; set; }

        public virtual DbSet<Mechanic> Mechanics { get; set; }

        public virtual DbSet<MechanicBreakdown> MechanicBreakdowns { get; set; }

        public virtual DbSet<Registration> Registrations { get; set; }

        public virtual DbSet<Slot> Slots { get; set; }

        public virtual DbSet<Status> Statuses { get; set; }

        public virtual DbSet<LoyaltyEvent> LoyaltyEvents { get; set; }

        public virtual DbSet<Promocode> Promocode { get; set; }

        public virtual DbSet<CartItem> CartItems { get; set; }

        public virtual DbSet<Cart> Carts { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Server=ThinkPad_Nikita\\SQLEXPRESS;Database=AutoServiceDb;Trusted_Connection=True;Encrypt=False;", b => b.MigrationsAssembly("DAL"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Promocode>(entity =>
            {
                entity.ToTable("Promocode");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Title).HasColumnName("title");
                entity.Property(e => e.DiscountValue).HasColumnName("discountValue");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("CartItem");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CartId).HasColumnName("cart_id");
                entity.Property(e => e.CartId).HasColumnName("slot_id");
                entity.HasOne(e => e.Cart).WithMany(e => e.CartItems).HasForeignKey(e => e.CartId).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_CartItem_Cart");
                entity.HasOne(e => e.Slot).WithMany(e => e.CartItems).HasForeignKey(e => e.SlotId).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_CartItem_Slot");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.PromocodeId).HasColumnName("promocode_id");
                entity.Property(e => e.ClientId).HasColumnName("client_id");
                entity.HasOne(e => e.Promocode).WithMany(e => e.Carts).HasForeignKey(e => e.PromocodeId).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Cart_Promocode");
                entity.HasOne(e => e.Client).WithOne(e => e.Cart).HasForeignKey<Cart>(e => e.ClientId).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Cart_Client");
            });

            modelBuilder.Entity<LoyaltyEvent>(entity =>
            {
                entity.ToTable("LoyaltyEvent");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.DiscountPoints).HasColumnName("discount_points");
                entity.Property(e => e.ImageURL).HasColumnName("image_url");
                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<User>(entity =>
            {
                //entity.UseTpcMappingStrategy();
                entity.HasOne(e => e.Mechanic).WithMany().HasForeignKey(e => e.MechanicId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Client).WithMany().HasForeignKey(e => e.ClientId).OnDelete(DeleteBehavior.Cascade);
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

                entity.HasOne(d => d.Discount).WithMany(p => p.Clients)
                    .HasForeignKey(d => d.DiscountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Discount");

                entity.Property(e => e.CartId).HasColumnName("cart_id");
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
                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("full_name");
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
