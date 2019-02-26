import sys
import os
from PyQt5.QtWidgets import *
from PyQt5.QtGui import QIcon
from PyQt5.QtCore import Qt

HOST = '127.0.0.1'  # The server's hostname or IP address
PORT = 65435        # The port used by the server

# Subclass QMainWindow to customise your application's main window
class MainWindow(QMainWindow):
	def __init__(self, parent=None):
		super(MainWindow, self).__init__(parent)

		self.setWindowTitle("MogSaes")
		windw = Window(self)
		# Set the central widget of the Window. Widget will expand
		# to take up all the space in the window by default.
		self.setCentralWidget(windw)

	def on_button_clicked_alumno(self):
		alumno = Alumno(self) 
		self.setCentralWidget(alumno) 
		#alert = QMessageBox()
		#alert.setText('You clicked the button!')
		#alert.exec_()
	def on_button_clicked_maestro(self):
		Maestro = Maestro(self) 
		self.setCentralWidget(Maestro)
	def on_button_clicked_salir(self):
		windw = Window(self)
		self.setCentralWidget(windw)

class Alumno(QWidget):
	def __init__(self, parent):        
		super(Alumno, self).__init__(parent)
		self.parent().resize(500,250)
		self.layout = QVBoxLayout(self)
		
		self.button1 = QPushButton("Inscribir")
		self.layout.addWidget(self.button1)
		self.button1.clicked.connect(self.inscribir)
		
		self.button2 = QPushButton("Ver calificaciones")
		self.button2.clicked.connect(self.calificaciones)
		self.layout.addWidget(self.button2)
		
		self.button3 = QPushButton("Ver horario")
		self.button3.clicked.connect(self.clean)
		self.layout.addWidget(self.button3)

		self.button4 = QPushButton("Salir")
		self.layout.addWidget(self.button4)
		self.button4.clicked.connect(self.parent().on_button_clicked_salir)

		
		self.setLayout(self.layout)

	def inscribir(self):
		self.clean()
		self.tabs = QTabWidget()
		self.info = QWidget()
		self.grupo = QWidget()
		self.foto_path = ''
		self.group = ''

		self.tabs.addTab(self.info, "Información personal")
		self.tabs.addTab(self.grupo,"Grupos")
		
		self.info.layout = QFormLayout(self)

		self.boleta = QLineEdit(self)
		LB = QLabel('Boleta', self)
		
		self.nombre = QLineEdit(self)
		LN = QLabel('Nombre', self)

		self.ApeMate = QLineEdit(self)
		LAm = QLabel('Apellido Materno', self)

		self.ApePate = QLineEdit(self)
		LAp = QLabel('Apellido Paterno', self)

		foto = QPushButton("Subir foto")
		foto.clicked.connect(self.getFoto)
		self.LF = QLabel('', self)
		
		self.info.layout.addRow(LB,  self.boleta)
		self.info.layout.addRow(LN,  self.nombre)
		self.info.layout.addRow(LAp, self.ApePate)
		self.info.layout.addRow(LAm, self.ApeMate)
		self.info.layout.addRow(self.LF, foto)
		
		self.info.setLayout(self.info.layout)

		self.grupo.layout = QGridLayout()
		
		self.b1 = QRadioButton('Grupo 1-A')
		self.b1.toggled.connect(lambda:self.btnstate(self.b1))
		self.b2 = QRadioButton('Grupo 1-B')
		self.b2.toggled.connect(lambda:self.btnstate(self.b2))
		self.b3 = QRadioButton('Grupo 2-A')
		self.b3.toggled.connect(lambda:self.btnstate(self.b3))
		self.b4 = QRadioButton('Grupo 2-B')
		self.b4.toggled.connect(lambda:self.btnstate(self.b4))
		self.b5 = QRadioButton('Grupo 3-A')
		self.b5.toggled.connect(lambda:self.btnstate(self.b5))
		self.b6 = QRadioButton('Grupo 3-B')
		self.b6.toggled.connect(lambda:self.btnstate(self.b6))

		self.grupo.layout.addWidget(self.b1,0,0)
		self.grupo.layout.addWidget(self.b2,0,1)
		self.grupo.layout.addWidget(self.b3,1,0)
		self.grupo.layout.addWidget(self.b4,1,1)
		self.grupo.layout.addWidget(self.b5,2,0)
		self.grupo.layout.addWidget(self.b6,2,1)
		
		self.grupo.setLayout(self.grupo.layout)

		self.layout.addWidget(self.tabs)
		
		sign = QPushButton("Inscribisrse")
		sign.clicked.connect(self.sendInfo)

		self.layout.addWidget(sign)
		self.setLayout(self.layout)

	def calificaciones(self):
		self.clean()
	
	def clean(self):
		for i in reversed(range(self.layout.count())): 
			self.layout.itemAt(i).widget().setParent(None)
	
	def sendInfo(self):
		if self.boleta.text() != '' and self.nombre.text() != '' and self.ApeMate.text() != ''  and self.ApePate.text() != '' and self.group != '' and self.foto_path != '':
			sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
			server_address = (HOST, PORT)
			message = b'This is the message.  It will be repeated.'
			try:
				# Send data
				print('sending {!r}'.format(message))
				sent = sock.sendto(message, server_address)

				# Receive response
				print('waiting to receive')
				data, server = sock.recvfrom(4096)
				print('received {!r}'.format(data))

			finally:
				print('closing socket')
				sock.close()

		else:
			QMessageBox.question(self, 'Error', "Faltan campos", QMessageBox.Ok, QMessageBox.Ok)
	
	def getFoto(self):
		fnme =  QFileDialog.getOpenFileName(self, 'Open file', 'c:\\',"Image files (*.jpg *.gif)")	
		self.LF.setText(os.path.basename(fnme[0]))
		self.foto_path = fnme[0]
	
	def btnstate(self,b):
		self.group = b.text()

class Window(QWidget):
	def __init__(self, parent):        
		super(Window, self).__init__(parent)
		self.parent().resize(250,100)
		self.layout = QVBoxLayout(self)
		self.button_alumno = QPushButton('Alumno')
		self.button_maestro = QPushButton('Maestro')
		self.layout.addWidget(self.button_alumno)
		self.layout.addWidget(self.button_maestro)
		self.button_alumno.clicked.connect(self.parent().on_button_clicked_alumno)
		self.button_maestro.clicked.connect(self.parent().on_button_clicked_maestro)
		self.setLayout(self.layout)

if __name__ == '__main__':
	app = QApplication([])
	window = MainWindow()
	window.show()
	app.exec_()