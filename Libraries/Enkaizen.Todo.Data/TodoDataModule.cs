using Autofac;
using Enkaizen.Todo.Data.Contexts;
using Enkaizen.Todo.Data.Repositories;
using Enkaizen.Todo.Data.Seeds;
using Enkaizen.Todo.Data.Services;
using Enkaizen.Todo.Data.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enkaizen.Todo.Data
{
    public class TodoDataModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public TodoDataModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TodoContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<TodoRepository>()
                .As<ITodoRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TodoUnitOfWork>()
                .As<ITodoUnitOfWork>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<TodoService>()
                .As<ITodoService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TodoDataSeed>().SingleInstance();

            base.Load(builder);
        }
    }
}
