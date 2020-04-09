using UnityEngine;

public abstract class Command : ICommand
{
    public string CommandName;

    public Command()
    {
        CommandName = "Base Command";
    }

    public virtual void Execute(MoveComponent go)
    {
        this.Log();
    }

    protected virtual string Log()
    {
        //log basic command to console
        return $"{this.CommandName} executed";
    }

    protected virtual void Log(MoveComponent go)
    {
        //log basic command to console
        Debug.Log($"{this.Log()} executed on {go}");
    }
}
