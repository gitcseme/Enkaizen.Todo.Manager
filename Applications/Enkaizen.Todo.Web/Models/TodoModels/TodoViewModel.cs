using System;

namespace Enkaizen.Todo.Web.Models.TodoModels
{
    public class TodoViewModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string CreationDate { get; set; }
        public bool IsDone { get; set; }
        public string EditedBy { get; set; }
        public string Creator { get; set; }
    }
}