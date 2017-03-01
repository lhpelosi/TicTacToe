/*
 * GameSettings.cs - Store the player settings along the game.
 * @author lhpelosi
 */

public class GameSettings
{
    public enum Difficulty
    {
        EASY,
        NORMAL,
        HARD
    }

    // Singleton instance
    private static GameSettings instance = null;

    // Settings to persist
    public BoardModel.SquareType humanSide;
    public Difficulty difficulty;

    /*
     * Constructor
     */
    private GameSettings()
    {
        // Default settings
        humanSide = BoardModel.SquareType.CROSS;
        difficulty = Difficulty.NORMAL;
    }
	
    /* 
     * Singleton instance getter
     */
	public static GameSettings Instance
    {
        get
        {
            if ( instance == null )
            {
                instance = new GameSettings();
            }
            return instance;
        }
    }
}
