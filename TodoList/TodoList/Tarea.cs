using System;
using System.ComponentModel;

namespace TodoList;

public class Tarea : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private string _status;
    private string _tarea;

    public string status
    {
        get { return _status; }
        set
        {
            if (_status != value)
            {
                _status = value;
                OnPropertyChanged("status");
            }
        }
    }

    public string tarea
    {
        get { return _tarea; }
        set
        {
            if (_tarea != value)
            {
                _tarea = value;
                OnPropertyChanged("tarea");
            }
        }
    }

    public Tarea(string tarea, string status)
    {
        this.tarea = tarea;
        this.status = status;
      
    }    
}
