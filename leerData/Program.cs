using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace leerData
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new AppVentaCursosContext())
            {
                var cursos = db.Curso.Include(c => c.InstructoresLink).ThenInclude(ci => ci.Instructor);//Sirve para incluir la tabla intermedia CursoInstructor y la tabla Instructor
                foreach(var curso in cursos)
                {
                    Console.WriteLine("Curso: " + curso.Titulo);
                    foreach(var inslink in curso.InstructoresLink)
                    {
                        Console.WriteLine("Profesor: " + inslink.Instructor.Nombre);
                    }
                }
            }
        }
    }
}
