using System.Collections.Generic;
using System.Linq;
using SistemaNominaCaribe.Modelos;

namespace SistemaNominaCaribe.Datos
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        public void Agregar(Empleado empleado)
        {
            using (var context = new NominaContext())
            {
                // CORRECCIÓN FINAL: Esto asegura que la tabla se cree antes de guardar.
                context.Database.EnsureCreated(); 
                
                context.Empleados.Add(empleado);
                context.SaveChanges();
            }
        }

        public List<Empleado> ObtenerTodos()
        {
            using (var context = new NominaContext())
            {
                // Esto es clave para que la tabla exista al listar
                context.Database.EnsureCreated();
                return context.Empleados.ToList();
            }
        }

        public void Actualizar(Empleado empleado)
        {
            using (var context = new NominaContext())
            {
                context.Empleados.Update(empleado);
                context.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var context = new NominaContext())
            {
                var empleado = context.Empleados.Find(id);
                if (empleado != null)
                {
                    context.Empleados.Remove(empleado);
                    context.SaveChanges();
                }
            }
        }
    }
}