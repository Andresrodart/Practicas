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
	messageCreator();
	document.getElementById('usrMessage').value = '';

}

function privateMs() {
	console.log('ejecutar mandar mensaje privado')
}

function messageCreator(message) {
	let nodeMes = document.createElement("div");
	let nodeMesName = document.createElement("div");
	let nodeMesText = document.createElement("div");
	let name;
	let mesg;

	nodeMes.classList.add("message");                					// Create a <div> node
	nodeMesName.classList.add("name");
	nodeMesText.classList.add("text");
	if (message == null){ 
		name = document.createTextNode(usrNAme);
		mesg = document.createTextNode(document.getElementById('usrMessage').value);
		nodeMes.classList.add("self");
		
	}else{
		
	}
	nodeMesName.appendChild(name);
	nodeMesText.appendChild(mesg);
	nodeMes.appendChild(nodeMesName);
	nodeMes.appendChild(nodeMesText);
	document.getElementById('messagess-area').appendChild(nodeMes);
}