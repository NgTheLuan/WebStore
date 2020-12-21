namespace WebStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCT")]
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            BILLDETAILs = new HashSet<BILLDETAIL>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? ID_Product { get; set; }

        [StringLength(85)]
        public string ProductName { get; set; }

        [StringLength(15)]
        public string Origin { get; set; }

        [StringLength(15)]
        public string Weight { get; set; }

        public double? Price { get; set; }

        public int? Quantity { get; set; }

        [StringLength(500)]
        public string Detail { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        public int? ID_ProductType { get; set; }

        public int? Sale { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLDETAIL> BILLDETAILs { get; set; }

        public virtual TYPE_PRODUCT TYPE_PRODUCT { get; set; }
    }
}
