namespace WebStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USER")]
    public partial class USER
    {
        [StringLength(50)]
        public string FName { get; set; }

        [StringLength(50)]
        public string LName { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(300)]
        public string Address { get; set; }

        [Key]
        [StringLength(80)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Password { get; set; }
    }
}
