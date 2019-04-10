import json
import sys
import os
import socket
import pickle
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
		windw.setMinimumSize(1,1)
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
		pass
		#Maestro = Maestro(self) 
		#self.setCentralWidget(Maestro)
	def on_button_clicked_salir(self):
		windw = Window(self)
		self.setCentralWidget(windw)

class Alumno(QWidget):
	def __init__(self, parent):        
		super(Alumno, self).__init__(parent)
		self.layout = QVBoxLayout(self)
		self.mainAlumno()

	def mainAlumno(self):
		self.clean()
		#self.parent().resize(500,250)
		self.mainWidget = QWidget()
		self.mainWidget.layout = QVBoxLayout(self)
		
		self.button1 = QPushButton("Inscribir")
		self.mainWidget.layout.addWidget(self.button1)
		self.button1.clicked.connect(self.inscribir)
		
		self.button2 = QPushButton("Ver calificaciones")
		self.button2.clicked.connect(self.calificaciones)
		self.mainWidget.layout.addWidget(self.button2)
		
		self.button3 = QPushButton("Ver horario")
		self.button3.clicked.connect(self.horario)
		self.mainWidget.layout.addWidget(self.button3)

		self.button4 = QPushButton("Salir")
		self.mainWidget.layout.addWidget(self.button4)
		self.button4.clicked.connect(self.parent().on_button_clicked_salir)

		self.mainWidget.setLayout(self.mainWidget.layout)
		self.layout.addWidget(self.mainWidget)		
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
		
		sign = QPushButton("Inscribisrse")
		rtrn = QPushButton("Regresar")
		sign.clicked.connect(self.sendInfo)
		rtrn.clicked.connect(self.mainAlumno)
		
		auxBox = QWidget()
		auxBox.layout = QHBoxLayout()
		auxBox.layout.addWidget(sign)
		auxBox.layout.addWidget(rtrn)
		auxBox.setLayout(auxBox.layout)

		self.layout.addWidget(self.tabs)
		self.layout.addWidget(auxBox)
		self.setLayout(self.layout)

	def calificaciones(self):
		self.clean()
		self.parent().resize(250,100)
		getUser = QWidget()
		getUser.layout = QFormLayout(self)
		
		self.boletaS = QLineEdit(self)
		LB = QLabel('Boleta', self)
		getUser.setLayout(getUser.layout)
		snd = QPushButton("Aceptar")
		snd.clicked.connect(self.lookGrades)
		rtrn = QPushButton("Regresar")
		rtrn.clicked.connect(self.mainAlumno)

		getUser.layout.addRow(LB, self.boletaS)
		getUser.layout.addRow(snd, rtrn)
		self.layout.addWidget(getUser)
		self.setLayout(self.layout)
		#self.parent().setFixedSize(self.layout.sizeHint())

	def horario(self):
		self.clean()
		self.parent().resize(250,100)
		getUser = QWidget()
		getUser.layout = QFormLayout(self)
		
		self.boletaS = QLineEdit(self)
		LB = QLabel('Boleta', self)
		getUser.setLayout(getUser.layout)
		snd = QPushButton("Aceptar")
		snd.clicked.connect(self.lookHorario)
		rtrn = QPushButton("Regresar")
		rtrn.clicked.connect(self.mainAlumno)

		getUser.layout.addRow(LB, self.boletaS)
		getUser.layout.addRow(snd, rtrn)
		self.layout.addWidget(getUser)
		self.setLayout(self.layout)
	
	def lookHorario(self):
		if self.boletaS.text() != '':
			sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
			server_address = (HOST, PORT)
			alumno = {
				"op": 'horario',
				"calOf": self.boletaS.text()
				}
			try:
				# Send data
				sock.sendto(pickle.dumps(alumno), server_address)
				
				data, server = sock.recvfrom(4096)
				try:
					self.grades = pickle.loads(data)
					self.showGrades()
				except  Exception as e: 
					print(e)
					if data.decode() == 'No_user':
						QMessageBox.question(self, 'Error', "Boleta no encontrada", QMessageBox.Ok, QMessageBox.Ok)
			except:
					
				print('closing socket')
				sock.close()
				#QMessageBox.question(self, 'Exito', "El alumno ha sido inscrito", QMessageBox.Ok, QMessageBox.Ok)
				self.mainAlumno()

		else:
			QMessageBox.question(self, 'Error', "Faltan campos", QMessageBox.Ok, QMessageBox.Ok)

	def lookGrades(self):
		if self.boletaS.text() != '':
			sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
			server_address = (HOST, PORT)
			alumno = {
				"op": 'grades',
				"calOf": self.boletaS.text()
				}
			try:
				# Send data
				sock.sendto(pickle.dumps(alumno), server_address)
				
				data, server = sock.recvfrom(4096)
				try:
					self.grades = pickle.loads(data)
					self.showGrades()
				except  Exception as e: 
					print(e)
					if data.decode() == 'No_user':
						QMessageBox.question(self, 'Error', "Boleta no encontrada", QMessageBox.Ok, QMessageBox.Ok)
					
			except:
				print('closing socket')
				sock.close()
				#QMessageBox.question(self, 'Exito', "El alumno ha sido inscrito", QMessageBox.Ok, QMessageBox.Ok)
				self.mainAlumno()

		else:
			QMessageBox.question(self, 'Error', "Faltan campos", QMessageBox.Ok, QMessageBox.Ok)

	def showGrades(self):
		grades = self.grades
		print('grades in:', grades)
		self.clean()
		self.parent().resize(262,len(grades)*62)
		gradetab = QWidget()
		gradetab.layout = QVBoxLayout(self)
		
		rtrn = QPushButton("Regresar")
		rtrn.clicked.connect(self.mainAlumno)
		
		tableWidget = QTableWidget()
		tableWidget.setRowCount(len(grades))
		tableWidget.setColumnCount(2)

		auxCount = 0
		for key in grades:
			tableWidget.setItem(auxCount,0, QTableWidgetItem(key))
			tableWidget.setItem(auxCount,1, QTableWidgetItem(grades[key]))
			auxCount += 1	
		#field, value = grades.items()[0]
		#print(field, value)
		gradetab.layout.addWidget(tableWidget)
		gradetab.layout.addWidget(rtrn)
		gradetab.setLayout(gradetab.layout)
		self.layout.addWidget(gradetab)		
		self.setLayout(self.layout)

	def clean(self):
		try:
			for i in reversed(range(self.layout.count())): 
				self.layout.itemAt(i).widget().setParent(None)
		except:
			pass
	
	def sendInfo(self):
		if self.boleta.text() != '' and self.nombre.text() != '' and self.ApeMate.text() != ''  and self.ApePate.text() != '' and self.group != '' and self.foto_path != '':
			sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
			server_address = (HOST, PORT)
			alumno = {
				"op":'sign',
				"boleta": self.boleta.text(),
				"name": self.nombre.text(), 
				"ap":	self.ApePate.text(),
				"am":	self.ApeMate.text(),
				"group":self.group,
				"foto":	os.path.basename(self.foto_path)
				}
			try:
				# Send data
				print('sending', alumno)
				sock.sendto(pickle.dumps(alumno), server_address)

				# Receive response
				print('waiting to receive')
				data, server = sock.recvfrom(4096)
				print('received {!r}'.format(data))
				
				if data.decode() == 'end':
					f = open(self.foto_path, 'rb')
					chonk = f.read(4096)
					while chonk: 
						sock.sendto(chonk, server_address)
						data, server = sock.recvfrom(4096)
						#print('received {!r}'.format(data))
						chonk = f.read(4096)
					f.close()
			
			finally:
				print('closing socket')
				sock.close()
				QMessageBox.question(self, 'Exito', "El alumno ha sido inscrito", QMessageBox.Ok, QMessageBox.Ok)
				self.mainAlumno()


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