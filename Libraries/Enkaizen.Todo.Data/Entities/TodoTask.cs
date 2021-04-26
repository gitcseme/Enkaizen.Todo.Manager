using Enkaizen.Todo.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Enkaizen.Todo.Data.Entities
{
    public class TodoTask : EntityBase<Guid>
    {
        [StringLength(100)]
        public string Description { get; set; }

        public bool IsDone { get; set; }

        public Guid CreatorId { get; set; }

        public Guid ModifierId { get; set; }
    }
}
