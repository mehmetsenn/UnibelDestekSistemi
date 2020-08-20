var dataTableBenimTaleplerim;
var dataTableTumTalepler;
var dataTableGonderilenTaleplerim;
var dataTableIptalTaleplerim;
var dataTableCozulenTaleplerim;

$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})
function openNav() {
    document.getElementById("mySidenav").style.width = "295px";
}

function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
}



$(document).ready(function ()
 {
    var width = (window.innerWidth > 0) ? window.innerWidth : screen.width;
    var solMenu = document.getElementById("leftNav");
    if (width < 768) {
        solMenu.classList.remove("solMenu");
        solMenu.classList.add("solMenuMobil");  
    }

    else
    {
        solMenu.classList.remove("solMenuMobil");
        solMenu.classList.add("solMenu");
    }

 }
);

function toggleLeftMenu() {

    var leftNav = document.getElementById("leftNav");
    

    if (leftNav.classList.contains("solMenuMobil")) {
        
        $("body").toggleClass("acikMobil");
    }
    else {
        
        $("body").toggleClass("acik");
    }
   

    

}

function toggleReplyTicket() {
    $("#replyTicketDiv").toggleClass("replyTicket");
}

function toggleMultipleOwnersTicket() {
    $("#addMultipleOwnersToTicketDiv").toggleClass("multipleOwners");
}

function profileSettingsTabToggle(tab) {

    var tabcontent;
    var passwordDiv = document.getElementById("passwordSettingsDiv");
    var assignedDepartmentsDiv = document.getElementById("assignedDepartmentsDiv");
    var s = "";

    s += tab;
    if (s.localeCompare('password') == 0) {
        passwordDiv.classList.remove("tabKapali");
        assignedDepartmentsDiv.classList.add("tabKapali");
    }
    else {
        passwordDiv.classList.add("tabKapali");
        assignedDepartmentsDiv.classList.remove("tabKapali");
    }

}

function modalTriggerEvent() {

    var modalTrigger = document.getElementById("addStaffToggler");
    

}


function denemeFunction()
{
    var newPasswordLabel = document.getElementById("newPasswordLabel");
    var repeatPasswordLabel = document.getElementById("repeatPasswordLabel");

    var uyariKarakterUzunlugu = document.getElementById("uyariKarakterUzunlugu");
    var uyariSifreEslesme = document.getElementById("uyariSifreEslesme");

    var newPassword = newPasswordLabel.value;
    var repeatPassword = repeatPasswordLabel.value;

    var newPasswordLength = newPassword.length;
    var newPasswordRepeatLength = repeatPassword.length;

    if (newPassword.localeCompare(repeatPassword) == 0) {

        uyariSifreEslesme.style.display = 'none';
        
    }
    else {
        uyariSifreEslesme.style.display = 'block';
    }
    
    function openNav() {
        document.getElementById("mySidenav").style.width = "250px";
    }

    /* Set the width of the side navigation to 0 */
    function closeNav() {
        document.getElementById("mySidenav").style.width = "0";
    }
    
    /*
    if (newPasswordLength <) {
        alert();
    }
    alert("" + newPassword.length);
    document.getElementById("form").submit;*/
}


// Load the Visualization API and the corechart package.
/*google.charts.load('current', { 'packages': ['corechart'] });

// Set a callback to run when the Google Visualization API is loaded.
google.charts.setOnLoadCallback(

    function() {//Burada chartlar yüklendikten sonra çalıştırılacak fonksiyonları çağırabiliriz.
        drawChart();
    }

);*/

// Callback that creates and populates a data table,
// instantiates the pie chart, passes in the data and
// draws it.
/*function drawChart() {

    // Create the data table.
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Topping');
    data.addColumn('number', 'Slices');
    data.addRows([
        ['Yazılım Grubu', 72],
        ['Grafik Web Tasarım', 2],
        ['Teknik Servis', 18],
        ['Web Editör', 6],
        ['Sistem Yönetim Grubu', 10],
        ['Saha Ekibi',40]
    ]);

    // Set chart options
    var options = {
        'title': 'Bekleyen İşler',
        'width': '10%',
        'height': '300px'
        
    };

    // Instantiate and draw our chart, passing in some options.
    var chart = new google.visualization.PieChart(document.getElementById('chart_div'));
    chart.draw(data, options);
}




$(window).resize(function () {
    drawChart();
});*/
var options = {

    data: ["blue", "green", "pink", "red", "yellow", "blue", "green", "pink", "red", "blue", "green", "pink", "red", "blue", "green", "pink", "red", "blue", "green", "pink", "red", "blue", "green", "pink", "red", "blue", "green", "pink", "red", "blue", "green", "pink", "red", "blue", "green", "pink", "red", "blue", "green", "pink", "red", "blue", "green", "pink", "red", "blue", "green", "pink", "red"],

    list: {
        match: {
            enabled: true
        }
    },

    //theme: "square"
};

$("#countries").easyAutocomplete(options);

dataTableBenimTaleplerim = $('#table_taleplerim').DataTable({
    "language": {
        "emptyTable": "SONUÇ BULUNAMADI"
    },

    "responsive": true,
    "columns": [
        {
            "data": "id",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.id + "</a>");
            }
        },
        {
            "data": "date",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.date + "</a>");
            }
        },

        {
            "data": "subject",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.subject + "</a>");
            }
        },
        {
            "data": "company",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.company + "</a>");
            }
        },
        {
            "data": "priority",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.priority + "</a>");
            }
        },
        {
            "data": "owner",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.owner + "</a>");
            }
        },
        {
            "data": "due",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.due + "</a>");
            }
        }
    ],

    "rowCallback": function (row, data, index) {
        if (data[2] == "Dusuk") {
            $('td', row).css('background-color', 'Red');
        }
        else if (data[2] == "Dusuk") {
            $('td', row).css('background-color', 'Orange');
        }
    }
});

dataTableTumTalepler = $('#table_tumTalepler').DataTable({
    "language": {
        "emptyTable": "SONUÇ BULUNAMADI"
    },

    "responsive": true,
    "columns": [
        {
            "data": "id",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.id + "</a>");
            }
        },
        {
            "data": "date",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.date + "</a>");
            }
        },

        {
            "data": "subject",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.subject + "</a>");
            }
        },
        {
            "data": "company",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.company + "</a>");
            }
        },
        {
            "data": "priority",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.priority + "</a>");
            }
        },
        {
            "data": "owner",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.owner + "</a>");
            }
        },
        {
            "data": "due",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.due + "</a>");
            }
        }
    ],

    "rowCallback": function (row, data, index) {
        if (data[2] == "Dusuk") {
            $('td', row).css('background-color', 'Red');
        }
        else if (data[2] == "Dusuk") {
            $('td', row).css('background-color', 'Orange');
        }
    }
});

dataTableGonderilenTaleplerim = $('#table_gonderilenTaleplerim').DataTable({
    "language": {
        "emptyTable": "SONUÇ BULUNAMADI"
    },

    "responsive": true,
    "columns": [
        {
            "data": "id",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.id + "</a>");
            }
        },
        {
            "data": "date",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.date + "</a>");
            }
        },

        {
            "data": "subject",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.subject + "</a>");
            }
        },
        {
            "data": "company",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.company + "</a>");
            }
        },
        {
            "data": "priority",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.priority + "</a>");
            }
        },
        {
            "data": "owner",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.owner + "</a>");
            }
        },
        {
            "data": "due",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.due + "</a>");
            }
        }
    ],

    "rowCallback": function (row, data, index) {
        if (data[2] == "Dusuk") {
            $('td', row).css('background-color', 'Red');
        }
        else if (data[2] == "Dusuk") {
            $('td', row).css('background-color', 'Orange');
        }
    }
});

dataTableIptalTaleplerim = $('#table_iptalTaleplerim').DataTable({
    "language": {
        "emptyTable": "SONUÇ BULUNAMADI"
    },

    "responsive": true,
    "columns": [
        {
            "data": "id",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.id + "</a>");
            }
        },
        {
            "data": "date",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.date + "</a>");
            }
        },

        {
            "data": "subject",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.subject + "</a>");
            }
        },
        {
            "data": "company",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.company + "</a>");
            }
        },
        {
            "data": "priority",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.priority + "</a>");
            }
        },
        {
            "data": "owner",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.owner + "</a>");
            }
        },
        {
            "data": "due",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.due + "</a>");
            }
        }
    ],

    "rowCallback": function (row, data, index) {
        if (data[2] == "Dusuk") {
            $('td', row).css('background-color', 'Red');
        }
        else if (data[2] == "Dusuk") {
            $('td', row).css('background-color', 'Orange');
        }
    }
});

dataTableCozulenTaleplerim = $('#table_cozulenTaleplerim').DataTable({
    "language": {
        "emptyTable": "SONUÇ BULUNAMADI"
    },

    "responsive": true,
    "columns": [
        {
            "data": "id",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.id + "</a>");
            }
        },
        {
            "data": "date",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.date + "</a>");
            }
        },

        {
            "data": "subject",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.subject + "</a>");
            }
        },
        {
            "data": "company",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.company + "</a>");
            }
        },
        {
            "data": "priority",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.priority + "</a>");
            }
        },
        {
            "data": "owner",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.owner + "</a>");
            }
        },
        {
            "data": "due",
            "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.due + "</a>");
            }
        }
    ],

    "rowCallback": function (row, data, index) {
        if (data[2] == "Dusuk") {
            $('td', row).css('background-color', 'Red');
        }
        else if (data[2] == "Dusuk") {
            $('td', row).css('background-color', 'Orange');
        }
    }
});