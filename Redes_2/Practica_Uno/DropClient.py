#!/usr/bin/env python3
from tkinter import Tk
from tkinter.filedialog import askopenfilenames
from tkinter.filedialog import askdirectory
import zipfile
import pickle
import socket
import sys
import os

HOST = '127.0.0.1'  # The server's hostname or IP address
PORT = 65432        # The port used by the server
option = -1
fileList = 0
ServerDirectory = './.TempServerDummy/'

def folderContent():
	fileList = pickle.loads(s.recv(1024))
	print('\nEl directorio contiene:')
	for i in range(len(fileList)):
		print('\t ', i, ')', fileList[i])
	print()
	return fileList

def UploadAFile():
	Tk().withdraw() # we don't want a full GUI, so keep the root window from appearing
	filename = askopenfilenames(title='Select the files') # show an "Open" dialog box and return the path to the selected file
	fantasy_zip = zipfile.ZipFile('./archive.zip', 'w')
	for _file in list(filename):
		fantasy_zip.write(_file, os.path.basename(_file))
	fantasy_zip.close()
	#print('Se enviara el archvio:', os.path.basename(filename))
	f = open('./archive.zip', 'rb')
	s.sendall('archive.zip'.encode())
	chonk = f.read(1024)
	while chonk: 
		s.sendall(chonk)
		chonk = f.read(1024)
	print(s.recv(1024).decode())
	f.close()
	#while True:
	#	try:
	os.remove('./archive.zip')
	#		break
	#	except:
	#		print('Elimiando')

def DownloadFile():
	fileList = folderContent()
	for elem in fileList:
		f = open(ServerDirectory + elem, 'wb')
		f.close()
	Tk().withdraw() # we don't want a full GUI, so keep the root window from appearing
	filename = askopenfilenames(initialdir = ServerDirectory,title='Select the files')
	s.sendall(pickle.dumps(filename))
	#file2D = input('Choose the file >')
	dirname = askdirectory(title='Open the folder to save')
	for target_list in filename:
		s.sendall(target_list.encode())
		f = open(dirname + '/' + os.path.basename(target_list), 'wb')
		while True:
			data = s.recv(1024)
			f.write(data)
			if len(data) < 1024:
				break
		f.close()
	print("Done Receiving", end='\n\n')
	
with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
	if not os.path.exists(ServerDirectory):
		os.mkdir(ServerDirectory)
	switcher = {
		0: folderContent,
		1: UploadAFile,
		2: DownloadFile
	}
	s.connect((HOST, PORT))
	print('Welcome to the DropPle')
	while True:
		if option < 0:	
			option = input('Select 0 to see what is in the folder\nSelect 1 to upload a file\nSelect 2 to dowload a file\n> ')
			s.sendall(option.encode())
			option = int(option)
		elif option == 3:
			break
		else:
			switcher[option]()
			option = -1
	
	#
	s.close()