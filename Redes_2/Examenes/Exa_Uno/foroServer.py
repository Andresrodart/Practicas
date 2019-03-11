#!/usr/bin/env python3
from tkinter import Tk
from tkinter.filedialog import askopenfilenames
from tkinter.filedialog import askdirectory
import zipfile
import pickle
import socket
import sys
import os
import shutil

HOST = '127.0.0.1'  # The server's hostname or IP address
PORT = 65435        # The port used by the server
ServerDirectory = './imagesServer'
post = {"usuario":"", "titulo": "", "texto": "","imagen":"","fecha":""}
topicos = {"perritos":[],"tecnologia":[]}

def newPost():
	topico texto
	post
	imagen
	pass

def sendForum():
	pass



with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
	if not os.path.exists(ServerDirectory):
		os.mkdir(ServerDirectory)
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