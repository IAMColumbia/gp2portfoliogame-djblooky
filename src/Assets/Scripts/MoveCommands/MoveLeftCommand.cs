public class MoveLeftCommand : Command
{
    public MoveLeftCommand()
    {
        this.CommandName = "Move Left";
    }

    public override void Execute(MoveComponent go)
    {
        go.MoveLeft();
        base.Execute(go);
    }
}
