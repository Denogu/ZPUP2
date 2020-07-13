using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Models
{
    public class ZPUPContext : DbContext
    {
        public ZPUPContext(DbContextOptions<ZPUPContext> options)
            : base(options)
        {
        }

        public DbSet<ZPUP> ZPUPs { get; set; }
    }
}
