using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Channels;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace AreULub.Models
{
    public class ServiceContext : DbContext
    {
        public ServiceContext()
        {
        }

        public ServiceContext(DbContextOptions<ServiceContext> options)
          : base(options)
        { }


        public DbSet<ServiceModel> Services { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CommentsModel> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                 new User {UserId = "1", UserLast = "FakeLast1", UserName = "Johnny" },
                 new User { UserId = "2", UserLast = "FakeLast2", UserName = "Tommy" },
                 new User { UserId = "3", UserLast = "FakeLast3", UserName = "Danny" },
                 new User { UserId = "4", UserLast = "FakeLast4", UserName = "Mannly" },
                 new User { UserId = "5", UserLast = "FakeLast5", UserName = "Conny" },
                 new User { UserId = "6", UserLast = "FakeLast6", UserName = "Sunny" },
                 new User { UserId = "7", UserLast = "FakeLast7", UserName = "Diandra" }
             );
            modelBuilder.Entity<ServiceModel>().HasData(
                new ServiceModel
                {
                    ServiceID = 1,
                    ServiceName = "Oil Change",
                    ServiceDescription = "Fast and using the best oil",
                    ServiceEstimated = "Around 30 minutes",
                    ServicePrice = 80,
                    UserID = "1"

                },
                  new ServiceModel
                  {
                      ServiceID = 2,
                      ServiceName = "General checkout",
                      ServiceDescription = "Reliable to get your car ready",
                      ServiceEstimated = "Around 1 hour",
                      ServicePrice = 140,
                      UserID = "5"

                  },
                    new ServiceModel
                    {
                        ServiceID = 3,
                        ServiceName = "Battery change",
                        ServiceDescription = "Quick and using Duracell",
                        ServiceEstimated = "Around 15 minutes",
                        ServicePrice = 120,
                        UserID = "7"


                    }
            );

        }
        
        }
}
