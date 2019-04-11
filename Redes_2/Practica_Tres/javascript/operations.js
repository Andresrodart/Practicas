var usrNAme = 'Elizabeth Bishop'

function fade(element, element2Unfade) {
    var op = 1;  // initial opacity
    var timer = setInterval(function () {
        if (op <= 0.1){
            clearInterval(timer);
			element.style.display = 'none';
			unfade(element2Unfade)
        }
        element.style.opacity = op;
        element.style.filter = 'alpha(opacity=' + op * 100 + ")";
        op -= op * 0.1;
    }, 50);
}

function unfade(element) {
	var op = 0.1;  // initial opacity
    element.style.display = 'block';
    var timer = setInterval(function () {
        if (op >= 1){
            clearInterval(timer);
        }
        element.style.opacity = op;
        element.style.filter = 'alpha(opacity=' + op * 100 + ")";
        op += op * 0.1;
    }, 10);
}

function ingresar(){
	document.getElementById('name').style.opacity = 0.1;
	fade(document.getElementById('ingresar'), document.getElementById('name'));
}
function checkName() {
	//Aquí checaremos que el nombre no este en uso, si todo cool mostramos la ventana de chat
	usrNAme = document.getElementById('usrName').value;
	document.getElementById('chat-area').style.opacity = 0.1;
	fade(document.getElementById('welcome'), document.getElementById('chat-area'));
}

function sendMessage() {
	//Mandar el mensaje por el protoolo UDP
	
}