import speech_recognition as reconocedorDeVoz #libreria para pasar de voz a texto
import voz                                    #libreria propia que usaremos para toda la parte del motor de busqueda
import playsound                              #libreria para reproducir el mp3
import sys

r = reconocedorDeVoz.Recognizer()

try:
    #si se ejecuta directamente habrá como máximo 9 segundos
    if __name__ == "__main__":
        with reconocedorDeVoz.Microphone() as fuenteEntrada:
            print ("Di algo")
            audio = r.listen(fuenteEntrada, timeout=9) #escucha lo que dices durante como máximo 9 segundos
            print("Procesando...")

    #sino (se ejecuta desde la interfaz) no habrá límite de tiempo
    else: 
        with reconocedorDeVoz.Microphone() as fuenteEntrada:
            print ("Di algo")
            audio = r.listen(fuenteEntrada) #escucha lo que dices sin limite de tiempo
            print("Procesando...")


    try:
        textoADecir = r.recognize_google(audio, language="es-ES") #la ultima parte es la parte que procesa lo que hemos dicho con la voz de google, en español
        print(textoADecir)

        #procesamient de lo que se ha dicho y lo guardamos
        respuesta = voz.interpretar(textoADecir ) #desde la libreria propia lo procesamos, le ponemos el otro parametro para que le entre un elemento de tipo lista. Y ademas lo guardamos
        voz.guardar(respuesta)

    except:
        print(sys.exc_info()[0]) #mostramos el error, si es que sucede.
        voz.guardar("Lo siento, no te he entendido.")

    playsound.playsound("audio.mp3") #reproducimos el audio que contiene la respuesta

except:
    voz.guardar("No se ha encontrado ningún dispositivo de entrada. Compruebe que el micrófono esté bien conectado.")
    playsound.playsound("audio.mp3")