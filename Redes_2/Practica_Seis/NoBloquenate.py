import select, socket, sys, queue
server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server.setblocking(0)
server.bind(('localhost', 50000))
server.listen(5)

http = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
http.connect(('localhost', 4545))
http.setblocking(0)
inputs = [server, http]
outputs = [http]
message_queues = {}
message_out = []
message_in = []

while inputs:
	readable, writable, exceptional = select.select(
		inputs, outputs, inputs)
	for s in readable:
		if s is server:
			connection, client_address = s.accept()
			connection.setblocking(0)
			inputs.append(connection)
			message_queues[connection] = queue.Queue()
		else:
			data = s.recv(1024)
			print(data)
			if data:
				#message_queues[s].put(data)
				message_out.append(data)
				if s not in outputs:
					outputs.append(s)
			else:
				if s in outputs:
					outputs.remove(s)
				inputs.remove(s)
				s.close()
				del message_queues[s]

	for s in writable:
		try:
			next_msg = message_out.pop() #
		except Exception:
			pass
			#outputs.remove(s)
		else:
			s.send(next_msg)
			print("data send")
		
		# data = s.recv(1024)
		# print(data)
	# if len(message_out) != 0:
	# 	pass

	for s in exceptional:
		inputs.remove(s)
		if s in outputs:
			outputs.remove(s)
		s.close()
		del message_queues[s]