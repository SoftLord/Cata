using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cata
{
    public partial class instalacionPythonYdependencias : Form
    {
        public instalacionPythonYdependencias()
        {
            InitializeComponent();
        }

        private void instalacionPythonYdependencias_Load(object sender, EventArgs e)
        {
            ComprobarArchivos();
        }

        private void ComprobarArchivos()
        {
            //comprobamos si tiene python 3 instalado
            if (Directory.Exists(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Programs\Python"))
            {
                //comprobamos que no sea Python 2
                if (Directory.Exists(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\Python\Python27"))
                {
                    MessageBox.Show("Este programa requiere la instalación de Python 3, ya que tiene usted Python 2 instalado, y varias dependecias.\n" +
                        "Para descargar Python 3 vaya a su página " +
                        "oficial o siga este enlace. https://www.python.org/downloads/", "Error en la instalación de Python", MessageBoxButtons.OK);
                    Application.Exit();
                }
                //es python 3
                else
                {
                    ProcessStartInfo ejecutarPip = new ProcessStartInfo(); //creamos un nuevo proceso a parte para ejecutar el programa pip.py
                    ejecutarPip.WindowStyle = ProcessWindowStyle.Hidden; //hacemos que la aparencia de la ventana sea escondida para que
                    ejecutarPip.FileName = "pip.bat";                  //no se vea la venta de la consola de comandos
                    Process.Start(ejecutarPip);
                    Thread.Sleep(2000);                                //le damos un margen de 2s para que cree el archivo

                    List<string> lista_librerias_necesarias = new List<string>()
                    {
                        "gTTS",
                        "wget",
                        "playsound",
                        "SpeechRecognition",
                        "pywhatkit",
                        "PyAudio"
                    }; //creamos una lista donde guardaremos los que necesitamos saber

                    StreamReader librerias_python = new StreamReader("librerias_python.txt");
                    string linea;
                    Boolean hecho = false;
                    while (!hecho)
                    {
                        linea = librerias_python.ReadLine();

                        if (linea == null) //fin del archivo
                        {
                            hecho = true;
                        }
                        else if (lista_librerias_necesarias.Contains(linea))
                        {
                            //eliminamos de la lisa las que tenemos instaladas
                            lista_librerias_necesarias.Remove(linea);
                        }
                    }

                    //miramos los elementos que quedaron
                    if (lista_librerias_necesarias.Any()) //any dice si contien datos o no, si hay algo devuelve true
                    {
                        string librerias_etiqueta = string.Join(", ", lista_librerias_necesarias); //pasamos la lista a string
                        etiquetaLibrerias.Text = "Necesita instalar las siguientes librerias:\n" +
                            librerias_etiqueta + "\nPara ello instale las librerias manualmente usando el comando " +
                            "pip install \"nombre_de_la_libreria\" (sin comillas) desde la terminal (cmd)";

                        StreamWriter archivoOpciones = new StreamWriter("opciones.txt");
                        archivoOpciones.Write("instalacion = false");
                        archivoOpciones.Close();
                    }
                    else
                    {
                        //Application.Exit();//si esta todo instalado lo cerramos
                        etiquetaLibrerias.Text = "Tiene usted todas las librerias instaladas.\n Puede cerrar y volver a abrir la aplicación.";

                        //abrimos el fichero para escribir en el
                        StreamWriter archivoOpciones = new StreamWriter("opciones.txt");
                        archivoOpciones.Write("instalacion = true");
                        archivoOpciones.Close();
                    }

                }
            }
            else
            {
                MessageBox.Show("Este programa requiere la instalación de Python 3 y varias dependecias.\nPara descargar Python 3 vaya a su " +
                    "página oficial o siga este enlace. " +
                    "https://www.python.org/downloads/", "Error en la instalación de Python", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

    }
}
