(function () {
    document.addEventListener("keyup", keyUp, false);
    function keyUp(e) {
        var keyCode = e.keyCode;
        if (keyCode == 38) {
            var xmlhttp = null;

            if (window.XMLHttpRequest) {
                xmlhttp = new window.XMLHttpRequest();
            }
            else if (window.ActiveXObject) {
                xmlhttp = new window.ActiveXObject("Microsoft.XMLHTTP");
            }
            else {
                alert("I'm sorry ! Your browser does not support XHR");
            }

            xmlhttp.open("GET", "http://localhost:58823/api/Game/Index?id=2", true);
            xmlhttp.setRequestHeader("Accept", "application/json");
            xmlhttp.send();
            xmlhttp.onreadystatechange = function (e) {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200)
                {
                    var responseText = xmlhttp.responseText;
                    var responseXML = xmlhttp.responseXML;
                    var matrix = JSON.parse(responseText);

                    //var element = document.getElementById("cell_0_0");
                    //element.innerHTML = matrix[0][0];

                    for (var i = 0; i < 4; i++) {
                        for (var j = 0; j < 4; j++) {
                            
                            element = document.getElementById("cell_" + i + "_" + j);

                            if (matrix[i][j] != 0) {
                                element.innerHTML = Math.round(matrix[i][j], 0);
                            }
                            else {
                                element.innerHTML = "&nbsp;";
                            }  
                        }
                    }
                    alert(matrix[0][0]);
                }
            }
            alert("Up");
        }
        else if (keyCode == 39) {
            alert("Right");
        }
        else if (keyCode == 40) {
            alert("Down");
        }
        else if (keyCode == 37) {
            alert("Left");
        }
    }


    function getMatrix(direction) {
        var xmlhttp = null;

        if (window.XMLHttpRequest) {
            xmlhttp = new window.XMLHttpRequest();
        }
        else if (window.ActiveXObject) {
            xmlhttp = new window.ActiveXObject("Microsoft.XMLHTTP");
        }
        else {
            alert("I'm sorry ! Your browser does not support XHR");
        }

        xmlhttp.open("GET", "http://localhost:58823/api/Game/Index?id=" + direction, true);
        xmlhttp.setRequestHeader("Accept", "application/json");
        xmlhttp.send();
        xmlhttp.onreadystatechange = function (e) {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                var responseText = xmlhttp.responseText;
                var responseXML = xmlhttp.responseXML;
                var matrix = JSON.parse(responseText);

                //var element = document.getElementById("cell_0_0");
                //element.innerHTML = matrix[0][0];

                for (var i = 0; i < 4; i++) {
                    for (var j = 0; j < 4; j++) {

                        element = document.getElementById("cell_" + i + "_" + j);

                        if (matrix[i][j] != 0) {
                            element.innerHTML = Math.round(matrix[i][j], 0);
                        }
                        else {
                            element.innerHTML = "&nbsp;";
                        }
                    }
                }
                alert(matrix[0][0]);
            }
        }
    }

    alert("Hello World!");

})();