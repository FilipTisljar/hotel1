$(document).ready(function () { //počni s izvršavanjem kad se HTML dokument učita dokraja

    $("#id_soba").on('blur', jeRezervirano); //dodajemo event na element pod ID-om "id_soba"
    $("#rezerviranoDo").on('blur', jeRezervirano); // -- || --
    $("#rezerviranoOd").on('blur', jeRezervirano); // -- || --

    function jeRezervirano() { //metoda/funkcija koju zovemo na "blur" event

        var data = { //kreiramo objekt koji sadrži dole navedene vrijednosti "key" -> "value" ("idSoba": "$("#id_Soba").val())
            idSoba: $("#id_soba").val(), //"key" more biti točnog naziva kao i ActionResult parametar 
            rezervacijaOd: $("#rezerviranoOd").val(),
            rezervacijaDo: $("#rezerviranoDo").val()
        }

        if (data.idSoba > 0 && data.rezervacijaOd !== "" && data.rezervacijaDo !== "") {
            $.ajax({
                type: "POST",
                url: "/Rezervacije/JeRezervirano",
                data: JSON.stringify(data),
                contentType: "application/json",
                success: function (obavijest) { //kad ajax request uspješno pošalje podatke action-u i action to obrani i vrati nazad ajax-u, TEK ONDA se pokreće "success" key/property
                    $("#obavijest").html(obavijest); //dodajemo html tekst iz action-a u div sa ID-om "obavijest"
                    $("#obavijest").css("display", "block"); //prikazujemo div sa ID-om "obavijest"
                }
            });
        }

    }
});