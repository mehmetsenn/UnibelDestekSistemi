const inputName = document.getElementById('customer-profile-name');
const inputCompany = document.getElementById('customer-profile-company');
const inputTitle = document.getElementById('customer-profile-title');
const inputPhone = document.getElementById('customer-profile-phone');
const inputEmail = document.getElementById('customer-profile-email');
const customerProfileButton = document.querySelector('#customer-submit');


$('#submitBtn').click(function () {
$('#customer-profile-tablename').text($('#customer-profile-name').val());
$('#customer-profile-tablecompany').text($('#customer-profile-company').val());
$('#customer-profile-tableTitle').text($('#customer-profile-title').val());
$('#customer-profile-tablephone').text($('#customer-profile-phone').val());
$('#customer-profile-table-mail').text($('#customer-profile-email').val());
});


$('#submit').click(function () {
  alert('İşleminiz Başarılı');
  $('#customer-profile-form').submit();
});



// Datatable//

$(document).ready(function () {
    $(document).ready(function () {

        $('#customer-datatable').DataTable({
            ajax: {
                url: '/Den',
                type: 'POST',
                dataSrc: ''
            },

            columns: [
                { data: "BiletId" },
                { data: "CalisanKullaniciKullaniciAdi" },
                { data: "BiletBasligi" },
                { data: "BiletGonderimTarihi" },
                { data: "BiletKapanisTarihi" },
                { data: "BiletDepartmanDepartmanAdi" },
                { data: "SirketSirketAdi" },
                { data: "BiletTurTipAdi" },
                { data: "OncelikOncelikAdi" }
            ]

        });
    });

    $(document).ready(function () {
        var table = $('#customer-datatable').DataTable();

        $('#customer-datatable tbody').on('click', 'tr', function () {
            var data = table.row(this).data();
            console.log('You clicked on ' + data.BiletId + '\'s row');
            var ticketId = data.BiletId;
            window.location.href = '/showTicket/' + ticketId;
        });
    });
});

//Datatable