using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;
using MySql.Data.MySqlClient;
using Common.Cache;
using Common.DTO;

namespace Negocio
{
    public class Modelo
    {
        DConsulta Consulta = new DConsulta();
        private int cveusuario;
        private string nombreUsuario;
        private string nombreCompleto;
        private string apepaterno;
        private string apematerno;
        private string contraseña;

        public Modelo(int cveusuario, string nombreUsuario, string nombreCompleto, string apepaterno, string apematerno, string Contraseña)
        {
            this.cveusuario = cveusuario;
            this.nombreUsuario = nombreUsuario;
            this.nombreCompleto = nombreCompleto;
            this.apepaterno = apepaterno;
            this.apematerno = apematerno;
            this.contraseña = Contraseña;
        }

        public Modelo()
        {

        }

        public string editarUsuario()
        {
            try
            {
                Consulta.EditarPerfil(cveusuario, nombreUsuario, nombreCompleto, apepaterno, apematerno, contraseña);
                Usuario(nombreUsuario, contraseña);
                return "Tu perfil ha sido actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Nombre de usuario ya ha sido registrado. Intente con otro";
            }

        }
        public bool Usuario(string Usuario, string Contraseña)
        {
            return Consulta.ObtenerUsuario(Usuario, Contraseña);
        }
        public DataTable MostrarReservacion()
        {
            return Consulta.MostrarReservacion();
        }          
        public DataTable Clasificacion()
        {
            return Consulta.mostrarClasificacion();
        }
        public DataTable PeliculaB()
        {
            return Consulta.mostrarPeliculaB();
        }
        public DataTable PeliculaB15()
        {
            return Consulta.mostrarPeliculaB15();
        }
        public DataTable PeliculaC()
        {
            return Consulta.mostrarPeliculaC();
        }
        public DataTable PeliculaD()
        {
            return Consulta.mostrarPeliculaD();
        }
        public DataTable MostrarPeliculaDG()
        {
            return Consulta.mostrarPeliculasDG();
        }
        public DataTable MostrarUsuarios()
        {
            return Consulta.mostrarUsuario();
        }
        public DataTable MostrarSala()
        {
            return Consulta.mostrarSala();
        }
        public DataTable MostrarSalaCB()
        {
            return Consulta.mostrarSalaCB();
        }
        public int CapacidadSala (int CvePelicula)
        {
            return Consulta.capacidadSala(CvePelicula);
        }
        //
        //OBTENER NUMERO DE ASIENTOS RESERVADOS
        //
        public List<Asiento> ObtenerNumAsiento(int cveAsiento)
        {
            return Consulta.obtenerNumAsiento(cveAsiento);
        }
        //
        //OBTENER CLAVE CLASIFICACION
        //
        //public List<Peliculavar> ObtenerCveClasificacion()
        //{
        //    return Consulta.obtenerClasificacion();
        //}
        //
        //OBTENER CLAVE DE SALA 
        //
        public int obtenerClaveSala(int cvePelicula)
        {
            return Consulta.obtenercvesala(cvePelicula);
        }
        //
        //OBTENER CLAVE DE ASIENTO
        //
        public int obtenerCveAsiento(int cveSala, int numAsiento)
        {
            return Consulta.ObtenerCveAsiento(cveSala, numAsiento);
        }
        //
        //VALIDAD EDAD OBTENIDA BOOL
        //
       

        //INSERTAR, MODIFICAR Y ELIMINAR DATOS
        //
        public void agregarusuario(string nomusuario, string nomcompleto, string apePaterno, string apeMaterno, int Edad, string Contraseña)
        {
            Consulta.insertaUsuario(nomusuario, nomcompleto, apePaterno, apeMaterno, Edad, Contraseña);
        }
        public void InsertarReservacion(int CveUsuario, int CvePelicula, int CveAsiento)
        {
            Consulta.insertarRervacion(CveUsuario, CvePelicula, CveAsiento);

        }
        public void InsertarSala(string nombreSala, int capacidadSala, int cveClasificacion)
        {
            Consulta.insertarSala(nombreSala, capacidadSala, cveClasificacion);
        }
        public void insertarPelicula(string nombrePelicula, int cveSala)
        {
            Consulta.insertarPelicula(nombrePelicula, cveSala);
        }
        public void ActualizarAsiento(int cvepelicula, int numeroAsiento)
        {
            Consulta.ActualizarAsiento(cvepelicula, numeroAsiento);
        }
        public void desActualizarAsiento(int cvepelicula, int numeroAsiento)
        {
            Consulta.desActualizarAsiento(cvepelicula, numeroAsiento);
        }
        public void ActualizarSala(string Nombre_Sala, int capacidadSala, int cveClasificacion, int cveSala)
        {
            Consulta.ActualizarSala(Nombre_Sala, capacidadSala, cveClasificacion, cveSala);
        }
        public void ActualizarPelicula(string nombrePelicula, int cveSala, int cvePelicula)
        {
            Consulta.ModificarPelicula(nombrePelicula, cveSala, cvePelicula);
        }
        public void ElimanarUsuario(int CveUsuario)
        {
            Consulta.EliminarUsuario(CveUsuario);
        }
        public void EliminarReservacion(int cveRervacion)
        {
            Consulta.EliminarReservacion(cveRervacion);
        }
        public void EliminarSala(int cveSala)
        {
            Consulta.EliminarSala(cveSala);
        }
        public void EliminarPelicula(int cvePelicula)
        {
            Consulta.EliminarPelicula(cvePelicula);
        }
    }
}
