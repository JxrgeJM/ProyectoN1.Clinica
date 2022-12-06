using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoN1.Clinica.Datos;
using ProyectoN1.Clinica.Entidades;

namespace ProyectoN1.Clinica.LogicaNegocio
{
    public  class AdministradorEquipoMedico
    {
        public static List<EquipoMedico> Listar()
        {
            return EquipoMedicoDAL.Listar();
        }

        public static void AgregarEquipoMedico(EquipoMedico pEquipoMedico)
        {
            EquipoMedicoDAL.AgregarEquipoMedico(pEquipoMedico);
        }

    }
}
