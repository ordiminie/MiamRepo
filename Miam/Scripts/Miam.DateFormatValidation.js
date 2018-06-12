jQuery(document).ready(function () {

    // Modifie le format de la date compris comme valide par la validation jQuery
    $.validator.methods.date = function (value, element) {
        return this.optional(element) || $.datepicker.parseDate('dd/mm/yy', value);
    }
    
    // Affiche un datepicker + formate la date lors de la sélection
    $(".datepicker").datepicker({
        dateFormat: "dd/mm/yy"
        , changeMonth: true
        , changeYear: true
        , minDate : new Date(2018, 01, 01)        
    });

});