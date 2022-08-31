$(document).ready(function () {
    // Feed the table using API GET method

    let dataTable = $("#customers").DataTable({
        ajax: {
            url: "/api/customers",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, type, customer) {
                    return "<a href='/customers/edit/" + customer.id + "'>" + customer.name + "</a>";
                }
            },
            {
                data: "membershipType.name"
            },
            {
                data: "id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-customer-id=" + data + ">Delete</button>";
                }
            }
        ]
    });

    // When the user clicks the button, delete the customer using API DELETE method

    $("#customers").on("click", ".js-delete", function () {
        let deleteButton = $(this);
        if (confirm("Are you sure you want to delete this customer?")) {
            $.ajax({
                url: "api/customers/" + deleteButton.attr("data-customer-id"),
                method: "DELETE",
                success: function () {
                    dataTable.row(deleteButton.parents("tr")).remove().draw();
                }
            });
        }
    });
});