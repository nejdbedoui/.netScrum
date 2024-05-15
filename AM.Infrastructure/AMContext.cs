
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AM.Infrastructure
{
    public class AMContext: DbContext
    {
        public DbSet<Membre> Membres { get; set; }
        public DbSet<Projet> Projets { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Tache> Taches { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
              Initial Catalog=test;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        //public AMContext(DbContextOptions<AMContext> options) : base(options)
        //{

        //}

        public AMContext()
        {
            //this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public AMContext(DbContextOptions<AMContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TacheConfig());

            modelBuilder.Entity<Tache>().HasKey(p => new
            {
                p.MembreKey,
                p.SprintKey,
                p.Titre
            });

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                  .Properties<string>()
                  .HaveMaxLength(200);

        }



    }
}
