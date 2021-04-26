using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enkaizen.Todo.Web.Models.TodoModels
{
    public class TodoIndexModel
    {
        private int TotalPages { get; set; }
        private int PageIndex { get; set; }
        public List<TodoViewModel> Todos { get; set; }

        public TodoIndexModel(List<TodoViewModel> Todos, int PageIndex, int PageSize, int TotalRecord)
        {
            this.Todos = Todos;
            this.PageIndex = PageIndex;

            TotalPages = (int)Math.Ceiling((double)TotalRecord / PageSize);
        }

        public bool PreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool NextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
    }
}
