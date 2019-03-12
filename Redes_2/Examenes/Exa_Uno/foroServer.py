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

def newPost():
	forum = conn.recv(1024).decode()
	newPost = post
	data = json.loads(conn.recv(1024).decode())
	if forum == 'perritos':
		topicos["perritos"].append(data)
	elif forum == 'tecnologia':
		topicos["tecnologia"].append(data)
	conn.sendall(b'succes')

def sendForum():
	forum = conn.recv(1024).decode()
	if forum == 'perritos':
		dataToSend = json.dumps(topicos['perritos'])
	elif forum == 'tecnologia':
		dataToSend = json.dumps(topicos['tecnologia'])
	conn.sendall(dataToSend)

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
		1: newPost
	}
	print('Welcome to the Forummy')
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
	with open('topicos.json', 'w') as outfile:
		json.dump(topicos, outfile)
		outfile.close()