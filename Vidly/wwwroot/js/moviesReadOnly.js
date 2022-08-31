$(document).ready(function () {
    // Feed the table using API GET method

    $("#movies").DataTable({
        ajax: {
            url: "/api/movies",
            dataSrc: ""
        },
        columns: [
            {
                data: "title"
            },
            {
                data: "genre.name"
            },
        ]
    });
});