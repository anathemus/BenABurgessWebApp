namespace BenABurgessWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AccountTransaction
    {
        public Guid TransactionsAccountId { get; set; }

        [Key]
        public Guid TransactionId { get; set; }

        [Required]
        [StringLength(5)]
        public string Symbol { get; set; }

        [StringLength(50)]
        public string CompanyName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Shares { get; set; }

        [Column(TypeName = "money")]
        public decimal? PriceAtPurchase { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalAtPurchase { get; set; }

        [Column(TypeName = "money")]
        public decimal? PriceAtSale { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalAtSale { get; set; }

        public virtual FinancialAccount FinancialAccount { get; set; }
    }
}
