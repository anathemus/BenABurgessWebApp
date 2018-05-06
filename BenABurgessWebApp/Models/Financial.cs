namespace BenABurgessWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Web;


    public class Financial
    {
        [Key]
        public Guid Id { get; set; }

        [Key]
        public string UserId { get; set; }

        [Required]
        [StringLength(10)]
        public string Symbol { get; set; }

        [Column(TypeName = "text")]
        public string Name { get; set; }

        public short Shares { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "money")]
        public decimal TOTAL { get; set; }
    }
}
