using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    public class CommandContext : DbContext
    {
        public CommandContext(DbContextOptions<CommandContext> options) : base(options)
        {

        }

        public DbSet<LocalUnion> LocalUnions { get; set; }
        public DbSet<UnionCounty> UnionCounties { get; set; }
        public DbSet<Command> CommandItems { get; set; }
        public DbSet<Person> PersonItems { get; set; }
        public DbSet<Case> CaseItems { get; set; }

    }
}
