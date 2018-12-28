




$(function () {

 
    if ($("#valotanq").length == 0) {
        var $myModal = $('#error');
        $myModal.modal('show');
    }
});

var res = 0;
var VE_TANQ = null;
var nom = null;
var ltri = null;
var ltrf = null;
var gcf = null;
var hfi = null;
var VE_AUM = null;
var VE_FOLR = null;
var clave = null;
var sub = null;
var cocgas = null;
var gasetn = null;
var cetngas = null;
var otros = null;
var marca = null;

$(function () {
    $('div.list-group a').click(function (e) {
       
        $("#resultado").val(parseInt(this.id));
        res = parseInt(this.id);

        nom = $(this).find('.nombre').text().trim();


        VE_TANQ = document.getElementById(res + "VE_TANQ").value;
        ltri = document.getElementById(res + "VE_LTRI").value;
        ltrf = document.getElementById(res + "VE_LTRF").value;
        VE_AUM = document.getElementById(res + "VE_AUM").value;
        gcf = document.getElementById(res + "VE_GCF").value;
        hfi = document.getElementById(res + "VE_HFI").value;
        clave = document.getElementById(res + "V_clvepro").value;
        sub = document.getElementById(res + "V_clvsubpro").value;
        cocgas = document.getElementById(res + "V_CocGas").value;
        gasetn = document.getElementById(res + "V_GasEtn").value;
        cetngas = document.getElementById(res + "V_CetnGas").value;
        otros = document.getElementById(res + "V_Otros").value;
        marca =document.getElementById(res + "V_Marca").value;
        VE_FOLR = document.getElementById(res + "VE_FOLR").value;
       
        
        var $this = $(this);
        $('.list-group').find('.active').removeClass('active');
        $this.addClass('active');
    });
});            

var p = null;

var tregma = "MA";
var tregdr = "DR";
var tregdD = "DD";
var documen = 1;

$(function  () {
    $('#ddmodal').click(function () {
     
        // p = document.getElementById("existe").value;

        if (res == 0) {
            var $myModal = $('#info');
            $myModal.modal('show');
        } else {

            if (VE_FOLR == 0) {
                
             
                    //MA
             
                $('#producto').val(clave);
                $('#clave').val(clave);
                $('#subproducto').val(sub);
                $('#cocgas').val(cocgas);
                $('#gasetn').val(gasetn);
                $('#cengas').val(cetngas);
                $('#otros').val(otros);
                $('#marca').val(marca);
                $('#docu').val(documen);
                $('#FOLR').val(VE_FOLR);
                $('#TREDD').val(tregdD);
             
                //DR
                $('#TANQUE').val(VE_TANQ);
                $('#ltri').val(ltri);
                $('#ltrf').val(ltrf);
                $('#aum').val(VE_AUM);
                $('#gcf').val(gcf);
                $('#hfi').val(hfi);
                $('#idc').val(res);

           



                    var $mymodal=$('#DD');
                     $mymodal.modal('show');

                    

        


            } else {
                $('#FOLR').val(VE_FOLR);
                $('#TREDD').val(tregdD);
                var $myModal = $('#DD');
                $myModal.modal('show');

            }

        }







    });

});

