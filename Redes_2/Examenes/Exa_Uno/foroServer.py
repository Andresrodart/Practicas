#!/usr/bin/env python3
from tkinter import Tk
from tkinter.filedialog import askopenfilenames
from tkinter.filedialog import askdirectory
import zipfile
import pickle
import socket
import sys
import os
import json
import shutil

HOST = '127.0.0.1'  # The server's hostname or IP address
PORT = 65435        # The port used by the server
ServerDirectory = './imagesServer'
post = {"usuario":"", "titulo": "", "texto": "","imagen":"","fecha":""}
topicos = {"perritos":[post],"tecnologia":[post]}

def newPost(forum):
	data = json.loads(conn.recv(1024).decode())
	if forum == 'perritos':
		topicos["perritos"].append(data)
	elif forum == 'tecnologia':
		topicos["tecnologia"].append(data)
	#conn.sendall(b'succes')
	if data["imagen"] != '':
		f = open(data["imagen"], 'wb')
		data = conn.recv(1024)
		while data:
			data = conn.recv(1024)
            f.write(data)
		    if len(data) < 1024:
				break

def sendForum(forum):
	print('Topico:' + forum)
	if forum == 'perritos':
		dataToSend = json.dumps(topicos['perritos'])
	elif forum == 'tecnologia':
		dataToSend = json.dumps(topicos['tecnologia'])
	conn.sendall(dataToSend.encode())

def askPhotos(photo):
	print('\nSending photo: ' + photo, end='')
	f = open(photo, 'rb')
	chonk = f.read(1024)
	while chonk: 
		conn.sendall(chonk)
		chonk = f.read(1024)
		print('', end='.')
	print(' Done')
        
if not os.path.exists(ServerDirectory):
		os.mkdir(ServerDirectory)   
if os.path.isfile('topicos.json'):
	with open('topicos.json', 'r') as outfile:
		topicos = json.load(outfile)
		outfile.close()
else:
	with open('topicos.json', 'w') as outfile:
		json.dump(topicos, outfile)
		outfile.close()

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
	s.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1) 
	s.bind((HOST, PORT))
	s.listen()
	fileList = os.listdir(ServerDirectory)
	switcher = {
		0: sendForum,
		1: newPost,
        2: askPhotos
	}
	print('Welcome to the Forummy')
	option = -1
	topicStrema = ''
	while True:
		conn, addr = s.accept()
		with conn:
			print('Direccion', addr)
			while True:
				if option < 0:
					strAux = conn.recv(256).decode()
					option = int(strAux[0])
					topicStrema = strAux[1:]
				elif option >= 3:
					option = -1
					print('Cliente desconectado')
					break
				else:
					switcher[option](topicStrema)
					option = -1
	s.close()
	with open('topicos.json', 'w') as outfile:
		json.dump(topicos, outfile)
		outfile.close()