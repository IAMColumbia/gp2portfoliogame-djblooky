using UnityEngine;

public enum WindowState { Still, BeingDragged, Released, NearAnotherWindow, Connected}

public class Window
{
    public string name;
    protected WindowState _state;
    public WindowState State
    {
        get { return _state; }
        set
        {
            if (_state != value)
            {
                this.Log(string.Format("{0} was: {1} now {2}", name, _state, value));
                _state = value;
            }
        }
    }

    public Window()
    {
        this.State = WindowState.Still;
    }

    public virtual void Log(string s)
    {
        Debug.Log(s);
    }

}
