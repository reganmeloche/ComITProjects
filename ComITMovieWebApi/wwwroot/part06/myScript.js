function loadMovies() {
    console.log("Loading movies!");
    
    $.get('../Movie', function(movies) {
        var table = $("#movie-table");
        console.log(movies);

        for (var i = 0; i < movies.length; i++) {  
            var movie = movies[i];
            var tableRow = buildTableRow(movie);
            table.append(tableRow);    
        }
    });

}

function buildTableRow(movie) {
    var nextRow = document.createElement('tr');

    var cell1 = document.createElement('td');
    var text1 = document.createTextNode(movie.title);
    cell1.append(text1);
    nextRow.append(cell1);

    var cell2 = document.createElement('td');
    var text2 = document.createTextNode(movie.director);
    cell2.append(text2);
    nextRow.append(cell2);

    var cell3 = document.createElement('td');
    var text3 = document.createTextNode(movie.year);
    cell3.append(text3);
    nextRow.append(cell3);

    //delete cell
    var deleteCell = document.createElement('td');
    var deleteButton = buildDeleteButton(movie.id);
    deleteCell.innerHTML = deleteButton;
    nextRow.append(deleteCell);

    return nextRow;
}

function buildDeleteButton(movieId) {
    return `<button class="btn btn-danger btn-sm" onclick="deleteMovie('${movieId}');">Delete</button>`;
}

function submitNewMovie(e) {
    e.preventDefault();
    var movieTitle = $("#movie-title").val();
    var movieDirector = $("#movie-director").val();
    var movieYear = $("#movie-year").val();
    var newMovie = {
        title: movieTitle,
        director: movieDirector,
        year: parseInt(movieYear)
    };
    
    $.ajax({ 
        url: '../Movie', 
        method: 'POST',
        headers: { 
            'Accept': 'application/json',
            'Content-Type': 'application/json' 
        },
        data: JSON.stringify(newMovie)
    }).then(function() {
        window.location.reload();
    });
}

function deleteMovie(movieId) {
    $.ajax({ url: `../Movie/${movieId}`, method: 'DELETE'})
        .then(function() {
            window.location.reload();
        });
}