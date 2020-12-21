namespace WebStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BILLDETAIL")]
    public partial class BILLDETAIL
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Product { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Bill { get; set; }

        public int? Quantity { get; set; }

        public double? Price { get; set; }

        public double? Total { get; set; }

        [StringLength(200)]
        public string ProductName { get; set; }

        public virtual BILL BILL { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}
