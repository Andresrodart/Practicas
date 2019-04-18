import socket
import struct
import sys
import json
import os
multicast_group = '224.3.29.71'
server_address = ('', 10001)
send_multicast_group = ('224.3.29.71', 10000)
ServerDirectory = './ServerDummy/'
recivingFile = False
f = None

users = {}
# Create the socket
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
sock.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)

# Bind to the server address
sock.bind(server_address)

# Tell the operating system to add the socket to
# the multicast group on all interfaces.
group = socket.inet_aton(multicast_group)
mreq = struct.pack('4sL', group, socket.INADDR_ANY)
sock.setsockopt(
	socket.IPPROTO_IP,
	socket.IP_ADD_MEMBERSHIP,
	mreq)

if not os.path.exists(ServerDirectory):
    os.mkdir(ServerDirectory)
# Receive/respond loop
while True:
	print('\nwaiting to receive message')
	if not recivingFile:
		data, address = sock.recvfrom(65000)
		print('received {} bytes from {}'.format(len(data), address))
		try:
			data_in_json = json.loads(data)
			if data_in_json['user'] in users and 'file' not in data_in_json:
				sock.sendto(json.dumps({'res':False}).encode(), send_multicast_group)
			else:
				users[data_in_json['user']] = True
				data2send = json.dumps({'res':True, 'sender':data_in_json['user'] ,'users':users}, ensure_ascii=False)
				print(data2send)
				sock.sendto(data2send.encode('utf8'), send_multicast_group)
			if 'file' in data_in_json:
				f = open(ServerDirectory + data_in_json['mesg'], 'wb')
				print(ServerDirectory + data_in_json['mesg'])
				recivingFile = True
				sock.sendto(('start_file_sending_' + data_in_json['user']).encode(), send_multicast_group)
		
		except Exception as e:
			raise e
	else:
		while True:
			data = sock.recv(65000)
			f.write(data)
			if len(data) < 65000:
				flnm = 0
				break
			sock.sendto('continue'.encode(), send_multicast_group)
		f.close()
		recivingFile = False
		print("Done Receiving")

	#print('sending acknowledgement to', address)