using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Common.Cache;
using Common.DTO;

namespace Acceso_a_Datos
{
    public partial class Reservacion : Form
    {
        int numeroTotalSillas = 15;
        int contar = 0;
        static PictureBox[,] boton = new PictureBox[3, 5];
        static int cvepelicula;
        static int CveAsiento;
        static Modelo Consulta = new Modelo();
        
        public Reservacion()
        {
            InitializeComponent();
        }

        public void mostrarPeliculaB()
        {
            cb_pelicula.DataSource = Consulta.PeliculaB();
            cb_pelicula.DisplayMember = "nombre_pelicula";
            cb_pelicula.ValueMember = "cve_pelicula";
        }
        public void mostrarPeliculaB15()
        {
            cb_pelicula.DataSource = Consulta.PeliculaB15();
            cb_pelicula.DisplayMember = "nombre_pelicula";
            cb_pelicula.ValueMember = "cve_pelicula";
        }
        public void mostrarPeliculaC()
        {
            cb_pelicula.DataSource = Consulta.PeliculaC();
            cb_pelicula.DisplayMember = "nombre_pelicula";
            cb_pelicula.ValueMember = "cve_pelicula";
        }
        public void mostrarPeliculaD()
        {
            cb_pelicula.DataSource = Consulta.PeliculaD();
            cb_pelicula.DisplayMember = "nombre_pelicula";
            cb_pelicula.ValueMember = "cve_pelicula";
        }

        private void Reservacion_Load(object sender, EventArgs e)
        {
            if (Usuario.edad_usuario >= 12 && Usuario.edad_usuario < 15)
            {
                mostrarPeliculaB();
            }
            else if (Usuario.edad_usuario >= 15 && Usuario.edad_usuario < 18)
            {
                mostrarPeliculaB();
                mostrarPeliculaB15();
            }
            else if (Usuario.edad_usuario >= 18)
            {
                mostrarPeliculaC();
                mostrarPeliculaD();
            }
            else
            {
                MessageBox.Show("Peliculas no APTAS para menores");
            }
        }
        void crearPicture()
        {
            cvepelicula = (int)cb_pelicula.SelectedValue;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    boton[i, j] = new PictureBox();
                    boton[i, j].Width = 80;
                    boton[i, j].Height = 50;
                    boton[i, j].Top = i * 75;
                    boton[i, j].Left = j * 150;
                    boton[i, j].Image = Image.FromFile(@"C:\Users\jesus\Pictures\asientoOcupado.ico");
                    boton[i, j].Cursor = Cursors.Hand;
                    boton[i, j].Click += new System.EventHandler(_AsientoClick);
                    boton[i, j].BackColor = Color.White;
                    PicPanel(boton, i, j, panel1);

                    contar += 1;
                    boton[i, j].Tag = contar;


                    int CapacidadAsientos = Consulta.CapacidadSala((int)cb_pelicula.SelectedValue);
                    int Total = numeroTotalSillas - CapacidadAsientos;
                    

                    if (Total == 5)
                    {
                        if ((i == 2 && j == 4) || (i == 2 && j == 3) || (i == 2 && j == 2) || (i == 2 && j == 1) || (i == 2 && j == 0))
                        {
                            boton[i, j].Enabled = false;
                            boton[i, j].Image = null;
                        }

                    }
                    else if (Total == 4)
                    {
                        if ((i == 2 && j == 4) || (i == 2 && j == 3) || (i == 2 && j == 2) || (i == 2 && j == 1))
                        {
                            boton[i, j].Enabled = false;
                            boton[i, j].Image = null;
                        }
                    }
                    else if (Total == 3)
                    {
                        if ((i == 2 && j == 4) || (i == 2 && j == 3) || (i == 2 && j == 2))
                        {
                            boton[i, j].Enabled = false;
                            boton[i, j].Image = null;
                        }
                    }
                    else if (Total == 2)
                    {
                        if ((i == 2 && j == 4) || (i == 2 && j == 3))
                        {
                            boton[i, j].Enabled = false;
                            boton[i, j].Image = null;
                        }
                    }
                    else if (Total == 1)
                    {
                        if ((i == 2 && j == 4))
                        {
                            boton[i, j].Enabled = false;
                            boton[i, j].Image = null;
                        }
                    }

                    int CveSala = Consulta.obtenerClaveSala((int)cb_pelicula.SelectedValue);

                    foreach (var item in Consulta.ObtenerNumAsiento(CveSala))
                    {
                        if (item.numeroAsiento == (int)boton[i, j].Tag)
                        {
                            boton[i, j].BackColor = Color.Black;
                            boton[i, j].Enabled = false;
                        }
                    }

                }
            }
        }
        static void _AsientoClick(object sender, EventArgs e)
        {
            PictureBox silla = sender as PictureBox; //Aqui obtienes el control que lanzó el evento
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (boton[i, j] == silla)
                    {
                        if (boton[i, j].BackColor == Color.White)
                        {
                            boton[i, j].BackColor = Color.Black;
                            Consulta.ActualizarAsiento(cvepelicula, (int)boton[i, j].Tag);
                            int CveSala = Consulta.obtenerClaveSala(cvepelicula);
                            CveAsiento = Consulta.obtenerCveAsiento(CveSala, (int)boton[i, j].Tag);
                            MessageBox.Show("Asiento Seleccionado");
                            InhabilitarAsiento(silla);
                        }
                        else if (boton[i, j].BackColor == Color.Black)
                        {
                            boton[i, j].BackColor = Color.White;
                            Consulta.desActualizarAsiento(cvepelicula, (int)boton[i, j].Tag);
                            MessageBox.Show("Asiento Cancelado");
                            HabilitarAsiento();
                        }
                    }
                }
            }
        }
        static void PicPanel(PictureBox[,] boton, int i, int j, Panel panel)
        {
            panel.Controls.Add(boton[i, j]);
        }
        private void Btn_ReservarAsiento_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            crearPicture();
        }
        void LimpiarAsientos()
        {
            for (int i=0;i<3;i++)
            {
                for (int j=0; j<5;j++)
                {
                    boton[i, j].Image = null;
                    boton[i, j].Enabled = false;
                    boton[i, j].BackColor = Color.Empty;
                }
            }
        }
        static void InhabilitarAsiento(PictureBox silla)
        {
            for (int i=0;i<3;i++)
            {
                for (int j=0;j<5;j++)
                {
                    if (boton[i, j] == silla)
                    {
                        if (boton[i, j].BackColor == Color.Black)
                        {
                            boton[i, j].Enabled = true;
                        }
                    }
                    else
                    {
                        boton[i, j].Enabled = false;
                    }
                }
            }
        }
        static void HabilitarAsiento(
            )
        {
            for (int i=0; i<3;i++)
            {
                for (int j=0; j<5;j++)
                {
                    boton[i, j].Enabled = true;
                }
            }
        }
        private void btn_ConfirmaReservacion_Click(object sender, EventArgs e)
        {
            Consulta.InsertarReservacion(Usuario.cve_usuario, cvepelicula, CveAsiento);
            LimpiarAsientos();
            MessageBox.Show("Asiento reservado");
            this.Close();
        }
    }
}
