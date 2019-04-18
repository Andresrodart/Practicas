const fs = require("fs");
const { remote } = require('electron');
const FILE_PORT = 10002;
const FILE_ADDR = "127.0.0.1";
const file_socket = dgram.createSocket({ type: "udp4", reuseAddr: true });
const input = document.getElementById('file-input');
var resivingFile = false;
var readStream;
var file = '';
file_socket.on("listening", function() {
	const address = file_socket.address();
	console.log(
		`UDP file socket listening on ${address.address}:${address.port}`
	);
});
file_socket.on("message", function(message, rinfo) {
	
	if (!resivingFile) {
		console.log(`Message from: ${rinfo.address}:${rinfo.port} - ${message.toString()}`);
		let theTextMess = message.toString();
		if (theTextMess == 'start_file_sending'){
			console.log(theTextMess);
			sendifile = true
			sendFile(file2sendPath);
		}else if(theTextMess == 'continue'){
			sendifile = true;
		}else if(theTextMess == 'sending'){
			resivingFile = true;
			const message = Buffer.from(`ok`);
			socket.send(message, 0, message.length, 10001, MULTICAST_ADDR, function() {
				console.info(`Sending message "${message}"`);
			});
		}	
	}else{
		console.log(`Message from: ${rinfo.address}:${rinfo.port} - ${message.length}`);
			resvFile(message);
	}
	
});
file_socket.on('error', (err) => {
	console.log(`server error:\n${err.stack}`);
	server.close();
});

file_socket.bind(FILE_PORT);

input.onchange = e => { 
	var file = e.target.files[0];
	let auxMessage = {
		'user':usrNAme,
		'mesg': path.basename(file.path),
		'to': chat_area_on,
		'file':true
	};
	let message = Buffer.from(`${JSON.stringify(auxMessage)}`);
	file_socket.send(message, 0, message.length, 10002, FILE_ADDR, function() {
		console.info(`Sending message "${message}" to 10002`);
	});
	file2sendPath = file.path;
	document.getElementById('sending_file').style.display = 'block';
};

function sendFile(filePath) {
	readStream = fs.createReadStream(filePath,{ highWaterMark: 65000 });
	readStream.on('data', (chunk) => {
		file_socket.send(chunk, 0, chunk.length, 10001, MULTICAST_ADDR, function() {
			console.info(`Sending message "${chunk.length}"`);
		});
		readStream.pause();
		setTimeout(() => {
			if (sendifile)
				readStream.resume();
		}, 1000);
		sendifile = false
	  });
	readStream.on('end', () => {
		console.log('There will be no more data.');
		let auxMessage = {
			'user':usrNAme,
			'mesg': path.basename(filePath),
			'to': chat_area_on,
			'file':true
		};
		messageCreatorSelfFile(auxMessage);
		let message = Buffer.from(`${JSON.stringify(auxMessage)}`);
		socket.send(message, 0, message.length, PORT, MULTICAST_ADDR, function() {
			console.info(`Sending message "${message}"`);
		});
		document.getElementById('sending_file').style.display = 'none';
	});
}

function resvFile(data) {
	fs.appendFile(file, data, (err) => {
		if (err) throw err;
		console.log('The "data to append" was appended to file!');
	  });
}

function downloadFile(fileName){
	file = path.join(remote.dialog.showOpenDialog({properties: ['openDirectory']})[0], path.basename(fileName));
	console.log(file);
	fs.open(file, 'w', function (err, file) {
		if (err) throw err;
		console.log('Saved!');
	});
	let auxMessage = {
		'user':usrNAme,
		'file': file
	};
	let message = Buffer.from(`${JSON.stringify(auxMessage)}`);
	socket.send(message, 0, message.length, 10002, FILE_ADDR, function() {
		console.info(`Sending message "${message}" to 10002`);
	});
}