using System;
using System.ComponentModel.DataAnnotations; // Usaremos esto para futuras validaciones si se necesitan

namespace SistemaNominaCaribe.Modelos
{
    public class Empleado
    {
        [Key] // Marca la propiedad como clave primaria
        public int Id { get; set; }
        
        // La palabra 'required' elimina la advertencia CS8618
        public required string Nombre { get; set; }
        public required string Departamento { get; set; }
        public decimal SalarioBase { get; set; } // Salario Bruto
    }
}