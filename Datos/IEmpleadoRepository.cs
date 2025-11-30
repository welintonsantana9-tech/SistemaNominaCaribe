using System.Collections.Generic;
using SistemaNominaCaribe.Modelos;

namespace SistemaNominaCaribe.Datos // <<-- ¡TIENE QUE SER ESTE!
{
    public interface IEmpleadoRepository
    {
        void Agregar(Empleado empleado);
        List<Empleado> ObtenerTodos();
        void Actualizar(Empleado empleado);
        void Eliminar(int id);
    }
}