using UnityEngine;

public enum CharacterState { Stopped, Moving, Jumping}

public class Character 
{
    protected CharacterState _state;
    public CharacterState State
    {
        get { return _state; }
        set
        {
            if (_state != value)
            {
                this.Log(string.Format("{0} was: {1} now {2}", this.ToString(), _state, value));
                _state = value;
            }
        }
    }

    public Character()
    {
        this.State = CharacterState.Stopped;
    }

    public virtual void Log(string s){

    }

}
