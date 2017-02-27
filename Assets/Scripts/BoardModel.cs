public class BoardModel
{

    public enum SquareType
    {
        EMPTY,
        CROSS,
        NOUGHT
    }

    public SquareType[,] squares;

    // Use this for initialization
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

    public static SquareType swapType( SquareType type ) 
    {
        if (type == BoardModel.SquareType.CROSS)
        {
            return BoardModel.SquareType.NOUGHT;
        }
        else if (type == BoardModel.SquareType.NOUGHT)
        {
            return BoardModel.SquareType.CROSS;
        }
        else return type;
    }
}
