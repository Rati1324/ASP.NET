using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Midterm.DB {
	public partial class CarRental : DbContext {
		public CarRental()
			: base("name=CarRental") {
		}

		public virtual DbSet<Car> Cars { get; set; }
		public virtual DbSet<User> Users { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Entity<Car>()
				.Property(e => e.name)
				.IsUnicode(false);

			modelBuilder.Entity<Car>()
				.Property(e => e.price)
				.HasPrecision(19, 4);

			modelBuilder.Entity<User>()
				.Property(e => e.userName)
				.IsUnicode(false);

			modelBuilder.Entity<User>()
				.Property(e => e.email)
				.IsUnicode(false);

			modelBuilder.Entity<User>()
				.Property(e => e.password)
				.IsUnicode(false);
		}
	}
}
