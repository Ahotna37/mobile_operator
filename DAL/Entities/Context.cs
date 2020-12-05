using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Entities
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=MobileOperator")
        {
        }

        public virtual DbSet<Call> Call { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ConnectService> ConnectService { get; set; }
        public virtual DbSet<ConnectTariff> ConnectTariff { get; set; }
        public virtual DbSet<ExtraService> ExtraService { get; set; }
        public virtual DbSet<LegalPerson> LegalPerson { get; set; }
        public virtual DbSet<PhysicalPerson> PhysicalPerson { get; set; }
        public virtual DbSet<Sms> Sms { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TariffPlan> TariffPlan { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Call>()
                .Property(e => e.numberWasCall)
                .IsFixedLength();

            modelBuilder.Entity<Client>()
                .Property(e => e.balance)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Client>()
                .Property(e => e.password)
                .IsFixedLength();

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Call)
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.idClient);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.ConnectService)
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.idClient);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.ConnectTariff)
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.idClient);

            modelBuilder.Entity<Client>()
                .HasOptional(e => e.LegalPerson)
                .WithRequired(e => e.Client);

            modelBuilder.Entity<Client>()
                .HasOptional(e => e.PhysicalPerson)
                .WithRequired(e => e.Client);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Sms)
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.idClient);

            modelBuilder.Entity<ExtraService>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<ExtraService>()
                .Property(e => e.subscFee)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ExtraService>()
                .HasMany(e => e.ConnectService)
                .WithOptional(e => e.ExtraService)
                .HasForeignKey(e => e.idExtraService);

            modelBuilder.Entity<LegalPerson>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<LegalPerson>()
                .Property(e => e.legalAdress)
                .IsFixedLength();

            modelBuilder.Entity<LegalPerson>()
                .Property(e => e.ITN)
                .IsFixedLength();

            modelBuilder.Entity<PhysicalPerson>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<PhysicalPerson>()
                .Property(e => e.surname)
                .IsFixedLength();

            modelBuilder.Entity<PhysicalPerson>()
                .Property(e => e.numberPassport)
                .IsFixedLength();

            modelBuilder.Entity<Sms>()
                .Property(e => e.recipientSms)
                .IsFixedLength();

            modelBuilder.Entity<Sms>()
                .Property(e => e.textSms)
                .IsUnicode(false);

            modelBuilder.Entity<TariffPlan>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<TariffPlan>()
                .Property(e => e.costOneMinCallCity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TariffPlan>()
                .Property(e => e.costOneMinCallOutCity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TariffPlan>()
                .Property(e => e.CostOneMinCallInternation)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TariffPlan>()
                .Property(e => e.costChangeTar)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TariffPlan>()
                .HasMany(e => e.ConnectTariff)
                .WithRequired(e => e.TariffPlan)
                .HasForeignKey(e => e.idTariffPlan)
                .WillCascadeOnDelete(false);
        }
    }
}
