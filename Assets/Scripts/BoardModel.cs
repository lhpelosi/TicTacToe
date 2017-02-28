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
}
