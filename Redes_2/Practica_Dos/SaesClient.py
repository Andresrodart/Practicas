from PyQt5.QtGui import QIcon
import sys
from PyQt5.QtWidgets import *
from PyQt5.QtCore import Qt

# Subclass QMainWindow to customise your application's main window
class MainWindow(QMainWindow):
	def __init__(self, parent=None):
		super(MainWindow, self).__init__(parent)

		self.setWindowTitle("My Awesome App")
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
		self.parent().resize(500,500)
		self.layout = QVBoxLayout(self)
		self.button1 = QPushButton("Inscribir")
		self.layout.addWidget(self.button1)
		self.button1.clicked.connect(self.parent().on_button_clicked_salir)
		self.button2 = QPushButton("Ver calificaciones")
		self.layout.addWidget(self.button2)

		self.setLayout(self.layout)
	

class Window(QWidget):
	def __init__(self, parent):        
		super(Window, self).__init__(parent)
		self.parent().resize(50,100)
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