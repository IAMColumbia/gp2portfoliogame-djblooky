using UnityEngine;

public class UnityWindow : Window, ILog
{
    protected GameObject _gameObject;
    public bool ShowDebug { get; set; }

    public UnityWindow(GameObject g) : base()
    {
        _gameObject = g;
        ShowDebug = true;
    }

    public override void Log(string s)
    {
        if (ShowDebug) Debug.Log(s);
    }

}
