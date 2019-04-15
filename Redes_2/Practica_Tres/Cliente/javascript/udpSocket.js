const dgram = require("dgram");
const PORT = 10000;
const MULTICAST_ADDR = "224.3.29.71";
const socket = dgram.createSocket({ type: "udp4", reuseAddr: true });
var newMesg = {};

socket.on("listening", function() {
	socket.addMembership(MULTICAST_ADDR);
	const address = socket.address();
	console.log(
		`UDP socket listening on ${address.address}:${address.port}`
		);
});
	
socket.on("message", function(message, rinfo) {
	console.log(`Message from: ${rinfo.address}:${rinfo.port} - ${message.toString('utf8')}`);
	newMesg = JSON.parse(message.toString('utf8'));
	messageCreator(newMesg);
});
	
socket.on('error', (err) => {
	console.log(`server error:\n${err.stack}`);
	server.close();
});

function sendMessage() {
	let auxMessage = {
		'user':usrNAme,
		'mesg': document.getElementById('usrMessage').value
	};
	const message = Buffer.from(`${JSON.stringify(auxMessage)}`);
	socket.send(message, 0, message.length, PORT, MULTICAST_ADDR, function() {
		console.info(`Sending message "${message}"`);
	});
	messageCreator();
	document.getElementById('usrMessage').value = '';

}

socket.bind(PORT);