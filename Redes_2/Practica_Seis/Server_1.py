import socket
import threading

HOST = '127.0.0.1'  # The server's hostname or IP address
PORT = 4546        # The port used by the server



try:

    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
        s.bind((HOST,PORT))
        s.setblocking(True)
        print('servidor 1 arriba')
        s.listen()
        while True:
            conn,addr=s.accept()
            with conn:
                print('Conectado a ',addr)
                data = conn.recv(1024)
                num = int(data.decode())
                aux =num
                print(data.decode())
                for i in range(39):
                    aux=aux*num
                    print(str(num)+' elevado a la potencia '+str(i+2)+' = '+str(aux))
                conn.sendall(str(aux).encode())
        s.close()


except KeyboardInterrupt:
    print('interrupted')