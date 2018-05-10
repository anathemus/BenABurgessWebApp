namespace BenABurgessWebApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Financial : DbContext
    {
        public Financial()
            : base("name=Financial")
        {
        }

        public virtual DbSet<AccountTransaction> AccountTransactions { get; set; }
        public virtual DbSet<FinancialAccount> FinancialAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountTransaction>()
                .Property(e => e.Symbol)
                .IsFixedLength();

            modelBuilder.Entity<AccountTransaction>()
                .Property(e => e.Shares)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AccountTransaction>()
                .Property(e => e.PriceAtPurchase)
                .HasPrecision(19, 4);

            modelBuilder.Entity<AccountTransaction>()
                .Property(e => e.TotalAtPurchase)
                .HasPrecision(19, 4);

            modelBuilder.Entity<AccountTransaction>()
                .Property(e => e.PriceAtSale)
                .HasPrecision(19, 4);

            modelBuilder.Entity<AccountTransaction>()
                .Property(e => e.TotalAtSale)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FinancialAccount>()
                .Property(e => e.TotalAvailable)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FinancialAccount>()
                .Property(e => e.TotalFromInvestments)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FinancialAccount>()
                .Property(e => e.GrandTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FinancialAccount>()
                .HasMany(e => e.AccountTransactions)
                .WithRequired(e => e.FinancialAccount)
                .WillCascadeOnDelete(false);
        }
    }
}
