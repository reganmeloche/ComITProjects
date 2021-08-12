// Can remove body onload and replace with this
// Also needed to add the cdn script
$(document).ready(function(){
    console.log('Using JavaScript and JQuery');

    // populate tasks at the start
    getAllTasks();

    // handlers: Can use the 'on' or the 'click'
    $(".complete_button").on('click', function(e) {
        var taskId = $(e.target).data("taskid");
        console.log(`Completing Task ${taskId}`);
    });

    $(".delete_button").click(function(e) {
        var taskId = $(e.target).data("taskid");
        console.log(`Deleting Task ${taskId}`);
    });

    $("#new_task_form").submit(function(e) {
        var taskName = $("#task_name").val();
        var taskComplete = $("#task_complete").val();
        var newTask = {
            name: taskName,
            isComplete: taskComplete,
        };
        console.log(`Creating Task ${JSON.stringify(newTask)}`);
        alert('Task created');
    });
});

function getAllTasks() {
    // Changed this to use jquery
    var table = $("#task_table");

    for (var i = 0; i < tasks.length; i++) {  
        var task = tasks[i];
        var tableRow = buildTableRow(task);
        table.append(tableRow);    
    }
}

// Nothing changes here
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

// Add the classes and the data attributes
function buildCompleteButton(taskId) {
    return `<button class="complete_button" data-taskid="${taskId}">Complete</button>`;
}

// Could still just call the function with the arg if we want. Show both ways
function buildDeleteButton(taskId) {
    return `<button class="delete_button" data-taskid="${taskId}">Delete</button>`;
}

var tasks = [
    {
        id: 1,
        name: "Walk the dog",
        isComplete: true
    },
    {
        id: 2,
        name: "Bake cookies",
        isComplete: false
    }
];
