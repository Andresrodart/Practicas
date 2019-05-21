#!/usr/bin/env python3

import socket

HOST = '127.0.0.1'  # Standard loopback interface address (localhost)
PORT = 3535        # Port to listen on (non-privileged ports are > 1023)
DIC_WORDS_LIST = ['Serendipia', 'Anonadado', 'Escampar','Resarcir','Compeler','Andorga']
DIC_WORDS = ('\n'.join(DIC_WORDS_LIST)).encode()
OtheDIc = {
	'serendipia': 4545,
	'anonadado': 4545,
	'compeler': 2525,
	'andorga':	2525
}
DIC = {
	'escampar': 'Cesar de llover y despejarse el cielo de nubes.',
	'resarcir':	'Dar una cosa o hacer un beneficio a una persona como reparación de un daño, perjuicio o molestia que se le ha causado.'
}

class FindWord():
	def __init__(self, word, port):
		self.word = word
		with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
			s.connect((HOST, port))
			s.sendall(word.encode())
			self.definition = s.recv(1024).decode()
					
	def getDef(self):
		return self.definition

def senfWord(word):
	with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
		s.connect((HOST, 4545))
		s.sendall(('_PUT.%s.%s'%(word, '3535')).encode())
		data = s.recv(1024)
	with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
		s.connect((HOST, 2525))
		s.sendall(('_PUT.%s.%s'%(word, '3535')).encode())
		data = s.recv(1024)

print('Servidor dos arriba')	

while True:
	with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
		s.bind((HOST, PORT))
		s.listen()
		conn, addr = s.accept()
		with conn:
			print('Connected by', addr)
			while True:
				data = conn.recv(1024).decode()
				if not data:
					break
				elif data.lower() == 'get':
					data = DIC_WORDS
				elif data.split('.')[0] == 'N3W_W0RD':
					DIC[data.split('.')[1]] = data.split('.')[2]
					DIC_WORDS_LIST.append(data.split('.')[1].capitalize())
					senfWord(data.split('.')[1])
					data = 'Palabra agregada con éxito'.encode()
				elif data.split('.')[0] == '_PUT':
					OtheDIc[(data.split('.')[1])] = int(data.split('.')[2])
					DIC_WORDS_LIST.append(data.split('.')[1].capitalize())
					DIC_WORDS = ('\n'.join(DIC_WORDS_LIST)).encode()
					data = b'added'
				elif data.lower() not in DIC:
					if data.lower() in OtheDIc:
						Finder = FindWord(data.lower(), OtheDIc[data.lower()])
						data = Finder.getDef().encode()
					else:
						data = b'Not Found'
				else:
					data = DIC[data.lower()].encode()
				conn.sendall(data)