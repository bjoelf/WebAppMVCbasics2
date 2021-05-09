


function closeDetailsPerson(id, event) {
    event.preventDefault();

    var endDetailsUrl = event.target.href;

    $.post(endDetailsUrl, { id: id },
        function (data, status) {
            console.log("Data: " + data + "\nStatus: " + status);
            $("#person" + id).replaceWith(data);
        }
    );
}

function detailsPerson(id, event) {
    event.preventDefault();

    var detailsUrl = event.target.href;
    $.post(detailsUrl, { id: id },

        //Motsvarar i Contollern: 
        //return PartialView("_PeopleDetailsTableRow", person);
        function (data, status) {
            console.log("Data: " + data + "\nStatus: " + status);

            //Det funkade men behöver snyggas till en smula...
            $("#person" + id).replaceWith(data);
        }
    );
}

function deletePerson(element, event) {
    event.preventDefault();

    console.log(event);
    console.log(element);

    //Typiskt värde: https://localhost:44386/People/Delete/4
    //console.log(event.target.href);

    var deleteUrl = event.target.href;

    //här snackas det med controllern och variabeln data håller returvärdet från controllern!
    //function är ett generiskt uttryck för metoden anropet skickas till!
    $.get(deleteUrl, function (data, status) {
        alert("Data: " + data + "\nStatus: " + status);

        //deleteUrl = "https://localhost:44386/People/Delete/3"
        console.log(deleteUrl);

        //data = "person2" Det motsvarar id på det element som skall bort.
        //Skumt att backend och frontend liksom jobbar parallellt.
        console.log(data);

        //Här blir strängen #person2 vilket är "css style" adressering av elementet
        $("#" + data).remove();
    })
}

