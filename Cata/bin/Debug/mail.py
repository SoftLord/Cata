import smtplib
import tkinter as tk
from tkinter import *
from tkinter import ttk
from tkinter import messagebox
import os

servidor = smtplib.SMTP("smtp.gmail.com", 587)
#usaremos los servidores smtp de google para enviar el correo a traves del puerto 587 (predeterminado)
servidor.starttls() #conexion segura tls

def registro(usuario, contrasena):
	servidor.login(usuario, contrasena) #usuario, contrasena

def enviarMail(emisor, receptor, asunto):
	servidor.sendmail(emisor, receptor, asunto)  #emisor, receptor, asunto

def establecerParametros():
	ventanaCorreo = tk.Tk()
	ventanaCorreo.title("Enviar correo")
	ventanaCorreo.geometry("400x160")
	ventanaCorreo.resizable(0,0)
	ventanaCorreo.iconbitmap("logo.ico")

	def verificarCorreo():
		if ("@" in usuario.get() and "@" in destinatario.get()):
			if (contrasena.get() == ""):
				messagebox.showerror("Error", "Introduzca una contraseña válida.")
			else:
				try:
					registro(usuario.get(), contrasena.get())
					try:
						enviarMail(usuario.get(), receptor.get(), "Mensaje de prueba")
					except:
						messagebox.showerror("Error", "Imposible enviar mensaje.")
				except:
					messagebox.showerror("Error", "La clave o usuario del correo no coincide.")
		else:
			messagebox.showerror("Error", "Introduzca una dirección de correo válida.")

	def salir():
		ventanaCorreo.destroy()

	#-----------etiquetas y entradas de texto----------------#
	espacio1 = tk.Label(ventanaCorreo, text="")
	espacio1.grid(row=1)

	textoUsuario = tk.Label(ventanaCorreo, text="	Usuario:	    ")
	textoUsuario.grid(row=2)
	textoContrasena = tk.Label(ventanaCorreo, text="	       Contraseña:	    ")
	textoContrasena.grid(row=3)

	usuario = ttk.Entry(ventanaCorreo)
	usuario.grid(row=2, column=1)
	contrasena = ttk.Entry(ventanaCorreo, show="•")
	contrasena.grid(row=3, column = 1)

	espacio2 = tk.Label(ventanaCorreo, text="")
	espacio2.grid(row=4)

	textoDestinatario = tk.Label(ventanaCorreo, text="	Destinatario")
	textoDestinatario.grid(row=5)
	destinatario = ttk.Entry(ventanaCorreo)
	destinatario.grid(row=5, column=1)

	espacio3 = tk.Label(ventanaCorreo, text="")
	espacio3.grid(row=6)

	#------------------botones-------------------------------#
	cancelar = tk.Button(ventanaCorreo, text="cancelar", cursor="hand2", command=salir)
	cancelar.grid(row=7)
	aceptar = tk.Button(ventanaCorreo, text="Aceptar", cursor="hand2", command=verificarCorreo)
	aceptar.grid(row=7, column=1)

	ventanaCorreo.mainloop()


if __name__ == "__main__":
	establecerParametros()