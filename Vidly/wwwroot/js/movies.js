$(document).ready(function () {
    // Feed the table using API GET method

    let dataTable = $("#movies").DataTable({
        ajax: {
            url: "/api/movies",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, type, movie) {
                    return "<a href='/movies/edit/" + movie.id + "'>" + movie.title + "</a>";
                }
            },
            {
                data: "genre.name"
            },
            {
                data: "id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-movie-id='" + data + "'>Delete</button>";
                }
            }
        ]
    });

    // When the user clicks the button, delete the movie using API DELETE method

    $("#movies").on("click", ".js-delete", function () {
        let deleteButton = $(this);
        if (confirm("Are you sure you want to delete this movie?")) {
            $.ajax({
                url: "/api/movies/" + deleteButton.attr("data-movie-id"),
                method: "DELETE",
                success: function () {
                    dataTable.row(deleteButton.parents("tr")).remove().draw();
                }
            });
        }
    })
})