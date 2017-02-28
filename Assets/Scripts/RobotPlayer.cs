using System.Collections.Generic;

public class RobotPlayer
{
    // Defines the robot side ( cross or nought )
    public BoardModel.SquareType side;

    /*
     * Constructor
     * @param type Side of the robot
     */
    public RobotPlayer( BoardModel.SquareType side )
    {
        this.side = side;
	}

    /*
     * Decides the next play of the robot
     * @param board Current board state
     * @return Robot choice
     */
    public Coordinates decidesPlay( BoardModel board )
    {
        return decidesRandom( board );
    }

    private Coordinates decidesRandom( BoardModel board )
    {
        List<Coordinates> freePositions = new List<Coordinates>();

        foreach ( Coordinates position in board.getPositions() )
        {
            if ( board.at( position ) == BoardModel.SquareType.EMPTY )
            {
                freePositions.Add( position );
            }
        }
        
        System.Random random = new System.Random();
        return freePositions[ random.Next( freePositions.Count ) ];
    }
}
