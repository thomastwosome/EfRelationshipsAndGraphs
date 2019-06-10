//*********************************************************************
// Displays a confirmation message modal dialog.  If 'Yes' is
// clicked, the callback function will be executed.
//*********************************************************************
function confirm(title, message, callback) {
    var confirmEvent = null;
    var confirmYes = false;

    $("#ConfirmModal").off("hidden.bs.modal", OnConfirmModalHidden);
    $("#ConfirmModal").on("hidden.bs.modal", OnConfirmModalHidden)

    $("#ConfirmAccept").off("click", ConfirmAccept);
    $("#ConfirmAccept").on("click", ConfirmAccept);

    $("#ConfirmTitle").text(title === null ? "" : title);
    $("#ConfirmMessage").html(message === null ? "" : message);
    $("#ConfirmModal").modal("show");

    function OnConfirmModalHidden(event) {
        event.stopPropagation();
        event.preventDefault();

        $("#ConfirmAccept").off("click", ConfirmAccept);
        $("#ConfirmModal").off("hidden.bs.modal", OnConfirmModalHidden);

        if ((confirmYes) &&
            (typeof (callback) != "undefined") &&
            (callback !== null)) {
            callback(confirmEvent);
        }

        confirmYes = false;
    }

    function ConfirmAccept(event) {
        event.stopPropagation();
        event.preventDefault();

        $("#ConfirmAccept").off("click", ConfirmAccept);

        confirmEvent = event;
        confirmYes = true;

        $("#ConfirmModal").modal("hide");
    }
}