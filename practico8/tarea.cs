namespace EspacioTarea; 

public class Tarea {
    private int tareaID; 
    private string? descripcion;
    private int duracion;


    /*El constructor tiene el mismo nombre que la clase (Tarea) y no tiene tipo de 
    retorno. Recibe tres parámetros (tareaID, descripciony duracion) que se 
    utilizan para inicializar los atributos de la clase.Se utiliza la palabra clave 
    this para referir a los atributos de la instancia actual de la clase.*/
    public Tarea(int tareaID, string descripcion, int duracion ){
        this.TareaID = tareaID;
        this.descripcion = descripcion;
        this.duracion = duracion;
    }

    public int TareaID { get => tareaID; set => tareaID = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public int Duracion { get => duracion; set => duracion = value; }

    public string mostrarTarea(){
        string texto = $"\nID:{TareaID} \nDescripcion:{Descripcion} \nDuracion:{Duracion} \n" ;
        return texto;
    }
}
