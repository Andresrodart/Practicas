#!/usr/bin/env python3

import socket
import os
import pickle #serialize the list to send it tru socket
import zipfile

HOST = '127.0.0.1'  # Standard loopback interface address (localhost)
PORT = 65432        # Port to listen on (non-privileged ports are > 1023)
f = 0
dataSend = 0
ServerDirectory = './ServerDummy/'
option = -1
fileList = 0

def folderContent():
	fileList = os.listdir(ServerDirectory)
	conn.sendall(pickle.dumps(fileList))

def UploadAFile():
	flnm = 0
	while True:
		data = conn.recv(1024)
		if flnm == 0:
			f = open(ServerDirectory + data.decode(), 'wb')
			flnm = flnm + 1
		else:
			f.write(data)
			if len(data) < 1024:
				flnm = 0
				break
	f.close()
	conn.sendall(b'Send was succesful\n')
	print("Done Receiving")
	fantasy_zip = zipfile.ZipFile(ServerDirectory + '/archive.zip')
	fantasy_zip.extractall(ServerDirectory)
	fantasy_zip.close()
	os.remove( ServerDirectory + '/archive.zip')

def DownloadFile():
	folderContent()
	filesname = pickle.loads(conn.recv(1024))
	for item in filesname:
		file2D = conn.recv(1024).decode()
		#print('Se enviara el archvio:', fileList[file2D])
		f = open(ServerDirectory + os.path.basename(file2D), 'rb')
		chonk = f.read(1024)
		while chonk: 
			conn.sendall(chonk)
			chonk = f.read(1024)

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
	if not os.path.exists(ServerDirectory):
		os.mkdir(ServerDirectory)
	s.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1) 
	s.bind((HOST, PORT))
	s.listen()
	fileList = os.listdir(ServerDirectory)
	switcher = {
		0: folderContent,
		1: UploadAFile,
		2: DownloadFile
	}
	print('Welcome to the DropPle')
	while True:
		conn, addr = s.accept()
		with conn:
			print('Direccion', addr)
			while True:
				if option < 0:
					option = int(conn.recv(1024).decode())
				elif option >= 3:
					option = -1
					break
				else:
					switcher[option]()
					option = -1
			#while True:	
	s.close()
	client.Close();
#