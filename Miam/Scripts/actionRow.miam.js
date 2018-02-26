
/*
    Ajoute une action en jQuery sur une ligne
*/

$(".action").click(function (e) {
    window.location.href = "/"
        + $(this).attr("controllerName")
        + "/" + $(this).attr("actionName")
        + "/" + $(this).attr("elementId");
});