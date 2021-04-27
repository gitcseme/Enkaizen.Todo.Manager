function DeleteTodo(btn, todoId) {
    let todoItem = $(btn).parent().parent();

    $.ajax({
        url: '/Todos/Delete',
        type: 'POST',
        dataType: 'text',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: { todoId: todoId },
        success: function (response) {
            todoItem.remove();
        },
        error: function (data, status, xhr) {
            console.log(status);
        }
    })
}

