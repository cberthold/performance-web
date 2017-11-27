using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Performance.Models.Security
{
    public partial class SecurityContext : DbContext
    {
        public virtual DbSet<AdminUserPolicy> AdminUserPolicy { get; set; }
        public virtual DbSet<Features> Features { get; set; }
        public virtual DbSet<FeatureTypePolicy> FeatureTypePolicy { get; set; }
        public virtual DbSet<FeatureTypes> FeatureTypes { get; set; }
        public virtual DbSet<Policy> Policy { get; set; }
        public virtual DbSet<PolicyFeaturePermissions> PolicyFeaturePermissions { get; set; }
        public virtual DbSet<ResourceActions> ResourceActions { get; set; }
        public virtual DbSet<ResourceActionToFeatureMap> ResourceActionToFeatureMap { get; set; }
        public virtual DbSet<Tenants> Tenants { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserTenantPolicy> UserTenantPolicy { get; set; }
        public virtual DbSet<UserPermissions> UserPermissions { get; set; }


        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=WideWorldImporters;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminUserPolicy>(entity =>
            {
                entity.HasKey(e => e.PolicyId);

                entity.ToTable("AdminUserPolicy", "Security");

                entity.Property(e => e.PolicyId).ValueGeneratedNever();

                entity.HasOne(d => d.Policy)
                    .WithOne(p => p.AdminUserPolicy)
                    .HasForeignKey<AdminUserPolicy>(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminUserPolicy_Policy");
            });

            modelBuilder.Entity<Features>(entity =>
            {
                entity.ToTable("Features", "Security");

                entity.Property(e => e.Created).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((0))");

                entity.Property(e => e.Enabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.LegacyTextId).HasMaxLength(255);

                entity.Property(e => e.LookupId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.FeatureType)
                    .WithMany(p => p.Features)
                    .HasForeignKey(d => d.FeatureTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Features_FeatureTypes");
            });

            modelBuilder.Entity<FeatureTypePolicy>(entity =>
            {
                entity.HasKey(e => new { e.PolicyId, e.FeatureTypeId });

                entity.ToTable("FeatureTypePolicy", "Security");

                entity.HasOne(d => d.FeatureType)
                    .WithMany(p => p.FeatureTypePolicy)
                    .HasForeignKey(d => d.FeatureTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FeatureTypePolicy_FeatureTypes");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.FeatureTypePolicy)
                    .HasForeignKey(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FeatureTypePolicy_Policy");
            });

            modelBuilder.Entity<FeatureTypes>(entity =>
            {
                entity.ToTable("FeatureTypes", "Security");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.ToTable("Policy", "Security");

                entity.Property(e => e.Created).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((0))");

                entity.Property(e => e.LookupId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.ParentPolicy)
                    .WithMany(p => p.InverseParentPolicy)
                    .HasForeignKey(d => d.ParentPolicyId)
                    .HasConstraintName("FK_Policy_PolicyParent");
            });

            modelBuilder.Entity<PolicyFeaturePermissions>(entity =>
            {
                entity.ToTable("PolicyFeaturePermissions", "Security");

                entity.Property(e => e.LookupId).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.PolicyFeaturePermissions)
                    .HasForeignKey(d => d.FeatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PolicyFeaturePermissions_Features");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.PolicyFeaturePermissions)
                    .HasForeignKey(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PolicyFeaturePermissions_Policy");
            });

            modelBuilder.Entity<ResourceActions>(entity =>
            {
                entity.ToTable("ResourceActions", "Security");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((0))");

                entity.Property(e => e.Resource)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(1000);
            });

            modelBuilder.Entity<ResourceActionToFeatureMap>(entity =>
            {
                entity.HasKey(e => new { e.ResourceActionId, e.FeatureId });

                entity.ToTable("ResourceActionToFeatureMap", "Security");

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.ResourceActionToFeatureMap)
                    .HasForeignKey(d => d.FeatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceActionToFeatureMap_Features");
            });

            modelBuilder.Entity<Tenants>(entity =>
            {
                entity.ToTable("Tenants", "Security");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "Security");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(254)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserTenantPolicy>(entity =>
            {
                entity.HasKey(e => e.PolicyId);

                entity.ToTable("UserTenantPolicy", "Security");

                entity.Property(e => e.PolicyId).ValueGeneratedNever();

                entity.HasOne(d => d.Policy)
                    .WithOne(p => p.UserTenantPolicy)
                    .HasForeignKey<UserTenantPolicy>(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserClientPolicy_Policy");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTenantPolicy)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTenantPolicy_User");
            });


            modelBuilder.Entity<UserPermissions>(entity =>
            {
                entity.HasKey(e => new { e.PolicyId, e.TenantId, e.UserId });
                entity.ToTable("UserPermissionsView", "Security");
            });

            modelBuilder.HasSequence<int>("BuyingGroupID").StartsAt(3);

            modelBuilder.HasSequence<int>("CityID").StartsAt(38187);

            modelBuilder.HasSequence<int>("ColorID").StartsAt(37);

            modelBuilder.HasSequence<int>("CountryID").StartsAt(242);

            modelBuilder.HasSequence<int>("CustomerCategoryID").StartsAt(9);

            modelBuilder.HasSequence<int>("CustomerID").StartsAt(1062);

            modelBuilder.HasSequence<int>("DeliveryMethodID").StartsAt(11);

            modelBuilder.HasSequence<int>("InvoiceID").StartsAt(70511);

            modelBuilder.HasSequence<int>("InvoiceLineID").StartsAt(228266);

            modelBuilder.HasSequence<int>("OrderID").StartsAt(73596);

            modelBuilder.HasSequence<int>("OrderLineID").StartsAt(231413);

            modelBuilder.HasSequence<int>("PackageTypeID").StartsAt(15);

            modelBuilder.HasSequence<int>("PaymentMethodID").StartsAt(5);

            modelBuilder.HasSequence<int>("PersonID").StartsAt(3262);

            modelBuilder.HasSequence<int>("PurchaseOrderID").StartsAt(2075);

            modelBuilder.HasSequence<int>("PurchaseOrderLineID").StartsAt(8368);

            modelBuilder.HasSequence<int>("SpecialDealID").StartsAt(3);

            modelBuilder.HasSequence<int>("StateProvinceID").StartsAt(54);

            modelBuilder.HasSequence<int>("StockGroupID").StartsAt(11);

            modelBuilder.HasSequence<int>("StockItemID").StartsAt(228);

            modelBuilder.HasSequence<int>("StockItemStockGroupID").StartsAt(443);

            modelBuilder.HasSequence<int>("SupplierCategoryID").StartsAt(10);

            modelBuilder.HasSequence<int>("SupplierID").StartsAt(14);

            modelBuilder.HasSequence<int>("SystemParameterID").StartsAt(2);

            modelBuilder.HasSequence<int>("TransactionID").StartsAt(336253);

            modelBuilder.HasSequence<int>("TransactionTypeID").StartsAt(14);
        }
    }
}
