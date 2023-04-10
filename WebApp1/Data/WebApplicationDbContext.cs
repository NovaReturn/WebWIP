using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1.Data
{
    public class WebApplicationDbContext : DbContext
    {
        public WebApplicationDbContext (DbContextOptions<WebApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebApp1.Models.Shouts> Shout { get; set; } = default!;
    }
}
