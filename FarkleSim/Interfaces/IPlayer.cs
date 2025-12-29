namespace FarkleSim
{
    public interface IPlayer
    {
        List<Dice> Dice { get; }

        int PlayTurn();
    }
}