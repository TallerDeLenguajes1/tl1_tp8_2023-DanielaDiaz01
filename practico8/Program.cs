using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using EspacioTarea;
internal class Program{
    private static void Main(string[] args){

        //1.Cree aleatoriamente N tareas pendientes
        List<Tarea> TareasPendientes = new();

        string? descripcion;

        Random rand = new(); 
        int cantTareas = rand.Next(3,8);
        for (int i=0; i<cantTareas; i++){
            Console.WriteLine("Ingrese la descripcion de la tarea: ");
            descripcion = Console.ReadLine();
            Tarea aux = new(i,descripcion /*"Tarea "+i */,rand.Next(30, 81));
            TareasPendientes.Add(aux);
        }
        Console.WriteLine("Tareas Pendientes");
        mostrarLista(TareasPendientes);

  
        //2.Desarrolle una interfaz para mover las tareas pendientes a realizadas
        List<Tarea> TareasRealizadas = new();

        moverTareas(TareasPendientes, TareasRealizadas);
        Console.WriteLine("\nTareas Pendientes");
        mostrarLista(TareasPendientes);
        Console.WriteLine("\nTareas Realizadas");
        mostrarLista(TareasRealizadas);


        //3.Desarrolle una interfaz para buscar tareas pendientes por descripción
        string? descri;
        Console.WriteLine("\nIngrese descripcion de la tarea: ");
        descri = Console.ReadLine();
        foreach(var tarea in TareasPendientes){
            if(tarea.Descripcion == descri){
                Console.WriteLine("Tareas Pendientes");
                Console.Write(tarea.mostrarTarea());
            }
        }


        //4. Guarde en un archivo de texto un sumario de las horas trabajadas por el empleado 
        //(sumatoria de la duración de las tareas)
        string nombreArchivo = "horasTrabajadas.txt";
        using (StreamWriter archivo = new(nombreArchivo, true)){
            int horasTrabajadas = cantHorasTrabajadas(TareasRealizadas);
            archivo.WriteLine($"Horas trabajadas: {horasTrabajadas}");
        }
    }


    public static void mostrarLista(List<Tarea> lista){
        foreach (var tarea in lista){
            Console.Write(tarea.mostrarTarea());
        }
    }

    public static void moverTareas(List<Tarea> TareasPendientes, List<Tarea> TareasRealizadas){
        string? respuesta;
        Console.WriteLine("Tareas Pendientes");
        for (int i=0; i<TareasPendientes.Count; i++){
            Console.Write(TareasPendientes[i].mostrarTarea());
            Console.WriteLine("Tarea realizada?(1=si, 0=no)");
            respuesta = Console.ReadLine();
            if (respuesta == "1"){
                TareasRealizadas.Add(TareasPendientes[i]);
            }
        }
        foreach (var tarea in TareasRealizadas){
            TareasPendientes.Remove(tarea); //elimina la tarea
        }
    }

    public static int cantHorasTrabajadas(List<Tarea> lista){
        int horasTrabajadas = 0;
        foreach(var tarea in lista){
            horasTrabajadas += tarea.Duracion;
        }
        return horasTrabajadas;
    }
}