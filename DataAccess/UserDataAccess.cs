using DevicMonitor.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DevicMonitor.DataAccess
{
    internal class UserDataAccess : DbContext
    {
        public UserDataAccess(DbContextOptions options) : base(options)
        {
        }

        public UserDataAccess()
        {
        }

        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(
           DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=192.168.1.2;Database=device_monitor;User Id=sa;Password=365373011;TrustServerCertificate=True;")
                            .UseLoggerFactory(LoggerFactory.Create(logBuilder => logBuilder.AddConsole())) // 控制台输出
                            .EnableSensitiveDataLogging(); // 启用敏感数据日志记录（可选）;

        }
    }
}
