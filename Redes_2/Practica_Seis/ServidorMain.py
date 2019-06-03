import socket

HOST = '127.0.0.1'  # The server's hostname or IP address
PORT = 4545        # The port used by the server

Servidores = [
	4546,
	4646,
	3434,
]
cont = 0
try:

    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
        s.bind((HOST,PORT))
        s.setblocking(True)
        print('servidor arriba')
        s.listen()
        while True:
            conn,addr=s.accept()
            with conn:
                print('Conectado a ',addr)
                numero = conn.recv(1024)
                print('el cliente quiere elevar a la potencia 40 el numero: ' + numero.decode())
                print('Enviando carga a servidor ' + str(cont))

                with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as e:
                    puerto=Servidores[cont]
                    e.connect((HOST,puerto))
                    e.sendall(numero)
                    resultado = e.recv(30000)

                print('el servidor recibio de resultado= '+resultado.decode())
                conn.sendall(resultado)

                if cont == 3:
                    cont = 0
                else:
                    cont += 1
        s.close()



except KeyboardInterrupt:
    print('interrupted')