 Sistema de Nómina del Caribe en C# (INF 512)

Este proyecto es la implementación de un sistema de nómina empresarial, desarrollado en C# con arquitectura limpia, utilizando Entity Framework Core y una base de datos SQLite.

Funcionalidades Implementadas

El sistema ofrece un menú interactivo en consola para gestionar y calcular la nómina de los empleados.

1.  **Agregar Empleado (CRUD)**: Permite ingresar nuevos empleados con su salario base.
2.  **Listar Empleados (CRUD)**: Muestra el listado completo de los empleados registrados.
3.  **Generar Reporte de Nómina (Cálculos)**: Calcula las deducciones y el salario neto de todos los empleados y presenta un reporte mensual.
4.  **Eliminar Empleado (CRUD)**: Permite dar de baja un empleado de la base de datos.

## 📊 Cálculos de Deducciones

Los cálculos de nómina se basan en la legislación de seguridad social:

| Deducción | Porcentaje Aplicado |
| :--- | :--- |
| **AFP (Seguro de Pensión)** | 2.87% del Salario Bruto |
| **ARS (Seguro de Salud)** | 3.04% del Salario Bruto |
| **Salario Neto** | Salario Bruto - (AFP + ARS) |

## 💻 Tecnologías Utilizadas

* **Lenguaje:** C# (.NET 8)
* **Base de Datos:** SQLite
* **ORM:** Entity Framework Core
