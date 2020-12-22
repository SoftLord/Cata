import subprocess

#obtenemos el resultado en consola de -pip list y lo guardamos en un fichero de texto dandole el formato que queramos
output = str(subprocess.check_output("pip list"))
output = output.replace("Package", "")
output = output.replace("Version", "")
output = output.replace("b", "")
output = output.replace("'", "")
output = output.replace("-", "")
output = output.replace("\\r\\n\\r\\n", "")
output = output.replace("\\r\\n", " ")
#estas sustituciones extrañas tienen sentido ya que las suele incluir en el output

#eliminaciones de espacios,  desde que haya
output = output.replace("  ", "") #eliminamos de dos en dos, si queda alguno suelto se eliminara mas tarde

#eliminaciones de numeros
for i in range (10):
    output = output.replace(str(i), "")

#eliminacion de los puntos (versiones)
output = output.replace(".", "") 

#volvemos a eliminar los grupos de 2 ya que pueden haber quedado despues de la eliminacion de los numeros.
output = output.replace("  ", " ")
#si queda alguno suelto se convertira en un alto de linea para separar los nombres
output = output.replace(" ", "\n")

#lo guardamos en un .txt
librerias_instaladas = open("librerias_python.txt", "w+")
librerias_instaladas.write(output)
librerias_instaladas.close()