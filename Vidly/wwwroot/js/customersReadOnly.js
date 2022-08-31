$(document).ready(function () {
    // Feed the table using API GET method

    $("#customers").DataTable({
        ajax: {
            url: "/api/customers",
            dataSrc: ""
        },
        columns: [
            {
                data: "name"
            },
            {
                data: "membershipType.name"
            },
        ]
    });;
});