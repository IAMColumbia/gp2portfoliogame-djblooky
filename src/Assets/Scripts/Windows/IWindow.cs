using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWindow 
{
    string name { get; set; }
    WindowState _state { get; set; }
    WindowState State { get; set; }

    void Log(string s);
}
