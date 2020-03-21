using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ngoWebhookApi.Models
{
    public class exampleEventContext : DbContext
    {

        public exampleEventContext(DbContextOptions<exampleEventContext> options) : base(options) { }

        public DbSet<ngoEvent> exampleEvents { get; set; }

    }

}
