﻿(function () {
    document.addEventListener("keyup", keyUp, false); // attach keyup event to the document
    function keyUp(e) {
        var keyCode = e.keyCode;
        if (keyCode == 38) {
            getMatrix(1);
           // alert("Up");
        }
        else if (keyCode == 39) {
            getMatrix(2);
            //alert("Right");
        }
        else if (keyCode == 40) {
            getMatrix(3);
            //alert("Down");
        }
        else if (keyCode == 37) {
            getMatrix(4);
            //alert("Left");
        }

    }


    function getMatrix(direction) {
        var xmlhttp = null;

        if (window.XMLHttpRequest) {
            xmlhttp = new window.XMLHttpRequest(); //to interact with server
        }
        else if (window.ActiveXObject) {
            xmlhttp = new window.ActiveXObject("Microsoft.XMLHTTP");//for older versions,that don't support xmlhttpobject
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
                var game = JSON.parse(responseText);
                var matrix = game.Matrix;

                
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
                //alert(matrix[0][0]);

                score = document.getElementById("score");
                score.innerHTML = "Score:" + game.Score;

                result = document.getElementById("result");
                result.innerHTML = "Max Result:" + game.Result;

                gameStatus = document.getElementById("gameStatus");
                if (game.hasBeenWon === true) {
                    gameStatus.innerHTML = "You Won";
                } else if (game.isGameOver === true) {
                    gameStatus.innerHTML = "Game Over";
                } else {}

            }
        }
    }

    //alert("Hello World!");

    


})();