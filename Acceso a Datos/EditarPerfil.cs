using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;
using Common.DTO;
using Negocio;

namespace Acceso_a_Datos
{
    public partial class EditarPerfil : Form 
    {

        public EditarPerfil()
        {
            InitializeComponent();
        }

        private void EditarPerfil_Load(object sender, EventArgs e)
        {
            cargarDatosUsuario();
            InicializarControlEditar();
        }

        private void cargarDatosUsuario()
        {
            //VISTA
            lbl_nombrecompleto.Text = Usuario.nombre_completo;
            lbl_apepaterno.Text = Usuario.apepaterno_usuario;
            lbl_apematerno.Text = Usuario.apematerno_usuario;
            lbl_nombreusuario.Text = Usuario.nombre_usuario;

            //EDITAR PANEL
            txt_nombrecompleto.Text = Usuario.nombre_completo;
            txt_apepaterno.Text = Usuario.apepaterno_usuario;
            txt_apematerno.Text = Usuario.apematerno_usuario;
            txt_nombreUsuario.Text = Usuario.nombre_usuario;
            txt_nuevacontraseña.Text = Usuario.contraseña;
            txt_confirmarContraseña.Text = Usuario.contraseña;
            txt_contraseñaactual.Text = "";
        }
        private void InicializarControlEditar()
        {
            llabel_editar.Text = "Editar";
            txt_nuevacontraseña.Enabled = false;
            txt_nuevacontraseña.UseSystemPasswordChar = true;
            txt_confirmarContraseña.Enabled = false;
            txt_confirmarContraseña.UseSystemPasswordChar = true;

        }

        private void Resetear()
        {
            cargarDatosUsuario();
            InicializarControlEditar();
        }

        private void llabel_editarPerfil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = true;
            cargarDatosUsuario();
        }

        private void llabel_editar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (llabel_editar.Text == "Editar")
            {
                llabel_editar.Text = "Cancel";
                txt_nuevacontraseña.Enabled = true;
                txt_nuevacontraseña.Text = "";
                txt_confirmarContraseña.Enabled = true;
                txt_confirmarContraseña.Text = "";
            }
            else if (llabel_editar.Text == "Cancel")
            {
                InicializarControlEditar();
                txt_nuevacontraseña.Text = Usuario.contraseña;
                txt_confirmarContraseña.Text = Usuario.contraseña;
            }
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (txt_nuevacontraseña.TextLength >= 5)
            {
                if (txt_nuevacontraseña.Text == txt_confirmarContraseña.Text)
                {
                    if (txt_contraseñaactual.Text == Usuario.contraseña)
                    {
                        var Modelo = new Modelo(
                            cveusuario: Usuario.cve_usuario,
                            nombreCompleto: txt_nombrecompleto.Text,
                            apepaterno: txt_apepaterno.Text,
                            apematerno: txt_apematerno.Text,
                            nombreUsuario: txt_nombreUsuario.Text,
                            Contraseña: txt_nuevacontraseña.Text
                            );
                        var Resultado = Modelo.editarUsuario();
                        MessageBox.Show(Resultado);
                        Resetear();
                        panel1.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Contraseña Actual Incorrecta");
                    }
                }
                else
                {
                    MessageBox.Show("Las Contraseñas no Coinciden");
                }
            }
            else
            {
                MessageBox.Show("La contraseña debe tener un minimo de 5 caracteres");
            }
            
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            Resetear();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
