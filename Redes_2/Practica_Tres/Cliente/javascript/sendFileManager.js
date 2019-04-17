const fs = require("fs");
var readStream
function sendFile(filePath) {
	readStream = fs.createReadStream(filePath,{ highWaterMark: 65000 });
	readStream.on('data', (chunk) => {
		socket.send(chunk, 0, chunk.length, 10001, MULTICAST_ADDR, function() {
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
	});
}