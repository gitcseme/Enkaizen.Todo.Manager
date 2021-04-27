using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Enkaizen.Todo.Web.Models.TodoModels
{
    public class TodoCreateViewModel
    {
        [StringLength(100), Required]
        public string Description { get; set; }
    }
}
