using UnityEngine;

public class BoardPresenter
{
    // Reference to its model
    private BoardModel model;
    // Reference to its viewer
    private BoardViewer viewer;
    // Current turn
    private BoardModel.SquareType turn;

    /*
     * Constructor
     * param boardViewer Reference to its viewer
     */
    public BoardPresenter( BoardViewer boardViewer )
    {
        model = new BoardModel();
        viewer = boardViewer;
        turn = BoardModel.SquareType.CROSS;
    }

    /*
     * Action of the player of choosing a certain position on the board
     * @param position Board coordinates
     */
    public void choosePosition( Coordinates position )
    {
        if ( model.at( position ) != BoardModel.SquareType.EMPTY ) return;
        
        model.setPositionTo( position, turn );
        viewer.setPositionTo( position, turn );

        turn = BoardModel.swapType( turn );

        Debug.Log( model.computeWinner() );
    }
}
