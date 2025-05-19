public static class Game
{
    private static GameState state;
    public static GameState State => state;

    public static void SetState(GameState newState) => state = newState;

    public enum GameState
    {
        Paused = -2,
        Lobby = -1,
        None = 0,
        Died = 1,
        Completed = 2,
    }
}
