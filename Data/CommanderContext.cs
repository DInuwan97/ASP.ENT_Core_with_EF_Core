using Microsoft.EntityFrameworkCore;
using MYTestingASPNETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYTestingASPNETCore.Data
{
    public class CommanderContext : DbContext
    {
        public DbSet<Command> Commands { get; set; }
        public CommanderContext(DbContextOptions<CommanderContext> opt) :base(opt)
        {

        }
    }
}
