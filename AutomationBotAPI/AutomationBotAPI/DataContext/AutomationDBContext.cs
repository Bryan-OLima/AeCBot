using AutomationBotAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomationBotAPI.DataContext
{
    public class AutomationDBContext : DbContext
    {
        public AutomationDBContext(DbContextOptions<AutomationDBContext> options) : base(options) { }
        public DbSet<Automation> Automations { get; set; }
    }
}
