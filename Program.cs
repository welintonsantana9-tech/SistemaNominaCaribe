using System;
using SistemaNominaCaribe.Datos; // <<-- ¡ESTA LÍNEA ES CRUCIAL!
using SistemaNominaCaribe.Modelos;

namespace SistemaNominaCaribe
{
    public class Program // <<-- INICIO de la clase principal
    {
        public static void Main(string[] args)
        {
            // Ahora debe encontrar EmpleadoRepository sin problemas
            IEmpleadoRepository repositorio = new EmpleadoRepository();
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== SERVICIOS CORPORATIVOS CARIBE SRL ===");
                Console.WriteLine("1. Agregar Empleado");
                Console.WriteLine("2. Listar Empleados");
                Console.WriteLine("3. Generar Reporte de Nómina (Cálculos)");
                Console.WriteLine("4. Eliminar Empleado");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                string? opcion = Console.ReadLine()?.Trim();

                switch (opcion)
                {
                    case "1":
                        AgregarEmpleado(repositorio);
                        break;
                    case "2":
                        ListarEmpleados(repositorio);
                        break;
                    case "3":
                        GenerarNomina(repositorio);
                        break;
                    case "4":
                        EliminarEmpleado(repositorio);
                        break;
                    case "5":
                        continuar = false;
                        break;
                }
            }
        } // <<-- FIN del método Main

        private static void AgregarEmpleado(IEmpleadoRepository repo)
        {
            Console.WriteLine("\n--- Nuevo Empleado ---");
            Console.Write("Nombre: ");
            string? nombre = Console.ReadLine()?.Trim();
            
            Console.Write("Departamento: ");
            string? depto = Console.ReadLine()?.Trim();
            
            Console.Write("Salario Base: ");
            if (!decimal.TryParse(Console.ReadLine()?.Trim(), out decimal salario) || salario < 0)
            {
                Console.WriteLine("Error: Salario inválido. Debe ser un número positivo.");
                Console.ReadKey();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(depto))
            {
                Console.WriteLine("Error: Nombre y Departamento no pueden estar vacíos.");
                Console.ReadKey();
                return;
            }

            var emp = new Empleado { Nombre = nombre, Departamento = depto, SalarioBase = salario };
            repo.Agregar(emp);
            Console.WriteLine("Empleado guardado en SQL Server.");
            Console.ReadKey();
        }

        private static void ListarEmpleados(IEmpleadoRepository repo)
        {
            var lista = repo.ObtenerTodos();
            Console.WriteLine("\n--- Lista de Empleados ---");
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
            }
            else
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-15}", "ID", "Nombre", "Departamento", "Salario Base");
                Console.WriteLine(new string('-', 55));
                foreach (var emp in lista)
                {
                    Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-15:N2}", emp.Id, emp.Nombre, emp.Departamento, emp.SalarioBase);
                }
            }
            Console.ReadKey();
        }

        private static void GenerarNomina(IEmpleadoRepository repo)
        {
            var empleados = repo.ObtenerTodos();
            decimal totalNetoPagado = 0;

            Console.WriteLine("\n=== REPORTE MENSUAL DE NÓMINA ===");
            Console.WriteLine("{0,-20} {1,-15} {2,-15} {3,-15} {4,-15}", "Empleado", "S. Bruto", "AFP (2.87%)", "ARS (3.04%)", "S. Neto");
            Console.WriteLine(new string('-', 85));

            foreach (var emp in empleados)
            {
                // Cálculos según el PDF
                decimal afp = emp.SalarioBase * 0.0287m;
                decimal ars = emp.SalarioBase * 0.0304m;
                decimal totalDeducciones = afp + ars;
                decimal salarioNeto = emp.SalarioBase - totalDeducciones;

                totalNetoPagado += salarioNeto;

                Console.WriteLine("{0,-20} {1,-15:N2} {2,-15:N2} {3,-15:N2} {4,-15:N2}", 
                    emp.Nombre, emp.SalarioBase, afp, ars, salarioNeto);
            }
            Console.WriteLine(new string('-', 85));
            Console.WriteLine($"Total Neto a Pagar por la Empresa: {totalNetoPagado:C}");
            Console.ReadKey();
        }

        private static void EliminarEmpleado(IEmpleadoRepository repo)
        {
            Console.Write("Ingrese el ID del empleado a eliminar: ");
            if (int.TryParse(Console.ReadLine()?.Trim(), out int id))
            {
                repo.Eliminar(id);
                Console.WriteLine("Comando ejecutado. Verifique la lista.");
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
            Console.ReadKey();
        }

    } // <<-- FIN de la clase principal Program
} // <<-- FIN del namespace SistemaNominaCaribe