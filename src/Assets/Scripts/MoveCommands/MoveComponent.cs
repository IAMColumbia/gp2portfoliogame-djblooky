
public class MoveComponent
{
    protected int _X = 0, _Y = 0;

    public int X
    {
        get { return this._X; }
        protected set { _X = value; }
    }

    public int Y
    {
        get { return this._Y; }
        protected set { _Y = value; }
    }

    internal void MoveUp()
    {
        this.Y++;
    }

    internal void MoveRight()
    {
        this.X++;
    }

    internal void MoveDown()
    {
        this.Y--;
    }

    internal void MoveLeft()
    {
        this.X--;
    }
}
