using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EFCoreDBFirstTest.Models
{
    public partial class AdvokathusetContext : DbContext
    {
        public AdvokathusetContext()
        {
        }

        public AdvokathusetContext(DbContextOptions<AdvokathusetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdvArbejdsYdelser> AdvArbejdsYdelsers { get; set; }
        public virtual DbSet<AdvokatUddannelser> AdvokatUddannelsers { get; set; }
        public virtual DbSet<Kunde> Kundes { get; set; }
        public virtual DbSet<KundeTlf> KundeTlves { get; set; }
        public virtual DbSet<Kørsel> Kørsels { get; set; }
        public virtual DbSet<LogIn> LogIns { get; set; }
        public virtual DbSet<Medarbejder> Medarbejders { get; set; }
        public virtual DbSet<MedarbejderTlf> MedarbejderTlves { get; set; }
        public virtual DbSet<MedarbejderType> MedarbejderTypes { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Sag> Sags { get; set; }
        public virtual DbSet<SagYdelser> SagYdelsers { get; set; }
        public virtual DbSet<Tid> Tids { get; set; }
        public virtual DbSet<TypeYdelse> TypeYdelses { get; set; }
        public virtual DbSet<Uddannelser> Uddannelsers { get; set; }
        public virtual DbSet<Ydelse> Ydelses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Advokathuset;Integrated Security=True;ConnectRetryCount=0");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdvArbejdsYdelser>(entity =>
            {
                entity.HasKey(e => new { e.YdelseNr, e.AdvId });

                entity.ToTable("Adv_Arbejds_Ydelser");

                entity.Property(e => e.YdelseNr).HasColumnName("Ydelse_Nr");

                entity.Property(e => e.AdvId).HasColumnName("Adv_ID");

                entity.HasOne(d => d.Adv)
                    .WithMany(p => p.AdvArbejdsYdelsers)
                    .HasForeignKey(d => d.AdvId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Adv_Arbejds_Ydelser_Medarbejder");
            });

            modelBuilder.Entity<AdvokatUddannelser>(entity =>
            {
                entity.HasKey(e => new { e.AdvokatUddanelse, e.MeId })
                    .HasName("PK_Advokat_Uddannelser_1");

                entity.ToTable("Advokat_Uddannelser");

                entity.Property(e => e.AdvokatUddanelse)
                    .HasMaxLength(30)
                    .HasColumnName("Advokat_Uddanelse");

                entity.Property(e => e.MeId).HasColumnName("Me_ID");

                entity.HasOne(d => d.AdvokatUddanelseNavigation)
                    .WithMany(p => p.AdvokatUddannelsers)
                    .HasForeignKey(d => d.AdvokatUddanelse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Advokat_Advokat_Udanelser");

                entity.HasOne(d => d.Me)
                    .WithMany(p => p.AdvokatUddannelsers)
                    .HasForeignKey(d => d.MeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Advokat_Uddannelser_Medarbejder");
            });

            modelBuilder.Entity<Kunde>(entity =>
            {
                entity.ToTable("Kunde");

                entity.Property(e => e.KundeId)
                    .ValueGeneratedNever()
                    .HasColumnName("Kunde_ID");

                entity.Property(e => e.KundeAdresse)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Kunde_Adresse");

                entity.Property(e => e.KundeEfternavn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Kunde_Efternavn");

                entity.Property(e => e.KundeEmail)
                    .HasMaxLength(50)
                    .HasColumnName("Kunde_Email");

                entity.Property(e => e.KundeFornavn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Kunde_Fornavn");

                entity.Property(e => e.KundeOpretsDato)
                    .HasMaxLength(25)
                    .HasColumnName("Kunde_Oprets_Dato");

                entity.Property(e => e.KundePostNr).HasColumnName("Kunde_PostNr");

                entity.HasOne(d => d.KundePostNrNavigation)
                    .WithMany(p => p.Kundes)
                    .HasForeignKey(d => d.KundePostNr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kunde_Post");
            });

            modelBuilder.Entity<KundeTlf>(entity =>
            {
                entity.HasKey(e => new { e.KundeTlf1, e.KundeId });

                entity.ToTable("Kunde_Tlf");

                entity.Property(e => e.KundeTlf1).HasColumnName("Kunde_Tlf");

                entity.Property(e => e.KundeId).HasColumnName("Kunde_ID");

                entity.HasOne(d => d.Kunde)
                    .WithMany(p => p.KundeTlves)
                    .HasForeignKey(d => d.KundeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kunde_Tlf_Kunde1");
            });

            modelBuilder.Entity<Kørsel>(entity =>
            {
                entity.ToTable("Kørsel");

                entity.Property(e => e.KørselId)
                    .ValueGeneratedNever()
                    .HasColumnName("Kørsel_ID");

                entity.Property(e => e.AdvokatId).HasColumnName("Advokat_ID");

                entity.Property(e => e.KørselDato)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Kørsel_Dato");

                entity.Property(e => e.KørselNotering)
                    .HasMaxLength(70)
                    .HasColumnName("Kørsel_Notering");

                entity.Property(e => e.KørselTid)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Kørsel_Tid");

                entity.Property(e => e.SagId).HasColumnName("Sag_ID");

                entity.HasOne(d => d.Advokat)
                    .WithMany(p => p.Kørsels)
                    .HasForeignKey(d => d.AdvokatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kørsel_Medarbejder");

                entity.HasOne(d => d.Sag)
                    .WithMany(p => p.Kørsels)
                    .HasForeignKey(d => d.SagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kørsel_Sag1");
            });

            modelBuilder.Entity<LogIn>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Log_In");

                entity.HasIndex(e => e.LogInNavn, "IX_Log_In")
                    .IsUnique();

                entity.HasIndex(e => e.MeId, "IX_Log_In_1")
                    .IsUnique();

                entity.Property(e => e.LogInNavn)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Log_In_Navn");

                entity.Property(e => e.LogInPass)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Log_In_Pass");

                entity.Property(e => e.MeId).HasColumnName("Me_ID");

                entity.HasOne(d => d.Me)
                    .WithOne()
                    .HasForeignKey<LogIn>(d => d.MeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Log_In_Medarbejder");
            });

            modelBuilder.Entity<Medarbejder>(entity =>
            {
                entity.HasKey(e => e.MeId)
                    .HasName("PK_Medarbejder_1");

                entity.ToTable("Medarbejder");

                entity.HasIndex(e => e.MeFornavn, "IX_Medarbejder")
                    .IsUnique();

                entity.Property(e => e.MeId)
                    .ValueGeneratedNever()
                    .HasColumnName("Me_ID");

                entity.Property(e => e.MeAdresse)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Me_Adresse");

                entity.Property(e => e.MeEfternavn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Me_Efternavn");

                entity.Property(e => e.MeEmail)
                    .HasMaxLength(50)
                    .HasColumnName("Me_Email");

                entity.Property(e => e.MeFornavn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Me_Fornavn");

                entity.Property(e => e.MeOpretsDato)
                    .HasMaxLength(25)
                    .HasColumnName("Me_Oprets_Dato");

                entity.Property(e => e.MePostNr).HasColumnName("Me_PostNr");

                entity.Property(e => e.MeType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Me_Type");

                entity.HasOne(d => d.MePostNrNavigation)
                    .WithMany(p => p.Medarbejders)
                    .HasForeignKey(d => d.MePostNr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medarbejder_Post");

                entity.HasOne(d => d.MeTypeNavigation)
                    .WithMany(p => p.Medarbejders)
                    .HasForeignKey(d => d.MeType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medarbejder_Medarbejder_Type");
            });

            modelBuilder.Entity<MedarbejderTlf>(entity =>
            {
                entity.HasKey(e => new { e.MeTlf, e.MeId });

                entity.ToTable("Medarbejder_Tlf");

                entity.Property(e => e.MeTlf).HasColumnName("Me_Tlf");

                entity.Property(e => e.MeId).HasColumnName("Me_ID");

                entity.HasOne(d => d.Me)
                    .WithMany(p => p.MedarbejderTlves)
                    .HasForeignKey(d => d.MeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medarbejder_Tlf_Medarbejder1");
            });

            modelBuilder.Entity<MedarbejderType>(entity =>
            {
                entity.HasKey(e => e.MeType);

                entity.ToTable("Medarbejder_Type");

                entity.Property(e => e.MeType)
                    .HasMaxLength(20)
                    .HasColumnName("Me_Type");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.PostNr);

                entity.ToTable("Post");

                entity.Property(e => e.PostNr).ValueGeneratedNever();

                entity.Property(e => e.Distrikt).HasMaxLength(50);
            });

            modelBuilder.Entity<Sag>(entity =>
            {
                entity.ToTable("Sag");

                entity.Property(e => e.SagId)
                    .ValueGeneratedNever()
                    .HasColumnName("Sag_ID");

                entity.Property(e => e.SagAdvokatId).HasColumnName("Sag_Advokat_ID");

                entity.Property(e => e.SagAfslutet).HasColumnName("Sag_Afslutet");

                entity.Property(e => e.SagKundeId).HasColumnName("Sag_Kunde_ID");

                entity.Property(e => e.SagOpretsDato)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("Sag_Oprets_Dato");

                entity.Property(e => e.SagSlutDato)
                    .HasMaxLength(15)
                    .HasColumnName("Sag_Slut_Dato");

                entity.Property(e => e.SagType)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("Sag_Type");

                entity.HasOne(d => d.SagAdvokat)
                    .WithMany(p => p.Sags)
                    .HasForeignKey(d => d.SagAdvokatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sag_Medarbejder");

                entity.HasOne(d => d.SagKunde)
                    .WithMany(p => p.Sags)
                    .HasForeignKey(d => d.SagKundeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sag_Kunde");
            });

            modelBuilder.Entity<SagYdelser>(entity =>
            {
                entity.HasKey(e => new { e.SagId, e.YdelseNr });

                entity.ToTable("Sag_Ydelser");

                entity.Property(e => e.SagId).HasColumnName("Sag_ID");

                entity.Property(e => e.YdelseNr).HasColumnName("Ydelse_Nr");

                entity.Property(e => e.SagYdelseOpretsDato)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("Sag_Ydelse_Oprets_Dato");

                entity.HasOne(d => d.Sag)
                    .WithMany(p => p.SagYdelsers)
                    .HasForeignKey(d => d.SagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sag_Ydelser_Sag1");

                entity.HasOne(d => d.YdelseNrNavigation)
                    .WithMany(p => p.SagYdelsers)
                    .HasForeignKey(d => d.YdelseNr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sag_Ydelser_Ydelse");
            });

            modelBuilder.Entity<Tid>(entity =>
            {
                entity.ToTable("Tid");

                entity.Property(e => e.TidId)
                    .ValueGeneratedNever()
                    .HasColumnName("Tid_ID");

                entity.Property(e => e.AdvokatId).HasColumnName("Advokat_ID");

                entity.Property(e => e.SagId).HasColumnName("Sag_ID");

                entity.Property(e => e.Tid1)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Tid");

                entity.Property(e => e.TidDato)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("Tid_Dato");

                entity.Property(e => e.YdelseNr).HasColumnName("Ydelse_Nr");

                entity.HasOne(d => d.Advokat)
                    .WithMany(p => p.Tids)
                    .HasForeignKey(d => d.AdvokatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tid_Medarbejder");

                entity.HasOne(d => d.Sag)
                    .WithMany(p => p.Tids)
                    .HasForeignKey(d => d.SagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tid_Sag1");

                entity.HasOne(d => d.SagYdelser)
                    .WithMany(p => p.Tids)
                    .HasForeignKey(d => new { d.SagId, d.YdelseNr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tid_Sag_Ydelser");
            });

            modelBuilder.Entity<TypeYdelse>(entity =>
            {
                entity.HasKey(e => e.YdelseType);

                entity.ToTable("Type_Ydelse");

                entity.Property(e => e.YdelseType)
                    .HasMaxLength(10)
                    .HasColumnName("Ydelse_Type");
            });

            modelBuilder.Entity<Uddannelser>(entity =>
            {
                entity.HasKey(e => e.AdvokatUddanelse)
                    .HasName("PK_Advokat_Udanelser");

                entity.ToTable("Uddannelser");

                entity.Property(e => e.AdvokatUddanelse)
                    .HasMaxLength(30)
                    .HasColumnName("Advokat_Uddanelse");
            });

            modelBuilder.Entity<Ydelse>(entity =>
            {
                entity.HasKey(e => e.YdelseNr);

                entity.ToTable("Ydelse");

                entity.HasIndex(e => e.YdelseNavn, "IX_Ydelse")
                    .IsUnique();

                entity.Property(e => e.YdelseNr)
                    .ValueGeneratedNever()
                    .HasColumnName("Ydelse_Nr");

                entity.Property(e => e.YdelseArt)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Ydelse_Art");

                entity.Property(e => e.YdelseNavn)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("Ydelse_Navn");

                entity.Property(e => e.YdelseOpretsDato)
                    .HasMaxLength(25)
                    .HasColumnName("Ydelse_Oprets_Dato");

                entity.Property(e => e.YdelsePris)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Ydelse_Pris");

                entity.Property(e => e.YdelseType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Ydelse_Type");

                entity.HasOne(d => d.YdelseTypeNavigation)
                    .WithMany(p => p.Ydelses)
                    .HasForeignKey(d => d.YdelseType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ydelse_Type_Ydelse");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
