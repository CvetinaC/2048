//$('body').keypress(function (e) {
//    $.post("index.asp",
//        {
//            submit = String.fromCharCode(e.which)
//        },
//        function (data, status) {
//            alert("Data: " + data + "\nStatus: " + status);
//        });
//});
$("window").keydown(function () {
    alert("Handler for .keydown() called.");
});