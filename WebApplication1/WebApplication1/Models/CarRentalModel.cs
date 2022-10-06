using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication1.DB {
	public partial class CarRentalModel : DbContext {
		public CarRentalModel()
			: base("name=CarRental") {
		}

		public virtual DbSet<Car> Cars { get; set; }
		public virtual DbSet<CarBodyType> CarBodyTypes { get; set; }
		public virtual DbSet<FuelType> FuelTypes { get; set; }
		public virtual DbSet<TransmissionType> TransmissionTypes { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Entity<Car>()
				.Property(e => e.name)
				.IsUnicode(false);

			modelBuilder.Entity<Car>()
				.Property(e => e.price)
				.HasPrecision(19, 4);

			modelBuilder.Entity<Car>()
				.Property(e => e.licenseNumber)
				.IsUnicode(false);

			modelBuilder.Entity<CarBodyType>()
				.HasMany(e => e.Cars)
				.WithOptional(e => e.CarBodyType)
				.HasForeignKey(e => e.bodyType);

			modelBuilder.Entity<FuelType>()
				.Property(e => e.name)
				.IsUnicode(false);

			modelBuilder.Entity<FuelType>()
				.HasMany(e => e.Cars)
				.WithOptional(e => e.FuelType1)
				.HasForeignKey(e => e.fuelType);

			modelBuilder.Entity<TransmissionType>()
				.Property(e => e.name)
				.IsUnicode(false);

			modelBuilder.Entity<TransmissionType>()
				.HasMany(e => e.Cars)
				.WithOptional(e => e.TransmissionType1)
				.HasForeignKey(e => e.transmissionType);
		}
	}
}
