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

        public static void AgregarEspecialidad(ClinicaEspecialidad pClinicaEspecialidad)
        {
            ClinicaDAL.AgregarEspecialidad(pClinicaEspecialidad);
        }

        public static void BorrarEspecialidad(ClinicaEspecialidad pClinicaEspecialidad)
        {
            ClinicaDAL.BorrarEspecialidad(pClinicaEspecialidad);
        }

        public static List<TipoEspecialidad> ListarEspecialidad(int pIdClinica)
        {
            return ClinicaDAL.ListarEspecialidad(pIdClinica);
        }

        public static void AgregarMedicoEspecialista(ClinicaMedico pClinicaMedico)
        {
            ClinicaDAL.AgregarMedicoEspecialista(pClinicaMedico);
        }
    }
}
