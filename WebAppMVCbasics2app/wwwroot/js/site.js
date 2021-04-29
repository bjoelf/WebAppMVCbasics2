// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function deletePerson(element, event) {
    event.preventDefault();

    console.log(event);
    console.log(element);

    //Typiskt värde: https://localhost:44386/People/Delete/4
    //console.log(event.target.href);

    var deleteUrl = event.target.href;

    $.get(deleteUrl, function (data, status) {
        //alert("Data: " + data + "\nStatus: " + status);

        //deleteUrl = "https://localhost:44386/People/Delete/3"
        console.log(deleteUrl);

        //data = "Person_2"
        console.log(data);

        //Funkar hit!
        $("#" + data).remove();
    })

}