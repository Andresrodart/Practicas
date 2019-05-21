import socket
import pickle

HOST = '127.0.0.1'  # The server's hostname or IP address
PORT = 2525        # The port used by the server
DIC = {}

try:
	while True:
		with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
			s.connect((HOST, PORT))
			s.sendall(b'get')
			DIC = s.recv(1024).decode()
		print('Diccionario disponible:\n', DIC, sep='')
		choose = int(input('\nIngresa:\n\t1) Buscar palabra\n\t2) Agregar palabra al diccionario\n\tOtro) Salir: '))
		if choose == 1:
			word = input('Ingresa la palabra a buscar: ')

			with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
				s.connect((HOST, PORT))
				s.sendall(word.encode())
				data = s.recv(1024)
				if data and data.decode() != 'Not Found':
					print(word, ': ', data.decode(), '\n')
				else:
					print('palabra no encontrada, ¿la escribiste bien?')
		elif choose == 2:
			word = input('Ingresa la palabra nueva a agregar: ')
			correct = input('¿%s esta correcta? 0) Sí Otro) No: '%word)
			while correct != '0':
				word = input('Ingresa la palabra nueva a agregar: ')
				correct = input('¿%s esta correcta? 0) Sí Otro) No: '%word)
			
			definition = input('Ingresa la definición de la palabra nueva a agregar: ')
			correct = input('¿%s esta correcta? 0) Sí Otro) No: '%definition)
			while correct != '0':
				definition = input('Ingresa la definición de la palabra nueva a agregar: ')
				correct = input('¿%s esta correcta? 0) Sí Otro) No: '%definition)
			
			with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
				s.connect((HOST, PORT))
				s.sendall(('N3W_W0RD.%s.%s'%(word, definition)).encode())
				data = s.recv(1024)
				print(data.decode(), '\n')
		else:
			break
except KeyboardInterrupt:
	print('interrupted!')