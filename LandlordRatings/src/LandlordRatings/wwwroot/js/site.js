// Write your Javascript code.

function toggler(divID) {
    if (divID === "alphabet") {
        if ($("#citystate").is(":visible")) {
            $("#citystate").hide();
        }
    } else if (divID === "citystate") {
        if ($("#alphabet").is(":visible")) {
            $("#alphabet").hide();
        }
    }
    $("#" + divID).toggle();
}