import socket
import os
import random

HOST = '127.0.0.1'  # Standard loopback interface address (localhost)
PORT = 65432        # Port to listen on (non-privileged ports are > 1023)
ez = ['mundo', 'palabra', 'carrera']
med = ['recapacitar', 'instituir', 'anticonstitucional']
hrd = ['recapacita bieber', 'ya quiro dormir', 'mateneme ahora que duermo']

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    s.bind((HOST, PORT))
    s.listen()
    while True:
        conn, addr = s.accept()
        with conn:
            print('Connected by', addr)
            while True:
                data = conn.recv(1024)
                if not data:
                    break
                elif data.decode() == 'ez':
                    conn.sendall(ez[random.randint(0,2)].encode())
                elif data.decode() == 'med':
                    conn.sendall(med[random.randint(0,2)].encode())
                elif data.decode() == 'hrd':
                    conn.sendall(hrd[random.randint(0,2)].encode())