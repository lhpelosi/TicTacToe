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
        return decidesShallow( board );
    }

    // Decides next play randomly
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

    // Decides next play analysing one play forward
    private Coordinates decidesShallow( BoardModel board )
    {
        List<Coordinates> winningMoves = new List<Coordinates>();
        List<Coordinates> preventLosingMoves = new List<Coordinates>();
        List<Coordinates> neutralMoves = new List<Coordinates>();

        foreach ( Coordinates position in board.getPositions() )
        {
            // Tests only possible moves
            if ( board.at( position ) != BoardModel.SquareType.EMPTY ) continue;
            
            BoardModel testBoard = new BoardModel( board );

            // Tests for a winning move
            testBoard.setPositionTo( position, side );
            if ( testBoard.computeWinner() == side )
            {
                winningMoves.Add( position );
                continue;
            }

            // Tests for a move preventing a losing
            BoardModel.SquareType opponentSide = BoardModel.swapType( side );
            testBoard.setPositionTo( position, opponentSide );
            if ( testBoard.computeWinner() == opponentSide )
            {
                preventLosingMoves.Add( position );
                continue;
            }

            // Else it's just a neutral move
            neutralMoves.Add( position );
        }

        // Makes a random move in order of preference ( win > not lose )
        foreach ( List<Coordinates> moves in new List<Coordinates>[]{
            winningMoves, preventLosingMoves, neutralMoves } )
        {
            if ( moves.Count > 0 )
            {
                System.Random random = new System.Random();
                return moves[ random.Next( moves.Count ) ];
            }
        }

        // Error
        return new Coordinates( -1, -1 );
    }
}
