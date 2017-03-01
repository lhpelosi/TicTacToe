/*
 * GameSettings.cs - Store the player settings along the game.
 * @author lhpelosi
 */

public class GameSettings
{
    // Singleton instance
    private static GameSettings instance = null;

    // Settings to persist
    public BoardModel.SquareType humanSide;

    /*
     * Constructor
     */
    private GameSettings()
    {
        // Default settings
        humanSide = BoardModel.SquareType.CROSS;
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
