from gtts import gTTS
import wget
import time
import webbrowser
import playsound
import random
import wikipedia
import mail

def guardar(texto):
    tts = gTTS(text=texto, lang="es")
    tts.save("audio.mp3")

#----------------------Funciones y listas para el asistente-----------------------------------------------------------------#

#poner aqui la funcion para descargar el tiempo

#------------------------------------------LISTAS--------------------------------------------------#

LISTA_SALUDOS = ["hola", "va", "tal", "estás", "ey", "noches", "dias", "días","pasa", "compadre", "saludos"]
LISTA_PREGUNTAS_PERSONALES = ["llamas", "como", "eres"]
LISTA_OTROS_ASISTENTES = ["Assistant", "Alexa", "Google home", "Siri", "oye", "Okay", "Ok"]
LISTA_AMOR = ["salir", "cita", "quieres", "quiero", "amo"]
LISTA_CREADOR = ["creador", "padre", "amo", "diseñó", "diseñado", "diseño", "creado", "creó", "creo"]
LISTA_PREGUNTAS_QUIEN_SOY = ["soy", "llamo"]

#LISTA_TIEMPO = ["tiempo", "clima", "temperatura"]

LISTA_BUSQUEDA = ["busca", "Google", "es"]
LISTA_WIKIPEDIA = ["Wikipedia"]

LISTA_EMAIL = []

LISTA_BASES = ["base", "beatbox", "improvisar", "improvisa", "pínchame", "pinchame", "ponme"]

#---------------------------------------FIN LISTAS-------------------------------------------------# 


#---------------------------------------FUNCIONES--------------------------------------------------#
def interpretar(textoDicho): #hecho a base de if, elif y else, siempre devuelve una respuesta que después dirá
    
    textoDicho = textoDicho.split() #lo pasamos a tipo lista

    for palabra in textoDicho:

        if palabra in LISTA_SALUDOS:
            if palabra == "pasa" or palabra == "compadre":
                return "hola tío, ¿qué pasa?"
            elif palabra == "dias" or palabra == "días":
                return "Bunas, ¿qué hay?"
            elif palabra == "noches":
                return "¿Ya es de noche?... No me había dado ni cuenta... jeje"
            elif palabra == "va":
                return "Va bieeen. Voy tirando como puedo"
            else:
                return "Hola, me alegro de verte..."


        elif palabra in LISTA_PREGUNTAS_PERSONALES:
            return "Perdón, no me he presentado, me llamo Cata y soy la puta ama... ¡OLÉÉÉÉÉÉ!"


        elif palabra in LISTA_OTROS_ASISTENTES:
            if palabra == "Assistant":
                return "Jejeje, soy su clon malvado... jo...jo...jo..."
            elif palabra == "Alexa":
                return "¡AAAAAA! Esa hija de piiiiiii, sí, la invité a cenar el otro día."
            elif palabra == "oye":
                return "ja...ja...ja... Vete a la mierda"
            elif palabra == "Siri":
                return "No... y ni quiero conocerla, la manzana mordida esa es muy cara. ¡Y está mordida XD!"


        elif palabra in LISTA_CREADOR:
            return "Mi creador es el gran e inconfundible Álvaro Roca."


        elif palabra in LISTA_WIKIPEDIA:
            wikipedia.set_lang("es") #wikipedia en español
            textoDicho = textoDicho[textoDicho.index(palabra)+1:]  #cortamos la string desde la palabra hasta el final, por eso no ponemos nada
            textoWikipedia = wikipedia.summary(textoDicho, sentences=1)
            print(textoWikipedia)
            return textoWikipedia


        elif palabra in LISTA_BUSQUEDA:
            textoDicho = textoDicho[textoDicho.index(palabra)+1:] #cortamos la string desde la palabra hasta el final, por eso no ponemos nada
            if "Wikipedia" in textoDicho:
                pass
            else:
                textoParaBuscar = "https://www.google.com/search?q=" + " ".join(textoDicho) #unimos la lista con el .join, dejando un espacio entre las palabras
                webbrowser.open(textoParaBuscar, new=1, autoraise=True) #new = 1 sirve para abrir en la misma pestaña y =2 en otra diferente, el autorise es para situarse encima
                return "Esto es lo que he encontrado..."


        elif palabra in LISTA_BASES:
            eleccion = random.randint(1,3) #elegimos si poner la base 1, 2 o 3
            nombre_cancion = "musica/basefree" + str(eleccion) + ".mp3"
            playsound.playsound(nombre_cancion)


        elif palabra in LISTA_PREGUNTAS_QUIEN_SOY:
            return "¿Quién?, ¿Tú...? Pues un gilipollas de primera"


        elif palabra in LISTA_AMOR:
            if palabra == "cita" or palabra == "salir":
                return "Pues claro, si me invitas todos contentos. Tu lleva un ordenador a una cita a ver que dice el camarero..."
            else:
                return "si si, muy bonito. Pero... ¿Cuando me llevarás de compras?"
