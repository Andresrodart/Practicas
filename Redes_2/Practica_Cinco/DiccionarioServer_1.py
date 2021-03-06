#!/usr/bin/env python3

import socket
import json
HOST = '127.0.0.1'  # Standard loopback interface address (localhost)
PORT = 4545        # Port to listen on (non-privileged ports are > 1023)
DIC_WORDS_LIST = ['Serendipia', 'Anonadado', 'Escampar','Resarcir','Compeler','Andorga']
DIC_WORDS = ('\n'.join(DIC_WORDS_LIST)).encode()
DIC = {
	'serendipia': 'es un descubrimiento o un hallazgo afortunado, valioso e inesperado que se produce de manera accidental, casual o por destino, o cuando se está buscando una cosa distinta.',
	'anonadado': 'es un adjetivo que deriva del verbo anonadar: desconcertar, sorprender o abrumar.'
}
OtheDIc = {
	'escampar':3535,
	'resarcir':3535,
	'compeler': 2525,
	'andorga':	2525
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
		s.connect((HOST, 3535))
		s.sendall(('_PUT.%s.%s'%(word, '4545')).encode())
		data = s.recv(1024)
	with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
		s.connect((HOST, 2525))
		s.sendall(('_PUT.%s.%s'%(word, '4545')).encode())
		data = s.recv(1024)

print('Servidor uno arriba')

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
					print('Sending dic')
					data = DIC_WORDS
				elif data.split('.')[0] == 'N3W_W0RD':
					print('Adding new word')
					DIC[((data.split('.')[1])).lower()] = data.split('.')[2]
					DIC_WORDS_LIST.append(data.split('.')[1].capitalize())
					DIC_WORDS = ('\n'.join(DIC_WORDS_LIST)).encode()
					senfWord(data.split('.')[1])
					data = ('Palabra agregada con éxito').encode()
				elif data.split('.')[0] == '_PUT':
					print('Sending new word to other severs')
					OtheDIc[((data.split('.')[1])).lower()] = int(data.split('.')[2])
					DIC_WORDS_LIST.append(data.split('.')[1].capitalize())
					DIC_WORDS = ('\n'.join(DIC_WORDS_LIST)).encode()
					data = ('added: ' + DIC_WORDS.decode() + json.dumps(OtheDIc)).encode()
				elif data.lower() not in DIC:
					print('Searching in other server')
					if data.lower() in OtheDIc:
						Finder = FindWord(data.lower(), OtheDIc[data.lower()])
						data = Finder.getDef().encode()
					else:
						data = b'Not Found'
				else:
					print('Found in this server')
					data = DIC[data.lower()].encode()
				print('Sending:', data)
				conn.sendall(data)
				s.close()