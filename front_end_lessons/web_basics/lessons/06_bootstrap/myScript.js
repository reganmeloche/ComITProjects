// Server url
const url = 'https://localhost:5001/api/TodoItems';

$(document).ready(function(){
    console.log('Bootstrap');

    getAllTasks();

    $("#new_task_form").submit(function(e) {
        e.preventDefault();
        var taskName = $("#task_name").val();
        var taskComplete = $("#task_complete").val();
        var newTask = {
            name: taskName,
            isComplete: (taskComplete == "true"),
        };
        console.log(`Creating Task ${JSON.stringify(newTask)}`);
        
        $.ajax({ 
            url: url, 
            method: 'POST',
            headers: { 
                'Accept': 'application/json',
                'Content-Type': 'application/json' 
            },
            data: JSON.stringify(newTask)
        }).then(function() {
             window.location.href = './index.html';
        });
    });
});

function bindHandlers() {
    $(".complete_button").on('click', function(e) {
        var taskId = $(e.target).data("taskid");
        console.log(`Completing Task ${taskId}`);

        $.ajax({ 
            url: `${url}/${taskId}/complete`, 
            method: 'PUT',
        }).then(function() {
             window.location.reload();
        });
    });

    $(".delete_button").click(function(e) {
        var taskId = $(e.target).data("taskid");
        console.log(`Deleting Task ${taskId}`);

        $.ajax({ url: `${url}/${taskId}`, method: 'DELETE'})
            .then(function() {
                window.location.reload();
            });
    });
}

function getAllTasks() {
    $.get(url, function(tasks) {
        var table = $("#task_table");

        for (var i = 0; i < tasks.length; i++) {  
            var task = tasks[i];
            var tableRow = buildTableRow(task);
            table.append(tableRow);    
        }

        bindHandlers();
    });
}


function buildTableRow(task) {
    var nextRow = document.createElement('tr');

    // name cell
    var nameCell = document.createElement('td');
    var nameText = document.createTextNode(task.name);
    nameCell.append(nameText);
    nextRow.append(nameCell);

    // isCompleteCell
    var completedCell = document.createElement('td');
    var completedText = document.createTextNode(task.isComplete);
    completedCell.append(completedText);
    nextRow.append(completedCell);

    // complete cell
    var completeCell = document.createElement('td');
    if (!task.isComplete) {
        var completeButton = buildCompleteButton(task.id);
        completeCell.innerHTML = completeButton;
    }
    nextRow.append(completeCell);

    // delete cell
    var deleteCell = document.createElement('td');
    var deleteButton = buildDeleteButton(task.id);
    deleteCell.innerHTML = deleteButton;
    nextRow.append(deleteCell);

    return nextRow;
}

function buildCompleteButton(taskId) {
    return `<button class="btn btn-success btn-sm complete_button" data-taskid="${taskId}">Complete</button>`;
}

function buildDeleteButton(taskId) {
    return `<button class="btn btn-danger btn-sm delete_button" data-taskid="${taskId}">Delete</button>`;
}
