from http.server import BaseHTTPRequestHandler 
from socketserver import ThreadingMixIn, TCPServer
import sys
import threading
import queue
import socket
import os
import cgi
import urllib.parse
import json
from io import BytesIO
from concurrent.futures import ThreadPoolExecutor # pip install futures

class Handler(BaseHTTPRequestHandler):
	# Handler for the GET requests
	def do_GET(self):
		if '?' in self.path:
			page = '''
			<!DOCTYPE html>
			<html lang="en">
			<head>
				<meta charset="UTF-8">
				<meta name="viewport" content="width=device-width, initial-scale=1.0">
				<meta http-equiv="X-UA-Compatible" content="ie=edge">
				<link rel="shortcut icon" type="image/png" href="favicon.ico">
				<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css">
				<script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"></script>
				<script src="utilities.js"></script>
				<title>Práctica cuatro</title>
			</head>
			<body>
				<nav class="teal lighten-1">
					<div class="nav-wrapper container">
						<a href="#" class="brand-logo">Logo</a>
						<ul id="nav-mobile" class="right hide-on-med-and-down">
							<li><a href="sass.html">Sass</a></li>
							<li><a href="badges.html">Components</a></li>
							<li><a href="collapsible.html">JavaScript</a></li>
						</ul>
					</div>
				</nav>
				<div class="row container" id="POST">
					<div class="row">
						<div class="col s3">
							<div class="card">
								<div class="card-image">
									<img src="coddess.png">
									<span class="card-title">Parámetros obtenidos</span>
								</div>
								<div class="card-content">
									<p>
										%s
									</p>
								</div>
									<div class="card-action">
									<a href="/">Return</a>
								</div>
							</div>
						</div>
					</div> 
				</div>
				<footer class="page-footer teal lighten-1">
					<div class="container">
						<div class="row">
							<div class="col l6 s12">
								<h5 class="white-text">Footer Content</h5>
								<p class="grey-text text-lighten-4">You can use rows and columns here to organize your footer content.</p>
							</div>
							<div class="col l4 offset-l2 s12">
								<h5 class="white-text">Links</h5>
								<ul>
									<li><a class="grey-text text-lighten-3" href="#!">Link 1</a></li>
									<li><a class="grey-text text-lighten-3" href="#!">Link 2</a></li>
									<li><a class="grey-text text-lighten-3" href="#!">Link 3</a></li>
									<li><a class="grey-text text-lighten-3" href="#!">Link 4</a></li>
								</ul>
							</div>
						</div>
					</div>
					<div class="footer-copyright">
						<div class="container">
							© 2014 Copyright Text
							<a class="grey-text text-lighten-4 right" href="#!">More Links</a>
						</div>
					</div>
				</footer>
			</body>
			</html>
			'''%('<br>'.join(self.path.split('?')))
			self.send_response(200)
			self.send_header('Content-type', 'text/html')
			self.end_headers()
			self.wfile.write(page.encode())
		else:
			self.respond()

	def do_HEAD(self):
		self.send_response(200)
		self.send_header('Content-type', 'text/html')
		self.end_headers()
		
	def do_POST(self):
		content = self.rfile.read(int(self.headers['Content-Length'])).decode("UTF-8")
		print(content)
		if 'file:all' == content:
			content = '<br>'.join(os.listdir(os.curdir))
		self.send_response(200)
		self.send_header("Content-Length", len(content.encode()))
		self.end_headers()
		self.wfile.write(content.encode())
	def do_DELETE(self):
		content = json.loads(self.rfile.read(int(self.headers['Content-Length'])).decode("UTF-8"))
		print('deleting %s'% os.path.basename(self.path), content['file'])
		if content['file'] in os.listdir(os.curdir):
			self.send_response(202) #Moved Permanently
			os.remove(os.path.join(os.curdir, content['file']))
		else:
			self.send_response(204)
		self.send_header("location", "/")
		self.end_headers()
		self.wfile.write(b'done')
	
	def handle_http(self):
		status = 200
		content_type = "text/plain"
		response_content = ""
		FileName = 'index.html'
		try:
			if self.path != '/':
				FileName = os.path.basename(self.path)
			f = open(os.path.join(os.curdir, FileName))
			content_type = "text/html"
			response_content = FileName
			f.close()
			if any(c in self.path for c in ['.PNG', '.png']):
				content_type = 'image/png'
			elif any(c in self.path for c in ['.JPEG', '.jpeg', '.JPG', '.jpg']):
				content_type = 'image/jpeg'
			elif any(c in self.path for c in ['.WAV', '.wav']):
				content_type = 'audio/wav'
			elif any(c in self.path for c in ['.PDF', '.pdf']):
				content_type = 'application/pdf'
		except FileNotFoundError:
			content_type = "text/plain"
			response_content = "404 Not Found"

		self.send_response(status)
		self.send_header('Content-type', content_type)
		self.end_headers()
		return response_content

	def respond(self):
		FileName = self.handle_http()
		f = open(os.path.join(os.curdir, FileName), 'rb')
		chonk = f.read(1024)
		while chonk: 
			self.wfile.write(chonk)
			chonk = f.read(1024)
		f.close()
			

class ThreadPoolMixIn(ThreadingMixIn):
	'''
	use a thread pool instead of a new thread on every request
	'''
	numThreads = 10
	allow_reuse_address = True  # seems to fix socket.error on server restart
	def __init__(self, numThreads=10):
		self.numThreads=numThreads
		ThreadingMixIn.__init__(self)
	
	def serve_forever(self):
		'''
		Handle one request at a time until doomsday.
		'''
		# set up the threadpool
		self.requests = queue.Queue(self.numThreads)
		for x in range(self.numThreads):
			t = threading.Thread(target = self.process_request_thread)
			t.setDaemon(1)
			t.start()

		# server main loop
		while True:
			self.handle_request()
			
		print('Closing server')
		self.server_close()

	
	def process_request_thread(self):
		'''
		obtain request from queue instead of directly from server socket
		'''
		while True:
			ThreadingMixIn.process_request_thread(self, *self.requests.get())

	
	def handle_request(self):
		'''
		simply collect requests and put them on the queue for the workers.
		'''
		try:
			request, client_address = self.get_request()
			print('Connecting client: ', client_address)
		except socket.error:
			print('error')
			return
		if self.verify_request(request, client_address):
			self.requests.put((request, client_address))

class ThreadedServer(ThreadPoolMixIn, TCPServer):
	def __init__(self, server_address, request_class, numThreads=10, bind_and_activate=True):
		ThreadPoolMixIn.__init__(self, numThreads=numThreads)
		TCPServer.__init__(
			self,
			server_address,
			request_class,
			bind_and_activate)

PORT = 4545
userChoise = int(input('Ingrese el núemro de hilos a usar: '))
with ThreadedServer(("", PORT), Handler, numThreads=userChoise) as httpd:
	print("serving at port", PORT)
	try:
		httpd.serve_forever()
	except KeyboardInterrupt:
		print("\nShutting down server per users request.")
		httpd.join()
		httpd.shutdown()
		httpd.server_close()