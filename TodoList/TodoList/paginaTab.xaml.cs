using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TodoList;

public partial class paginaTab : ContentPage, INotifyPropertyChanged
{
    string pendiente = "";
    string estado = "";
    int cantidad;
   
    private ObservableCollection<Tarea> toDoList;

    public ObservableCollection<Tarea> ToDoList
    {
        get { return toDoList; }
        set
        {
            toDoList = value;
            OnPropertyChanged(nameof(ToDoList));
        }
    }


    public paginaTab()
    {
        InitializeComponent();
        BindingContext = this;
        toDoList = new ObservableCollection<Tarea>();
        listaTareas.ItemsSource = ToDoList;
        Txtcantidad.Text = "0";
    }

    void btnAgregar_Clicked(System.Object sender, System.EventArgs e)
    {

        pendiente = txtTarea.Text;
        if (!string.IsNullOrEmpty(pendiente))
        {
            Tarea homework = new Tarea(pendiente,estado);
            ToDoList.Add(homework);
            listaTareas.ItemsSource = toDoList;
            txtTarea.Text = "";
            DisplayAlert("Succesfull", "Tarea creada con exito", "OK");
            Txtcantidad.Text = ToDoList.Count().ToString();
        }
        else
        {
            DisplayAlert("PROBLEM", "Ingresa una tarea", "OK");
        }

    }

    void btnOk_Clicked(System.Object sender, System.EventArgs e)
    {

        Button btnOk = (Button)sender; // Obtener la referencia al botón que se hizo clic

        // Obtener el control lblPrincipal dentro del contenedor ViewCell
        Label lblPrincipal = (Label)btnOk.Parent.FindByName("lblPrincipal");

        if (lblPrincipal != null)
        {
            // Acceder a las propiedades del control lblPrincipal
            string labelText = lblPrincipal.Text;
            // Hacer algo con la etiqueta...
            lblPrincipal.TextColor = Color.FromRgb(0,255,0);
        }
        DisplayAlert("Complete", "Tarea Completada", "OK");

    }

    private async void btnEliminar_Clicked(System.Object sender, System.EventArgs e)
    {
        // Obtener el botón que se ha hecho clic
        Button btnEliminar = (Button)sender;

        // Obtener la tarea asociada al botón
        Tarea tarea = (Tarea)btnEliminar.BindingContext;

        // Mostrar una alerta de confirmación antes de eliminar la tarea
        bool respuesta = await DisplayAlert("Eliminar Tarea", "¿Estás seguro de que deseas eliminar esta tarea?", "Sí", "No");

        if (respuesta)
        {
            // Eliminar la tarea de la lista o realizar cualquier otra lógica de eliminación
            ToDoList.Remove(tarea);
        }

        Txtcantidad.Text = ToDoList.Count().ToString();

    }

    void btnPendiente_Clicked(System.Object sender, System.EventArgs e)
    {

        Button btnOk = (Button)sender; // Obtener la referencia al botón que se hizo clic

        // Obtener el control lblPrincipal dentro del contenedor ViewCell
        Label lblPrincipal = (Label)btnOk.Parent.FindByName("lblPrincipal");

        if (lblPrincipal != null)
        {
            // Acceder a las propiedades del control lblPrincipal
            string labelText = lblPrincipal.Text;
            // Hacer algo con la etiqueta...
            lblPrincipal.TextColor = Color.FromRgb(255, 165, 0);
        }
        DisplayAlert("Complete", "Tarea marcada como pendiente", "OK");


    }




}
