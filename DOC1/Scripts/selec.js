




$(function () {

 
    if ($("#valotanq").length == 0) {
        var $myModal = $('#error');
        $myModal.modal('show');
    }
});

var res=0;
var nom = null;
$(function () {
    $('div.list-group a').click(function (e) {
         
        nom = $(this).find('.nombre').text();
        alert(nom);

        $("#resultado").val(parseInt(this.id));

        res = parseInt(this.id);
       
        var $this = $(this);
        $('.list-group').find('.active').removeClass('active');
        $this.addClass('active');
    });
});






               

var p = null;


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
                  
                  

                });

            } else {

                var $myModal = $('#DD');
               $myModal.modal('show');
            }

            
         
        }

    });

});


