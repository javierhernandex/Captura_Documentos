




$(function () {

 
    if ($("#valotanq").length == 0) {
        var $myModal = $('#error');
        $myModal.modal('show');
    }
});

var res = 0;
var tanq = null;
var nom = null;
var ltri = null;
var ltrf = null;
var gcf = null;
var hfi = null;


$(function () {
    $('div.list-group a').click(function (e) {
         
        nom = $(this).find('.nombre').text().trim();
        tanq = $(this).find('.VE_TANQ').text().trim();
        ltri = $(this).find('.VE_LTRI').text().trim();
        ltrf = $(this).find('.VE_LTRF').text().trim();
        gcf = $(this).find('.VE_GCF').text().trim();
        hfi = $(this).find('.VE_HFI').text().trim();

        $("#resultado").val(parseInt(this.id));

        res = parseInt(this.id);
       
        var $this = $(this);
        $('.list-group').find('.active').removeClass('active');
        $this.addClass('active');
    });
});






               

var p = null;
var m = "MAGNA";
var pre = "PREMIUN";
var clave = 07;
var sub1 = 1;
var sub2 = 2;
var tregma = "MA";
var tregdr = "DR";



$(function  () {
    $('#ddmodal').click(function () {
     
        p = document.getElementById("existe").value;

      

        if (res == 0) {
            var $myModal = $('#info');
            $myModal.modal('show');
        } else {
      
            if(p==0){
                var $myModal = $('#errorma');
                $myModal.modal('show');

                $('#cma').click(function () {
                $('#errorma').modal('hide');

                if (nom == m) {
                  
                    $('#nom').val(nom);
                    $('#tanq').val(tanq);
                    $('#clave').val(clave);
                    $('#sub').val(sub1);
                    $('#fhi').val(hfi);
                    $('#tregm').val(tregma);
                    $('#idc').val(res);

              

                } else {
                    $('#nom').val(nom);
                }
                  

                  

                });

            } else {

                var $myModal = $('#DD');
               $myModal.modal('show');
            }

            
         
        }

    });

});


