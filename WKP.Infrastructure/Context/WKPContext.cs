using Microsoft.EntityFrameworkCore;
using WKP.Domain.Entities;

namespace WKP.Infrastructure.Context
{
    public class WKPContext: DbContext
    {
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<ADMIN_COMPANY_INFORMATION> ADMIN_COMPANY_INFORMATIONs{ get; set; }
        public virtual DbSet<staff> Staffs { get; set; }
        public virtual DbSet<Domain.Entities.Application> Applications{ get; set; }
        public virtual DbSet<StrategicBusinessUnit> SBUs { get; set;}
        public virtual DbSet<ReturnedApplication> ReturnedApplications  { get; set; }
        public virtual DbSet<TypeOfPayments> TypeOfPayments{ get; set; }
        public virtual DbSet<PermitApproval> PermitApprovals {get; set;}
        public virtual DbSet<MyDesk> Desks { get; set;}
        public virtual DbSet<ADMIN_CONCESSIONS_INFORMATION> Concessions {get; set;}
        public virtual DbSet<COMPANY_FIELD> Fields { get; set;} 

        public WKPContext(DbContextOptions<WKPContext> options): base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADMIN_COMPANY_INFORMATION>(entity =>
            {
                entity.ToTable("ADMIN_COMPANY_INFORMATION");

                entity.Property(e => e.CATEGORY)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.COMPANY_ID)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.COMPANY_NAME)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.CompanyAddress)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.Created_by)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.DELETED_BY)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.DELETED_DATE)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.DELETED_STATUS)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.DESIGNATION)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Date_Created).HasColumnType("datetime");
                entity.Property(e => e.EMAIL)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.EMAIL_REMARK)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.FLAG1)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.FLAG2)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.FLAG_PASSWORD_CHANGE)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.LAST_LOGIN_DATE).HasColumnType("datetime");
                entity.Property(e => e.NAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.PASSWORDS)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.PHONE_NO)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.STATUS_)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.UPDATED_DATE)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("staff");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
                entity.Property(e => e.DeletedAt).HasColumnType("datetime");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.SignatureName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.SignaturePath)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.StaffElpsID)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.StaffEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });


            modelBuilder.Entity<PermitApproval>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
                entity.Property(e => e.DateExpired).HasPrecision(0);
                entity.Property(e => e.DateIssued).HasPrecision(0);
                entity.Property(e => e.IsRenewed).HasMaxLength(130);
                entity.Property(e => e.PermitNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MyDesk>(entity =>
            {
                entity.ToTable("MyDesks");

                entity.HasKey(e => e.DeskID).HasName("PK_MyDesk_UT");

                entity.Property(e => e.Comment).IsUnicode(false);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
                entity.Property(e => e.FromSBU)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<ADMIN_CONCESSIONS_INFORMATION>(entity =>
            {
                entity.HasKey(e => e.Consession_Id).HasName("PK_ADMIN_CONCESSIONS_INFORMATIONs");

                entity.ToTable("ADMIN_CONCESSIONS_INFORMATION");

                entity.Property(e => e.Area)
                    .HasMaxLength(3900)
                    .IsUnicode(false);
                entity.Property(e => e.CLOSE_DATE)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.COMPANY_EMAIL)
                    .HasMaxLength(3900)
                    .IsUnicode(false);
                entity.Property(e => e.Comment)
                    .HasMaxLength(3900)
                    .IsUnicode(false);
                entity.Property(e => e.CompanyName)
                    .HasMaxLength(3900)
                    .IsUnicode(false);
                entity.Property(e => e.Company_ID)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.ConcessionName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Concession_Held)
                    .HasMaxLength(3900)
                    .IsUnicode(false);
                entity.Property(e => e.Concession_Unique_ID)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Consession_Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Contract_Type)
                    .HasMaxLength(3900)
                    .IsUnicode(false);
                entity.Property(e => e.Created_by)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.DELETED_BY)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.DELETED_DATE)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.DELETED_STATUS)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Date_Created).HasColumnType("datetime");
                entity.Property(e => e.Date_Updated).HasColumnType("datetime");
                entity.Property(e => e.Date_of_Expiration).HasColumnType("datetime");
                entity.Property(e => e.EMAIL_REMARK)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Equity_distribution).IsUnicode(false);
                entity.Property(e => e.Field_Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Flag1)
                    .HasMaxLength(3900)
                    .IsUnicode(false);
                entity.Property(e => e.Flag2)
                    .HasMaxLength(3900)
                    .IsUnicode(false);
                entity.Property(e => e.Geological_location)
                    .HasMaxLength(3900)
                    .IsUnicode(false);
                entity.Property(e => e.OPEN_DATE)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Status_)
                    .HasMaxLength(3900)
                    .IsUnicode(false);
                entity.Property(e => e.Terrain)
                    .HasMaxLength(3900)
                    .IsUnicode(false);
                entity.Property(e => e.Updated_by)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Year)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Year_of_Grant_Award)
                    .HasMaxLength(3900)
                    .IsUnicode(false);
                entity.Property(e => e.submitted)
                    .HasMaxLength(3900)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<COMPANY_FIELD>(entity =>
            {
                entity.HasKey(e => e.Field_ID);

                entity.ToTable("COMPANY_FIELDS");

                entity.Property(e => e.Date_Created).HasColumnType("datetime");
                entity.Property(e => e.Date_Updated).HasColumnType("datetime");
                entity.Property(e => e.Field_Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Field_Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}