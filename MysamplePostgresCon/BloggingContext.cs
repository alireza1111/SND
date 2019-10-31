using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MysamplePostgresCon.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MysamplePostgresCon
{
    public class BloggingContext : DbContext
    {
        public IConfiguration Configuration { get; }
        public BloggingContext() : base()
        {
        }

        public BloggingContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile(@"C:\Users\xdaval\source\repos\MysamplePostgresCon\appsettings.Development.json", optional: false)
                .AddJsonFile($"appsettings.{envName}.json", optional: true)
                .Build();

            optionsBuilder.UseNpgsql(configuration.GetConnectionString("BloggingConnection"));

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
