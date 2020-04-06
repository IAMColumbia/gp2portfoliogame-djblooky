using UnityEngine;

public class UnityCharacter : Character, ILog
{
    protected GameObject _gameObject;
    public bool ShowDebug { get; set; }

    public UnityCharacter(GameObject g) : base()
    {
        _gameObject = g;
    }

    public override void Log(string s)
    {
        if (ShowDebug) Debug.Log(s);
    }

}
