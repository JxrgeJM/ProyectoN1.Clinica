using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoN1.Clinica.Datos;
using ProyectoN1.Clinica.Entidades;

namespace ProyectoN1.Clinica.LogicaNegocio
{
    public class AdministradorMedico
    {
        public static List<Medico> Listar()
        {
            return MedicoDAL.Listar();
        }

        public static List<Medico> ListarPorClinica(int pIdClinica)
        {
            return MedicoDAL.ListarPorClinica(pIdClinica);
        }

        public static List<Medico> ListarDisponibles(int pIdClinica)
        {
            return MedicoDAL.ListarDisponibles(pIdClinica);
        }

        public static void Agregar(Medico pMedico)
        {
            MedicoDAL.Agregar(pMedico);
        }
    }
}
