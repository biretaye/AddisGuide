using GPSNavigationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPSNavigationSystem.Domain.DAL
{
    public class GPSNavigationSystemAPIContext : DbContext 
    {
        public GPSNavigationSystemAPIContext()
            : base("GPSNavigationSystemAPIContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Destination> Destinations { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<Street> Street { get; set; }
        public virtual DbSet<ServiceProvider> ServiceProviders { get; set; }
        public virtual DbSet<ServiceProviderLocation> ServiceProviderLocations { get; set; }
        public virtual DbSet<StationDestination> StationDestinations { get; set; }
        public virtual DbSet<StationLocation> StationLocations { get; set; }
        public virtual DbSet<TrafficSign> TrafficSigns { get; set; }
        public virtual DbSet<TrafficSignLocation> TrafficSignLocations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<MidPoint> MidPoints { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.Configuration.LazyLoadingEnabled = false;

            //modelBuilder.Entity<MidPoint>()
            //    .HasOptional(entity => entity.StationDestination)
            //    .WithOptionalPrincipal()
            //    .Map(x => x.MapKey("MidPointID"));

            //modelBuilder.Entity<StationDestination>()
            //    .HasOptional(entity => entity.MidPoint)
            //    .WithOptionalPrincipal()
            //    .Map(x => x.MapKey("StationDestinationID"));
        }
    }
}
