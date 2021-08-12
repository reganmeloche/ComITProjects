console.log('Using Vanilla JS');

// Complete a task
function completeTask(taskId) {
    console.log(`Completing Task ${taskId}`);
}

// Delete a task
function deleteTask(taskId) {
    console.log(`Deleting Task ${taskId}`);
}

// Submit a new task
function createTask() {
    var taskName = document.getElementById("task_name").value;
    var taskComplete = document.getElementById("task_complete").value;
    var newTask = {
        name: taskName,
        isComplete: taskComplete,
    };
    console.log(`Creating Task ${JSON.stringify(newTask)}`);
    alert('Task created');
}

// Populate the table with the tasks
function loadTasks() {
    var table = document.getElementById("task_table");

    for (var i = 0; i < tasks.length; i++) {  
        var task = tasks[i];
        var tableRow = buildTableRow(task);
        table.append(tableRow);    
    }
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

// Two ways of building: building pure html from text or create element
function buildCompleteButton(taskId) {
    return `<button onclick="completeTask(${taskId})">Complete</button>`;
}

function buildDeleteButton(taskId) {
    return `<button onclick="deleteTask(${taskId})">Delete</button>`;
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
