using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWindow 
{
    public string name { get; set; }
    WindowState _state { get; set; }
    public WindowState State { get; set; }

    void Log(string s);
}
