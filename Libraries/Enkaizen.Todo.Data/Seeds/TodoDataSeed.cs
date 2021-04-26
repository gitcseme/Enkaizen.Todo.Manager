using Enkaizen.Todo.Dal;
using Enkaizen.Todo.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enkaizen.Todo.Data.Seeds
{
    public class TodoDataSeed : DataSeed
    {
        public TodoDataSeed(TodoContext dbContext) : base(dbContext)
        {
        }

        public override Task SeedAsync()
        {
            throw new NotImplementedException();
        }
    }
}
