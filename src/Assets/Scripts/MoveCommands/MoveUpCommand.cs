public class MoveUpCommand : Command
{
    public MoveUpCommand()
    {
        this.CommandName = "Move Up";
    }

    public override void Execute(MoveComponent go)
    {
        go.MoveUp();
        base.Execute(go);
    }
}
