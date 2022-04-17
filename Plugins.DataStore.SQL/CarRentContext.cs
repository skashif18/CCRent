﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CoreBusiness.Base;
using CoreBusiness.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Plugins.DataStore.SQL.Infrastructure.Services;

namespace Plugins.DataStore.SQL
{
    public partial class CarRentContext : DbContext
    {

        private readonly ICurrentUserService currentUser;
       

        public CarRentContext(DbContextOptions<CarRentContext> options, ICurrentUserService currentUser)
            : base(options)
        {
            this.currentUser = currentUser;
        }

        public virtual DbSet<SrvAddOn> SrvAddOns { get; set; }
        public virtual DbSet<SrvCategory> SrvCategories { get; set; }
        public virtual DbSet<SrvClass> SrvClasses { get; set; }
        public virtual DbSet<SrvClassValue> SrvClassValues { get; set; }
        public virtual DbSet<SrvCustomer> SrvCustomers { get; set; }
        public virtual DbSet<SrvDocument> SrvDocuments { get; set; }
        public virtual DbSet<SrvFileType> SrvFileTypes { get; set; }
        public virtual DbSet<SrvImage> SrvImages { get; set; }
        public virtual DbSet<SrvService> SrvServices { get; set; }
        public virtual DbSet<SrvServiceAddOn> SrvServiceAddOns { get; set; }
        public virtual DbSet<SrvServiceClass> SrvServiceClasses { get; set; }
        public virtual DbSet<SrvServiceClassValue> SrvServiceClassValues { get; set; }
        public virtual DbSet<SrvServiceType> SrvServiceTypes { get; set; }
        public virtual DbSet<SrvSupplier> SrvSuppliers { get; set; }
        public virtual DbSet<SysCity> SysCities { get; set; }
        public virtual DbSet<SysCountry> SysCountries { get; set; }
        public virtual DbSet<SysGender> SysGenders { get; set; }
        public virtual DbSet<SysLanguage> SysLanguages { get; set; }
        public virtual DbSet<SysNationality> SysNationalities { get; set; }
        public virtual DbSet<SysReligion> SysReligions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SrvAddOn>(entity =>
            {
                entity.ToTable("SrvAddOn");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.CreationUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserName).HasMaxLength(50);

                entity.Property(e => e.NameEn).IsRequired();

                entity.HasOne(d => d.Icon)
                    .WithMany(p => p.SrvAddOns)
                    .HasForeignKey(d => d.IconId)
                    .HasConstraintName("FK_SrvAddOn_SrvImage");
            });

            modelBuilder.Entity<SrvCategory>(entity =>
            {
                entity.ToTable("SrvCategory");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.CreationUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserName).HasMaxLength(50);

                entity.Property(e => e.NameEn).IsRequired();

                entity.HasOne(d => d.ParentCategory)
                    .WithMany(p => p.InverseParentCategory)
                    .HasForeignKey(d => d.ParentCategoryId)
                    .HasConstraintName("FK_SrvCategory_SrvCategory");
            });

            modelBuilder.Entity<SrvClass>(entity =>
            {
                entity.ToTable("SrvClass");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.CreationUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserName).HasMaxLength(50);

                entity.Property(e => e.NameEn).IsRequired();
            });

            modelBuilder.Entity<SrvClassValue>(entity =>
            {
                entity.ToTable("SrvClassValue");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.CreationUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserName).HasMaxLength(50);

                entity.Property(e => e.NameEn).IsRequired();

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.SrvClassValues)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_SrvClassValue_SrvClass");
            });

            modelBuilder.Entity<SrvCustomer>(entity =>
            {
                entity.ToTable("SrvCustomer");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.CreationUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserName).HasMaxLength(50);

                entity.Property(e => e.NameEn).IsRequired();

                entity.HasOne(d => d.City)
                    .WithMany(p => p.SrvCustomers)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_SrvCustomer_SysCity");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.SrvCustomers)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_SrvCustomer_SysGender");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.SrvCustomers)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_SrvCustomer_SysLanguage");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.SrvCustomers)
                    .HasForeignKey(d => d.NationalityId)
                    .HasConstraintName("FK_SrvCustomer_SysNationality");

                entity.HasOne(d => d.Religion)
                    .WithMany(p => p.SrvCustomers)
                    .HasForeignKey(d => d.ReligionId)
                    .HasConstraintName("FK_SrvCustomer_SysReligion");
            });

            modelBuilder.Entity<SrvDocument>(entity =>
            {
                entity.ToTable("SrvDocument");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.CreationUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FileUrlpath)
                    .IsRequired()
                    .HasColumnName("FileURLPath");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserName).HasMaxLength(50);

                entity.Property(e => e.ServerLocalPath).IsRequired();

                entity.Property(e => e.TableName).IsRequired();

                entity.HasOne(d => d.FileTypeNavigation)
                    .WithMany(p => p.SrvDocuments)
                    .HasForeignKey(d => d.FileType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SrvDocument_SrvFileType");
            });

            modelBuilder.Entity<SrvFileType>(entity =>
            {
                entity.ToTable("SrvFileType");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.CreationUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserName).HasMaxLength(50);

                entity.Property(e => e.NameEn).IsRequired();
            });

            modelBuilder.Entity<SrvImage>(entity =>
            {
                entity.ToTable("SrvImage");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.CreationUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FileUrlpath)
                    .IsRequired()
                    .HasColumnName("FileURLPath");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserName).HasMaxLength(50);

                entity.Property(e => e.ServerLocalPath).IsRequired();

                entity.HasOne(d => d.FileTypeNavigation)
                    .WithMany(p => p.SrvImages)
                    .HasForeignKey(d => d.FileType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SrvImage_SrvFileType");
            });

            modelBuilder.Entity<SrvService>(entity =>
            {
                entity.ToTable("SrvService");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.CreationUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserName).HasMaxLength(50);

                entity.Property(e => e.NameEn).IsRequired();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SrvServices)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SrvService_SrvCategory");

                entity.HasOne(d => d.ServiceType)
                    .WithMany(p => p.SrvServices)
                    .HasForeignKey(d => d.ServiceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SrvService_SrvServiceType");
            });

            modelBuilder.Entity<SrvServiceAddOn>(entity =>
            {
                entity.ToTable("SrvServiceAddOn");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.CreationUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserName).HasMaxLength(50);

                entity.HasOne(d => d.AddOn)
                    .WithMany(p => p.SrvServiceAddOns)
                    .HasForeignKey(d => d.AddOnId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SrvServiceAddOn_SrvAddOn");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.SrvServiceAddOns)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("FK_SrvServiceAddOn_SrvImage");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.SrvServiceAddOns)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SrvServiceAddOn_SrvService");
            });

            modelBuilder.Entity<SrvServiceClass>(entity =>
            {
                entity.ToTable("SrvServiceClass");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.CreationUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserName).HasMaxLength(50);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.SrvServiceClasses)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SrvServiceClass_SrvClass");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.SrvServiceClasses)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SrvServiceClass_SrvService");
            });

            modelBuilder.Entity<SrvServiceClassValue>(entity =>
            {
                entity.ToTable("SrvServiceClassValue");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.CreationUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserName).HasMaxLength(50);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.SrvServiceClassValues)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SrvServiceClassValue_SrvClass");

                entity.HasOne(d => d.ClassValue)
                    .WithMany(p => p.SrvServiceClassValues)
                    .HasForeignKey(d => d.ClassValueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SrvServiceClassValue_SrvClassValue");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.SrvServiceClassValues)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SrvServiceClassValue_SrvService");
            });

            modelBuilder.Entity<SrvServiceType>(entity =>
            {
                entity.ToTable("SrvServiceType");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.CreationUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserName).HasMaxLength(50);

                entity.Property(e => e.NameEn).IsRequired();

                entity.HasOne(d => d.ServiceType)
                    .WithMany(p => p.InverseServiceType)
                    .HasForeignKey(d => d.ServiceTypeId)
                    .HasConstraintName("FK_SrvServiceType_SrvServiceType");
            });

            modelBuilder.Entity<SrvSupplier>(entity =>
            {
                entity.ToTable("SrvSupplier");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.CreationUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserName).HasMaxLength(50);

                entity.Property(e => e.NameEn).IsRequired();

                entity.HasOne(d => d.City)
                    .WithMany(p => p.SrvSuppliers)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_SrvSupplier_SysCity");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.SrvSuppliers)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_SrvSupplier_SysGender");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.SrvSuppliers)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_SrvSupplier_SysLanguage");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.SrvSuppliers)
                    .HasForeignKey(d => d.NationalityId)
                    .HasConstraintName("FK_SrvSupplier_SysNationality");

                entity.HasOne(d => d.Religion)
                    .WithMany(p => p.SrvSuppliers)
                    .HasForeignKey(d => d.ReligionId)
                    .HasConstraintName("FK_SrvSupplier_SysReligion");
            });

            modelBuilder.Entity<SysCity>(entity =>
            {
                entity.ToTable("SysCity");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.CreationUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserName).HasMaxLength(50);

                entity.Property(e => e.NameEn).IsRequired();

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.SysCities)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_SysCity_SysCountry");
            });

            modelBuilder.Entity<SysCountry>(entity =>
            {
                entity.ToTable("SysCountry");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.CreationUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserName).HasMaxLength(50);

                entity.Property(e => e.NameEn).IsRequired();
            });

            modelBuilder.Entity<SysGender>(entity =>
            {
                entity.ToTable("SysGender");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.CreationUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserName).HasMaxLength(50);

                entity.Property(e => e.NameEn).IsRequired();
            });

            modelBuilder.Entity<SysLanguage>(entity =>
            {
                entity.ToTable("SysLanguage");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.CreationUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserName).HasMaxLength(50);

                entity.Property(e => e.NameEn).IsRequired();
            });

            modelBuilder.Entity<SysNationality>(entity =>
            {
                entity.ToTable("SysNationality");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.CreationUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserName).HasMaxLength(50);

                entity.Property(e => e.NameEn).IsRequired();
            });

            modelBuilder.Entity<SysReligion>(entity =>
            {
                entity.ToTable("SysReligion");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.CreationUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateUserName).HasMaxLength(50);

                entity.Property(e => e.NameEn).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ApplyAuditInformation();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ApplyAuditInformation();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


        private void ApplyAuditInformation()
            => this.ChangeTracker
                .Entries()
                .ToList()
                .ForEach(entry => {
                    var userName = this.currentUser.GetUserName();
                    if (entry.Entity is IDeletableEntity deletableEntity)
                    {
                        if (entry.State == EntityState.Deleted)
                        {
                            deletableEntity.DeletedOn = DateTime.UtcNow;
                            deletableEntity.DeletedBy = userName;
                            deletableEntity.IsDeleted = true;

                            entry.State = EntityState.Modified;
                        }
                    }
                    if (entry.Entity is IEntity entity)
                    {

                        if (entry.State == EntityState.Added)
                        {
                            entity.CreationDate = DateTime.UtcNow;
                            entity.CreationUserName = userName;
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            entity.LastUpdateDate = DateTime.UtcNow;
                            entity.LastUpdateUserName = userName;
                        }
                    }
                })
            ;
    }
}