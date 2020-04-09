public class MoveDownCommand : Command
{
    public MoveDownCommand()
    {
        this.CommandName = "Move Down";
    }

    public override void Execute(MoveComponent go)
    {
        go.MoveDown();
        base.Execute(go);
    }
}
