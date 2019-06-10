//*********************************************************************
// Displays notification message as a modal dialog 
//*********************************************************************
function notify(message, endFunction) {
    $("#NotifyMessage").text(message);

    $("#NotifyModal").off("hidden.bs.modal");
    if ((typeof endFunction !== "undefined") &&
        (endFunction != null)) {
        $("#NotifyModal").on("hidden.bs.modal", endFunction);
    }

    $("#NotifyModal").modal("show");
}