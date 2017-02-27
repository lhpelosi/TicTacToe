public class BoardPresenter
{
    private BoardModel model;
    private BoardViewer viewer;
    private BoardModel.SquareType turn;

	// Use this for initialization
	public BoardPresenter( BoardViewer boardViewer )
    {
        model = new BoardModel();
        viewer = boardViewer;
        turn = BoardModel.SquareType.CROSS;
    }

    public void choosePosition(int x, int y)
    {
        // Only proceeds if the chosen position is empty
        if ( model.squares[x,y] != BoardModel.SquareType.EMPTY )
        {
            return;
        }

        model.squares[x, y] = turn;
        viewer.setPositionTo(x, y, turn);

        turn = BoardModel.swapType( turn );
    }
}
