import socket
import sys
import pickle
import json
import os

HOST = '127.0.0.1'  # The server's hostname or IP address
PORT = 65435        # The port used by the server
ServerDirectory = './ServerDummy/'
# Create a UDP socket
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
db = { "alumnos": [], "Grupos": [], "Materias": []}

if os.path.isfile('data.json'):
	with open('data.json', 'w') as outfile:
		db = json.load(outfile)
else:
	with open('data.json', 'wb') as outfile:
		#aux = json.dumps(db)
		outfile.write('{ "alumnos": [], "Grupos": [], "Materias": []}')
		outfile.close()

# Bind the socket to the port
server_address = (HOST, PORT)
print('starting up on {} port {}'.format(*server_address))
sock.bind(server_address)
	
while True:
	print('\nwaiting to receive message')
	data, address = sock.recvfrom(4096)
	data = pickle.loads(data)
    
	print('received {} bytes from {}'.format(len(data), address))
	print(data)

	alumno = json.dumps(data)
	db["alumnos"].push(alumno)
	with open('data.json', 'wb') as outfile:
		json.dump(db, outfile)

	if data:
		sent = sock.sendto(b'end', address)
		print('sent {} bytes back to {}'.format(sent, address))

	f = open(ServerDirectory + alumno["foto"], 'wb')

	while True:
		data, address = sock.recvfrom(1024)
		f.write(data)
		if len(data) < 1024:
			flnm = 0
			break
	f.close()