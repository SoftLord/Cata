import smtplib

servidor = smtplib.SMTP("smtp.gmail.com", 587)
#usaremos los servidores smtp de google para enviar el correo a traves del puerto 587 (predeterminado)
servidor.starttls() #conexion segura tls

servidor.login("usuario", "contraseña") #usuario, contrasena
servidor.sendmail("emisor", "receptor", "asunto")  #emisor, receptor, asunto