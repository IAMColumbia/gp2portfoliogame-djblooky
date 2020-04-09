public class MoveRightCommand : Command
{
    public MoveRightCommand()
    {
        this.CommandName = "Move Right";
    }

    public override void Execute(MoveComponent go)
    {
        go.MoveRight();
        base.Execute(go);
    }
}
