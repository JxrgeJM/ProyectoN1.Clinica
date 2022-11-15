using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoN1.Clinica.Datos;
using ProyectoN1.Clinica.Entidades;

namespace ProyectoN1.Clinica.LogicaNegocio
{
    public class AdministradorClinica
    {
        public static List<Entidades.Clinica> Listar()
        {
            return ClinicaDAL.Listar();
        }

        public static void Modificar(Entidades.Clinica pClinica)
        {
            ClinicaDAL.Modificar(pClinica);
        }

        public static void AgregarEspecialidad(int pIdClinica, int pIdEspecialidad)
        {
            ClinicaDAL.AgregarEspecialidad(pIdClinica, pIdEspecialidad);
        }

        public static void BorrarEspecialidad(int pIdClinica, int pIdEspecialidad)
        {
            ClinicaDAL.BorrarEspecialidad(pIdClinica, pIdEspecialidad);
        }

        public static List<TipoEspecialidad> ListarEspecialidad(int pIdClinica)
        {
            return ClinicaDAL.ListarEspecialidad(pIdClinica);
        }
    }
}
