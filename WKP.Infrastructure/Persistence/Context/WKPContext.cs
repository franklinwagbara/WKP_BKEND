using Microsoft.EntityFrameworkCore;
using WKP.Domain.Entities;
using WKP.Infrastructure.Persistence;

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
        public virtual DbSet<AuditTrail> AuditTrails { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ApplicationProccess> AppProcessFlow { get; set; }
        public virtual DbSet<ApplicationDeskHistory> ApplicationDeskHistories { get; set; }
        public virtual DbSet<ApplicationSBUApproval> ApplicationSBUApprovals { get; set; }
        public virtual DbSet<AppStatus> AppStatuses { get; set; }

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

            modelBuilder.Entity<AuditTrail>(entity =>
            {
                entity.HasKey(e => e.AuditLogID).HasName("PK_AuditTrail");

                entity.Property(e => e.AuditAction).IsUnicode(false);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
                entity.Property(e => e.UserID)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("Role");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.RoleName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.id).ValueGeneratedOnAdd();

                // entity.HasMany(d => d.Funcs).WithMany(p => p.Roles)
                //     .UsingEntity<Dictionary<string, object>>(
                //         "RoleFunctionalityRef",
                //         r => r.HasOne<Functionality>().WithMany()
                //             .HasForeignKey("FuncId")
                //             .OnDelete(DeleteBehavior.ClientSetNull)
                //             .HasConstraintName("FK_RoleFunctionalityRef_Functionality"),
                //         l => l.HasOne<Role>().WithMany()
                //             .HasForeignKey("RoleId")
                //             .OnDelete(DeleteBehavior.ClientSetNull)
                //             .HasConstraintName("FK_RoleFunctionalityRef_Role"),
                //         j =>
                //         {
                //             j.HasKey("RoleId", "FuncId");
                //             j.ToTable("RoleFunctionalityRef");
                //         });
            });

            modelBuilder.Entity<ApplicationProccess>(entity =>
            {
                entity.ToTable("ApplicationProccesses");
                entity.HasKey(e => e.ProccessID).HasName("PK_WorkProccess_");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
                entity.Property(e => e.CreatedBy).HasMaxLength(500);
                entity.Property(e => e.DeletedAt).HasColumnType("datetime");
                entity.Property(e => e.DeletedBy).HasMaxLength(500);
                entity.Property(e => e.ProcessAction).HasMaxLength(100);
                entity.Property(e => e.ProcessStatus).HasMaxLength(100);
                //entity.Property(e => e.TargetTo).HasMaxLength(500);
                //entity.Property(e => e.TriggeredBy).HasMaxLength(500);
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(500);
            });

            modelBuilder.Entity<ApplicationSBUApproval>(entity =>
            {
                entity.ToTable("ApplicationSBUApproval");

                //entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AppId).HasColumnName("AppId");
                entity.Property(e => e.StaffID).HasColumnName("StaffID");
                entity.Property(e => e.Comment).HasColumnName("Comment");
                entity.Property(e => e.Status).HasColumnName("Status");
                entity.Property(e => e.AppAction).HasColumnName("AppAction");
                entity.Property(e => e.DeskID).HasColumnName("DeskID");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<StrategicBusinessUnit>(entity =>
            {
                entity.ToTable("StrategicBusinessUnits");

                entity.Property(e => e.SBU_Code).HasMaxLength(10);
                entity.Property(e => e.SBU_Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AppStatus>(entity =>
            {
                entity.ToTable("AppStatus");
            });
        }
    }
}