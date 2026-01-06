namespace Domain.Player;

public record PlayerId(int Value);

public class Player
{
    private Player(PlayerName playerName)
    {
        Name = playerName;
    }

    public PlayerId? Id { get; private set; }
    public PlayerName Name { get; private set; }

    public static Player Create(PlayerName playerName)
    {
        return new Player(playerName);
    }
}
