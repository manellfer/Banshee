using System;
using Microsoft.EntityFrameworkCore;

namespace Banshee.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {

        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<ClientVisits> ClientVisits { get; set; }
    }
}
