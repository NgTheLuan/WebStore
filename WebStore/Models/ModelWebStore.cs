namespace WebStore.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelWebStore : DbContext
    {
        public ModelWebStore()
            : base("name=WebStoreGearHost")
        {
        }

        public virtual DbSet<BILL> BILLs { get; set; }
        public virtual DbSet<BILLDETAIL> BILLDETAILs { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTs { get; set; }
        public virtual DbSet<TYPE_PRODUCT> TYPE_PRODUCT { get; set; }
        public virtual DbSet<USER> USERs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BILL>()
                .HasMany(e => e.BILLDETAILs)
                .WithRequired(e => e.BILL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCT>()
                .HasMany(e => e.BILLDETAILs)
                .WithRequired(e => e.PRODUCT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TYPE_PRODUCT>()
                .Property(e => e.Unit)
                .IsFixedLength();
        }
    }
}
