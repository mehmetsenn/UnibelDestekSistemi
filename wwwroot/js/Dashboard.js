window.onload = function (){

    var chartByGroup = new CanvasJS.Chart("chartByGroup", {
        animationEnabled: true,
        theme: "light2", // "light1", "light2", "dark1", "dark2"
        title: {
            text: "Unresolved Tickets By Group"
        },
        axisY: {
            title: "Tickets"
        },
        data: [{
            type: "column",
            dataPoints: [
                { y: 110, label: "Yazılım" },
                { y: 100, label: "Sistem Yönetim" },
                { y: 45, label: "Netsis Destek" },
                { y: 23, label: "Grafik/Web Tasarım" },
                { y: 66, label: "Teknik Servis" },
                { y: 32, label: "Web Editör" }
            ]
        }]
    });
    chartByGroup.render();

    var chartByStatus = new CanvasJS.Chart("chartByStatus", {
        animationEnabled: true,
        theme: "light2", // "light1", "light2", "dark1", "dark2"
        title: {
            text: "Unresolved Tickets By Status"
        },
        axisY: {
            title: "Tickets"
        },
        data: [{
            type: "column",
            dataPoints: [
                { y: 110, label: "Yazılım" },
                { y: 100, label: "Sistem Yönetim" },
                { y: 45, label: "Netsis Destek" },
                { y: 23, label: "Grafik/Web Tasarım" },
                { y: 66, label: "Teknik Servis" },
                { y: 32, label: "Web Editör" }
            ]
        }]
    });
    chartByStatus.render();

    var chartByPriority = new CanvasJS.Chart("chartByPriority", {
        animationEnabled: true,
        theme: "light2", // "light1", "light2", "dark1", "dark2"
        title: {
            text: "Unresolved Tickets By Priority"
        },
        axisY: {
            title: "Tickets"
        },
        data: [{
            type: "column",
            dataPoints: [
                { y: 110, label: "Yazılım" },
                { y: 100, label: "Sistem Yönetim" },
                { y: 45, label: "Netsis Destek" },
                { y: 23, label: "Grafik/Web Tasarım" },
                { y: 66, label: "Teknik Servis" },
                { y: 32, label: "Web Editör" }
            ]
        }]
    });
    chartByPriority.render();


    function afterValidation() {
        $("#changeEmailModal").click();
        $("#changeEmailTabButton").click();
    };

    function afterValidation2() {
        $("#changeEmailModal").click();
        //$("#changeEmailTabButton").click();
    };

    $(document).ready(function () {
        var tempdata = document.getElementById("errorMessage");
        if (tempdata.innerHTML != "") {
            afterValidation();
        }

        var tempdata2 = document.getElementById("errorMessagePassword")
        if (tempdata2.innerHTML != "") {
            afterValidation2();
        }
    });

}


//$("changeEmailButton").click(function () {

//    var Email = document.getElementById("existingEmailLabel");
//    var newEmail = document.getElementById("newEmailLabel");
//    var errorMessage = document.getElementById("errorMessage");
//    $.post("demo_test_post.asp",
//        {
//            Email: Email.value,
//            newEmail: newEmail.value
//        },
//        function (data, status) {
//            alert("Data: " + data + "\nStatus: " + status);
//            errorMessage.innerHTML = data;
//        });
//});

    

