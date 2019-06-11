using EfRelationshipsAndGraphs.Core.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EfRelationshipsAndGraphs.Persistance
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }

        public virtual DbSet<Charter> Charters { get; set; }
        public virtual DbSet<Moe> Moes { get; set; }
        public virtual DbSet<Expenditure> Expenditures { get; set; }
        public virtual DbSet<DirectSupport> DirectSupports { get; set; }
        public virtual DbSet<Exemption> Exemptions { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Charter>()
                .HasMany(x => x.Moes)
                .WithRequired(x => x.Charter)
                .HasForeignKey(x => x.CharterId);

            modelBuilder.Entity<Moe>()
                .HasOptional(s => s.Expenditure)
                .WithRequired(x => x.Moe)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Moe>()
                .HasOptional(s => s.DirectSupport)
                .WithRequired(x => x.Moe)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Moe>()
                .HasOptional(s => s.Exemption)
                .WithRequired(x => x.Moe)
                .WillCascadeOnDelete();

            ////Exemption and it's children
            //modelBuilder.Entity<Exemption>()
            //    .HasMany(x => x.Staffs)
            //    .WithRequired(x => x.Exemption)
            //    .HasForeignKey(x => x.MoeId)
            //    .WillCascadeOnDelete();

            //modelBuilder.Entity<Exemption>()
            //    .HasMany(x => x.Students)
            //    .WithRequired(x => x.Exemption)
            //    .HasForeignKey(x => x.MoeId)
            //    .WillCascadeOnDelete();

            //modelBuilder.Entity<Exemption>()
            //    .HasMany(x => x.CostlyExpenditures)
            //    .WithRequired(x => x.Exemption)
            //    .HasForeignKey(x => x.MoeId)
            //    .WillCascadeOnDelete();

            base.OnModelCreating(modelBuilder);
        }
    }
}