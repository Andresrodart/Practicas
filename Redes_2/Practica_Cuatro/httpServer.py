from http.server import BaseHTTPRequestHandler 
import socketserver
import os
from io import BytesIO

class Handler(BaseHTTPRequestHandler):
	# Handler for the GET requests
	def do_GET(self):
		self.respond()

	def do_POST(self):
		content_length = int(self.headers['Content-Length'])
		body = self.rfile.read(content_length)
		self.send_response(200)
		self.end_headers()
		response = BytesIO()
		response.write(b'This is POST request. ')
		response.write(b'Received: ')
		response.write(body)
		print(body)
		self.wfile.write(response.getvalue())

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
			
		
PORT = 4545

with socketserver.TCPServer(("", PORT), Handler) as httpd:
	print("serving at port", PORT)
	httpd.serve_forever()