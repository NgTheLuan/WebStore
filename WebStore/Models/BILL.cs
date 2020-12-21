namespace WebStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BILL")]
    public partial class BILL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BILL()
        {
            BILLDETAILs = new HashSet<BILLDETAIL>();
        }

        [Key]
        public int ID_Bill { get; set; }

        public DateTime? DateCreated { get; set; }

        [StringLength(300)]
        public string DeliveryAddress { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(200)]
        public string City { get; set; }

        [StringLength(200)]
        public string Country { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(200)]
        public string CustomerName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLDETAIL> BILLDETAILs { get; set; }
    }
}
