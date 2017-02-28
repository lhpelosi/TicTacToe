using System.Collections.Generic;

public class BoardModel
{
    // The different types of squares and players
    public enum SquareType
    {
        EMPTY,
        CROSS,
        NOUGHT
    }
    
    // Matrix with the state of each board square
    public SquareType[,] squares;

    /*
     * Constructor
     */
    public BoardModel()
    {
        squares = new SquareType[3, 3];
        for (int x = 0; x < squares.GetLength(0); x++)
        {
            for (int y = 0; y < squares.GetLength(1); y++)
            {
                squares[x, y] = SquareType.EMPTY;
            }
        }
    }

    /*
     * Copy constructor
     */
    public BoardModel( BoardModel originalBoard )
    {
        squares = new SquareType[ 3, 3 ];
        for ( int x = 0; x < squares.GetLength( 0 ); x++ )
        {
            for ( int y = 0; y < squares.GetLength( 1 ); y++ )
            {
                squares[ x, y ] = originalBoard.squares[ x, y ];
            }
        }
    }

    /*
     * Get every possible coordinate position on the board
     * @return A list with positions
     */
    public List< Coordinates > getPositions()
    {
        List< Coordinates > positions = new List< Coordinates >();

        for ( int x = 0; x < squares.GetLength( 0 ); x++ )
        {
            for ( int y = 0; y < squares.GetLength( 1 ); y++ )
            {
                positions.Add( new Coordinates( x, y ) );
            }
        }

        return positions;
    }

    /*
     * Get the state of a specific position on the board
     * @param position Board position
     * @return State of position
     */
    public SquareType at( Coordinates position )
    {
        return squares[ position.x, position.y ];
    }

    /*
     * Set the state of a specific position on the board
     * @param position Board position
     * @param type State of position
     */
    public void setPositionTo( Coordinates position, SquareType type )
    {
        squares[ position.x, position.y ] = type;
    }

    /*
     * Get the oposite type of a given state
     * @param type Given type
     * @return Oposite type
     */
    public static SquareType swapType( SquareType type )
    {
        if ( type == BoardModel.SquareType.CROSS )
        {
            return BoardModel.SquareType.NOUGHT;
        }
        else if ( type == BoardModel.SquareType.NOUGHT )
        {
            return BoardModel.SquareType.CROSS;
        }
        else return type;
    }

    /*
     * Check who is the winner given the current configuration of the board
     * @return The type of the winner ( CROSS or NOUGHT ) or EMPTY if there is not a winner
     */
    public SquareType computeWinner()
    {
        int size = squares.GetLength( 0 );
        foreach ( SquareType type in new SquareType[]{ SquareType.CROSS, SquareType.NOUGHT } )
        {
            // Check each line
            for ( int x=0; x < size; x++ )
            {
                bool winner = true;
                for ( int y = 0; y < size; y++ )
                {
                    winner = winner && ( squares[ x, y ] == type );
                }
                if ( winner ) return type;
            }
            // Check each collumn
            for ( int y = 0; y < size; y++ )
            {
                bool winner = true;
                for ( int x = 0; x < size; x++ )
                {
                    winner = winner && ( squares[ x, y ] == type );
                }
                if ( winner ) return type;
            }
            // Check for diagonals
            bool winnerD1 = true;
            bool winnerD2 = true;
            for ( int i = 0; i < size; i++ )
            {
                winnerD1 = winnerD1 && ( squares[ i, i ] == type );
                winnerD2 = winnerD2 && ( squares[ i, size-1-i ] == type );
            }
            if ( winnerD1 || winnerD2 ) return type;
        }
        // When there is not a winner yet
        return SquareType.EMPTY;
    }
}
