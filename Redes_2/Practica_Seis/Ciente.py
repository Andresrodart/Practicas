import socket
import threading

HOST = '127.0.0.1'  # The server's hostname or IP address
PORT = 4545        # The port used by the server
try:

    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
        s.connect((HOST,PORT))
        data =input('introduce el numero a elevar a la potencia 40')
        s.sendall(data.encode())
        #resultado = s.recv(1024)
        #print('el resultado es '+resultado.decode())
        resultado = s.recv(1024)
        print('el resultado es = '+resultado.decode())


except KeyboardInterrupt:
    print('interrupted')