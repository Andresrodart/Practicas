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
db = { "alumnos": [], "Grupos": []}
g1_A = {"Mate 1":"", "Fisica 1":"", "Quimica 1": ""}
g2_A = {"Mate 2":"", "Fisica 2":"", "Quimica 2": ""}
g3_A = {"Mate 3":"", "Fisica 3":"", "Quimica 3": ""}

g1_B = {"Etica 1":"", "Finanzas 1":"", "Gestion 1": ""}
g2_B = {"Etica 2":"", "Finanzas 2":"", "Gestion 2": ""}
g3_B = {"Etica 3":"", "Finanzas 3":"", "Gestion 3": ""}

if not os.path.exists(ServerDirectory):
    os.mkdir(ServerDirectory)

if os.path.isfile('data.json'):
	with open('data.json', 'r') as outfile:
		db = json.load(outfile)
		outfile.close()
else:
	with open('data.json', 'w') as outfile:
		json.dump(db, outfile)
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

	db["alumnos"].append(data)

	if data["group"] == 'Grupo 1-A':
		db["Grupos"].append({"Boleta":data["boleta"], "Materias":g1_A})
	elif data["group"] == 'Grupo 2-A':
		db["Grupos"].append({"Boleta":data["boleta"], "Materias":g2_A})
	elif data["group"] == 'Grupo 3-A':
		db["Grupos"].append({"Boleta":data["boleta"], "Materias":g3_A})
	elif data["group"] == 'Grupo 1-B':
		db["Grupos"].append({"Boleta":data["boleta"], "Materias":g1_B})
	elif data["group"] == 'Grupo 2-B':
		db["Grupos"].append({"Boleta":data["boleta"], "Materias":g2_B})
	elif data["group"] == 'Grupo 3-B':
		db["Grupos"].append({"Boleta":data["boleta"], "Materias":g3_B})
	
	with open('data.json', 'w') as outfile:
		json.dump(db, outfile, sort_keys=True, indent=4)

	if data:
		sent = sock.sendto(b'end', address)
		print('sent {} bytes back to {}'.format(sent, address))

	f = open(ServerDirectory + data["foto"], 'wb')

	while True:
		data, address = sock.recvfrom(4096)
		f.write(data)
		sent = sock.sendto(b'next', address)
		if len(data) < 4096:
			break
	
	f.close()
	print("Job done")