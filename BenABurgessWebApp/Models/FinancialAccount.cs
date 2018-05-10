namespace BenABurgessWebApp.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Security.Principal;

    [Table("FinancialAccount")]
    public partial class FinancialAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FinancialAccount()
        {
            AccountTransactions = new HashSet<AccountTransaction>();
        }

        [Key]
        public Guid TransactionsAccountId { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalAvailable { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalFromInvestments { get; set; }

        [Column(TypeName = "money")]
        public decimal GrandTotal { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountTransaction> AccountTransactions { get; set; }
    }

    // Tests for a Transactions account Guid, returns bool
    public class HasTransactionsAccount
    {
        private static ApplicationDbContext db = new ApplicationDbContext();
        public static bool HasTransactionAccount(string user)
        {
            //string currentUserName = db.Users.Find(user);
            //ApplicationUser currentUser = currentUserName;
            //string currentUserString = currentUser.ToString();
            const string nullGuid = "00000000-0000-0000-0000-000000000000";

            IQueryable<Guid> transactionAccountUserId = from q in db.FinancialAccounts
                                           where q.UserName == user
                                           select q.TransactionsAccountId;

            string userId = transactionAccountUserId.SingleOrDefault().ToString();
            // Console.WriteLine(userId);

            if (userId != nullGuid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
