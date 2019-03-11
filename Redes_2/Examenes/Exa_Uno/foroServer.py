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

ServerDirectory = './images'

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
#