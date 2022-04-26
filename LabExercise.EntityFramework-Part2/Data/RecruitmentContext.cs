using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LabExercise.EntityFramework_Part2.Models;

#nullable disable

namespace LabExercise.EntityFramework_Part2.Data
{
    public partial class RecruitmentContext : DbContext
    {
        private string connectionString;
        public RecruitmentContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public virtual DbSet<AnnualSalary> AnnualSalaries { get; set; }
        public virtual DbSet<CampusRecruitment> CampusRecruitments { get; set; }
        public virtual DbSet<CandidateSkill> CandidateSkills { get; set; }
        public virtual DbSet<College> Colleges { get; set; }
        public virtual DbSet<ContractRecruiter> ContractRecruiters { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeReferral> EmployeeReferrals { get; set; }
        public virtual DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public virtual DbSet<ExternalCandidate> ExternalCandidates { get; set; }
        public virtual DbSet<InternalCandidate> InternalCandidates { get; set; }
        public virtual DbSet<InternalJobPosting> InternalJobPostings { get; set; }
        public virtual DbSet<JobFair> JobFairs { get; set; }
        public virtual DbSet<MonthlySalary> MonthlySalaries { get; set; }
        public virtual DbSet<NewsAd> NewsAds { get; set; }
        public virtual DbSet<Newspaper> Newspapers { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<PositionSkill> PositionSkills { get; set; }
        public virtual DbSet<RecruitmentAgency> RecruitmentAgencies { get; set; }
        public virtual DbSet<Recruitmentuser> Recruitmentusers { get; set; }
        public virtual DbSet<Requisition> Requisitions { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=3LMBQG3;Database=Recruitment;User Id=sa;Password=edwin9598");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AnnualSalary>(entity =>
            {
                entity.HasKey(e => new { e.CEmployeeCode, e.SiYear })
                    .HasName("ast_pk");

                entity.Property(e => e.CEmployeeCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CEmployeeCodeNavigation)
                    .WithMany(p => p.AnnualSalaries)
                    .HasForeignKey(d => d.CEmployeeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AnnualSal__cEmpl__66603565");
            });

            modelBuilder.Entity<CampusRecruitment>(entity =>
            {
                entity.HasKey(e => e.CCampusRecruitmentCode)
                    .HasName("cr_pk");

                entity.Property(e => e.CCampusRecruitmentCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCollegeCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CCollegeCodeNavigation)
                    .WithMany(p => p.CampusRecruitments)
                    .HasForeignKey(d => d.CCollegeCode)
                    .HasConstraintName("FK__CampusRec__cColl__5441852A");
            });

            modelBuilder.Entity<CandidateSkill>(entity =>
            {
                entity.HasKey(e => new { e.CCandidateCode, e.CSkillCode })
                    .HasName("sctv_pk");

                entity.Property(e => e.CCandidateCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CSkillCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CCandidateCodeNavigation)
                    .WithMany(p => p.CandidateSkills)
                    .HasForeignKey(d => d.CCandidateCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Candidate__cCand__00200768");

                entity.HasOne(d => d.CSkillCodeNavigation)
                    .WithMany(p => p.CandidateSkills)
                    .HasForeignKey(d => d.CSkillCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Candidate__cSkil__01142BA1");
            });

            modelBuilder.Entity<College>(entity =>
            {
                entity.HasKey(e => e.CCollegeCode)
                    .HasName("ct_pk");

                entity.Property(e => e.CCollegeCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCity)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCollegeName)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CPhone)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CState)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CZip)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VCollegeAddress).IsUnicode(false);
            });

            modelBuilder.Entity<ContractRecruiter>(entity =>
            {
                entity.HasKey(e => e.CContractRecruiterCode)
                    .HasName("crtp_pk");

                entity.Property(e => e.CContractRecruiterCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCity)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CFax)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CName)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CPhone)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CState)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CZip)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VAddress).IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CCountryCode)
                    .HasName("c_pk");

                entity.Property(e => e.CCountryCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCountry)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.CDepartmentCode)
                    .HasName("dt_pk");

                entity.Property(e => e.CDepartmentCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VDepartmentHead).IsUnicode(false);

                entity.Property(e => e.VDepartmentName).IsUnicode(false);

                entity.Property(e => e.VLocation).IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.CEmployeeCode)
                    .HasName("etv_pk");

                entity.Property(e => e.CEmployeeCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCandidateCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCity)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCountryCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCurrentPosition)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CDepartmentCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CDesignation)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CEmailId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CPhone)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CRegion)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CSex)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CSocialSecurityNo)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CState)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CSupervisorCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CZip)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VAddress).IsUnicode(false);

                entity.Property(e => e.VFirstName).IsUnicode(false);

                entity.Property(e => e.VLastName).IsUnicode(false);

                entity.Property(e => e.VQualification).IsUnicode(false);

                entity.HasOne(d => d.CCountryCodeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CCountryCode)
                    .HasConstraintName("FK__Employee__cCount__5EBF139D");

                entity.HasOne(d => d.CDepartmentCodeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CDepartmentCode)
                    .HasConstraintName("FK__Employee__cDepar__60A75C0F");
            });

            modelBuilder.Entity<EmployeeReferral>(entity =>
            {
                entity.HasKey(e => e.CEmployeeReferralNo)
                    .HasName("ert_pk");

                entity.Property(e => e.CEmployeeReferralNo)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCandidateCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CEmployeeCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CCandidateCodeNavigation)
                    .WithMany(p => p.EmployeeReferrals)
                    .HasForeignKey(d => d.CCandidateCode)
                    .HasConstraintName("FK__EmployeeR__cCand__74AE54BC");

                entity.HasOne(d => d.CEmployeeCodeNavigation)
                    .WithMany(p => p.EmployeeReferrals)
                    .HasForeignKey(d => d.CEmployeeCode)
                    .HasConstraintName("FK__EmployeeR__cEmpl__73BA3083");
            });

            modelBuilder.Entity<EmployeeSkill>(entity =>
            {
                entity.HasKey(e => new { e.CEmployeeCode, e.CSkillCode })
                    .HasName("vest_pk");

                entity.Property(e => e.CEmployeeCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CSkillCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CEmployeeCodeNavigation)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.CEmployeeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeS__cEmpl__797309D9");

                entity.HasOne(d => d.CSkillCodeNavigation)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.CSkillCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeS__cSkil__7A672E12");
            });

            modelBuilder.Entity<ExternalCandidate>(entity =>
            {
                entity.HasKey(e => e.CCandidateCode)
                    .HasName("ectv_pk");

                entity.Property(e => e.CCandidateCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CAgencyCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCampusRecruitmentCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCity)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCollegeCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CContractRecruiterCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCountryCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CEmployeeReferralNo)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CExEmployeeCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CInterviewer)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CJobFairCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CNewsAdNo)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CPhone)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CPositionCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CRating)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CSex)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CState)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CStatus)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CZip)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VAddress).IsUnicode(false);

                entity.Property(e => e.VEmailId).IsUnicode(false);

                entity.Property(e => e.VFirstName).IsUnicode(false);

                entity.Property(e => e.VInterviewComments).IsUnicode(false);

                entity.Property(e => e.VLastName).IsUnicode(false);

                entity.Property(e => e.VQualification).IsUnicode(false);

                entity.HasOne(d => d.CAgencyCodeNavigation)
                    .WithMany(p => p.ExternalCandidates)
                    .HasForeignKey(d => d.CAgencyCode)
                    .HasConstraintName("FK__ExternalC__cAgen__6E01572D");

                entity.HasOne(d => d.CCampusRecruitmentCodeNavigation)
                    .WithMany(p => p.ExternalCandidates)
                    .HasForeignKey(d => d.CCampusRecruitmentCode)
                    .HasConstraintName("FK__ExternalC__cCamp__70DDC3D8");

                entity.HasOne(d => d.CContractRecruiterCodeNavigation)
                    .WithMany(p => p.ExternalCandidates)
                    .HasForeignKey(d => d.CContractRecruiterCode)
                    .HasConstraintName("FK__ExternalC__cCont__6EF57B66");

                entity.HasOne(d => d.CCountryCodeNavigation)
                    .WithMany(p => p.ExternalCandidates)
                    .HasForeignKey(d => d.CCountryCode)
                    .HasConstraintName("FK__ExternalC__cCoun__6A30C649");

                entity.HasOne(d => d.CJobFairCodeNavigation)
                    .WithMany(p => p.ExternalCandidates)
                    .HasForeignKey(d => d.CJobFairCode)
                    .HasConstraintName("FK__ExternalC__cJobF__6FE99F9F");

                entity.HasOne(d => d.CNewsAdNoNavigation)
                    .WithMany(p => p.ExternalCandidates)
                    .HasForeignKey(d => d.CNewsAdNo)
                    .HasConstraintName("FK__ExternalC__cNews__6D0D32F4");

                entity.HasOne(d => d.CPositionCodeNavigation)
                    .WithMany(p => p.ExternalCandidates)
                    .HasForeignKey(d => d.CPositionCode)
                    .HasConstraintName("FK__ExternalC__cPosi__6C190EBB");
            });

            modelBuilder.Entity<InternalCandidate>(entity =>
            {
                entity.HasKey(e => new { e.CCandidateCode, e.CEmployeeCode, e.CInternalJobPostingCode })
                    .HasName("ict_pk");

                entity.Property(e => e.CCandidateCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CEmployeeCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CInternalJobPostingCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CInterviewer)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CPositionCodeAppliedFor)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CRating)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CStatus)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VInterviewComments).IsUnicode(false);

                entity.HasOne(d => d.CInternalJobPostingCodeNavigation)
                    .WithMany(p => p.InternalCandidates)
                    .HasForeignKey(d => d.CInternalJobPostingCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__InternalC__cInte__59063A47");

                entity.HasOne(d => d.CPositionCodeAppliedForNavigation)
                    .WithMany(p => p.InternalCandidates)
                    .HasForeignKey(d => d.CPositionCodeAppliedFor)
                    .HasConstraintName("FK__InternalC__cPosi__59FA5E80");
            });

            modelBuilder.Entity<InternalJobPosting>(entity =>
            {
                entity.HasKey(e => e.CInternalJobPostingCode)
                    .HasName("ijp_pk");

                entity.Property(e => e.CInternalJobPostingCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CPositionCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VRegion).IsUnicode(false);
            });

            modelBuilder.Entity<JobFair>(entity =>
            {
                entity.HasKey(e => e.CJobFairCode)
                    .HasName("jft_pk");

                entity.Property(e => e.CJobFairCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VJobFairCompany).IsUnicode(false);

                entity.Property(e => e.VLocation).IsUnicode(false);
            });

            modelBuilder.Entity<MonthlySalary>(entity =>
            {
                entity.HasKey(e => new { e.CEmployeeCode, e.DPayDate })
                    .HasName("mst_pk");

                entity.Property(e => e.CEmployeeCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CEmployeeCodeNavigation)
                    .WithMany(p => p.MonthlySalaries)
                    .HasForeignKey(d => d.CEmployeeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MonthlySa__cEmpl__6383C8BA");
            });

            modelBuilder.Entity<NewsAd>(entity =>
            {
                entity.HasKey(e => e.CNewsAdNo)
                    .HasName("nat_pk");

                entity.Property(e => e.CNewsAdNo)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CNewspaperCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CNewspaperCodeNavigation)
                    .WithMany(p => p.NewsAds)
                    .HasForeignKey(d => d.CNewspaperCode)
                    .HasConstraintName("FK__NewsAd__cNewspap__4316F928");
            });

            modelBuilder.Entity<Newspaper>(entity =>
            {
                entity.HasKey(e => e.CNewspaperCode)
                    .HasName("np_pk");

                entity.Property(e => e.CNewspaperCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCity)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCountryCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CFax)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CNewspaperName)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CPhone)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CState)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CZip)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VContactPerson).IsUnicode(false);

                entity.Property(e => e.VHoaddress).IsUnicode(false);

                entity.Property(e => e.VRegion).IsUnicode(false);

                entity.Property(e => e.VTypeOfNewspaper).IsUnicode(false);

                entity.HasOne(d => d.CCountryCodeNavigation)
                    .WithMany(p => p.Newspapers)
                    .HasForeignKey(d => d.CCountryCode)
                    .HasConstraintName("FK__Newspaper__cCoun__3E52440B");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => new { e.CSourceCode, e.CChequeNo, e.DDate })
                    .HasName("tp_pks");

                entity.Property(e => e.CSourceCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CChequeNo)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.CPositionCode)
                    .HasName("ptv_pk");

                entity.Property(e => e.CPositionCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VDescription).IsUnicode(false);
            });

            modelBuilder.Entity<PositionSkill>(entity =>
            {
                entity.HasKey(e => new { e.CPositionCode, e.CSkillCode })
                    .HasName("pstv_pk");

                entity.Property(e => e.CPositionCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CSkillCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CPositionCodeNavigation)
                    .WithMany(p => p.PositionSkills)
                    .HasForeignKey(d => d.CPositionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PositionS__cPosi__03F0984C");

                entity.HasOne(d => d.CSkillCodeNavigation)
                    .WithMany(p => p.PositionSkills)
                    .HasForeignKey(d => d.CSkillCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PositionS__cSkil__04E4BC85");
            });

            modelBuilder.Entity<RecruitmentAgency>(entity =>
            {
                entity.HasKey(e => e.CAgencyCode)
                    .HasName("rat_pk");

                entity.Property(e => e.CAgencyCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCity)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CFax)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CName)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CPhone)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CState)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CZip)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VAddress).IsUnicode(false);
            });

            modelBuilder.Entity<Recruitmentuser>(entity =>
            {
                entity.Property(e => e.CPassword)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CUserName)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Requisition>(entity =>
            {
                entity.HasKey(e => new { e.CRequisitionCode, e.CPositionCode })
                    .HasName("RTP_PK");

                entity.Property(e => e.CRequisitionCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CPositionCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CDepartmentCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VRegion).IsUnicode(false);

                entity.HasOne(d => d.CPositionCodeNavigation)
                    .WithMany(p => p.Requisitions)
                    .HasForeignKey(d => d.CPositionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Requisiti__cPosi__7D439ABD");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(e => e.CSkillCode)
                    .HasName("stv_pk");

                entity.Property(e => e.CSkillCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VSkill).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
