using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enkaizen.Todo.Dal
{
    public interface Iseed
    {
        Task MigrateAsync();
        Task SeedAsync();
    }
}
