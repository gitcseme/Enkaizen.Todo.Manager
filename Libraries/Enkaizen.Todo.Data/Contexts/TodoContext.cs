using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Enkaizen.Todo.Data.Entities;

namespace Enkaizen.Todo.Data.Contexts
{
    public class TodoContext : DbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyname;

        public TodoContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyname = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    _connectionString, b => b.MigrationsAssembly(_migrationAssemblyname)
                );
            }

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<TodoTask> Todos { get; set; }
    }
}
