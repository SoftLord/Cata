using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cata
{
    public partial class Cata : Form
    {
        public Cata()
        {
            InitializeComponent();
        }

        //definimos las rutas de los videos y sonidos
        String rutaAnimacion = @"logos\animacion.mp4";
        String rutaSonido = @"logos\sonido.wav";

        Boolean instalado = false; //este bool nos servira para activar o no el boton de hablar

        private void Cata_Load(object sender, EventArgs e)
        {
            try
            {
                StreamReader instalacionCompletada = new StreamReader("opciones.txt");

                string linea = instalacionCompletada.ReadLine();
                instalacionCompletada.Close();

                if (linea.Contains("true"))
                {
                    instalado = true; //todo la instalacion de dependencias correctas
                    iniciarYpausarVideo(rutaAnimacion, true); //iniciamos el video al iniciar la aplicacion
                }
                else if (linea.Contains("false"))
                {
                    //creamos un form que sera el de instalacion python y dependencias
                    instalacionPythonYdependencias Form = new instalacionPythonYdependencias();
                    Form.Show();
                }
                else
                {
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("Ha borrado usted archivos necesarios para su ejecución.\n Reinstale el programa",
                    "Error de archivos", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        private Boolean hecho = false;

        private void btnReproducir_Click(object sender, EventArgs e)
        {
            if (instalado)
            {
                if (!hecho)
                {
                    iniciarYpausarVideo(rutaAnimacion); //lo despausamos y al cabo de 2300 ms lo reanudamos

                    hecho = true;

                    iniciarCata();
                }

                else
                {
                    repSonido(rutaSonido); //solo reproducimos el sonido

                    iniciarCata(); //iniciamos la parte logica de cata, que está escrita en python
                }
            }
            //si no esta instalado no hara nada
        }

        private void iniciarCata()
        {
            ProcessStartInfo ejecutarCata = new ProcessStartInfo(); //creamos un nuevo proceso a parte para la ejecucion de cata en python
            ejecutarCata.WindowStyle = ProcessWindowStyle.Hidden; //hacemos que la aparencia de la ventana sea escondida para que
            ejecutarCata.FileName = "start.bat";                  //no se vea la venta de la consola de comandos
            Process.Start(ejecutarCata);
        }

        private void repSonido(String rutaAudio) //reproducimos el sonido o efecto de que esta escuchando
        {
            SoundPlayer simpleSound = new SoundPlayer(rutaAudio);
            simpleSound.Play();
        }

        private void iniciarVideo() => reproductor.Ctlcontrols.play();
        //inicio de la animacion

        private void pausarVideo() //esperamos 2300 ms que es el tiempo exacto calculado
                                   //                       y lo pausamos
        {
            Thread.Sleep(2300);
            reproductor.Ctlcontrols.pause();
        }

        public void iniciarYpausarVideo(String ruta, Boolean resetRuta = false)
        {
            if (resetRuta) //si queremos cambiar la ruta
            {
                reproductor.URL = ruta;
            }

            //e iniciamos y pausamos
            var iniciar = Task.Factory.StartNew(iniciarVideo);
            var pausar = Task.Factory.StartNew(pausarVideo);
        }

    }
}
