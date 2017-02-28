using UnityEngine;

public class BoardPresenter
{
    // Reference to its model
    private BoardModel model;
    // Reference to its viewer
    private BoardViewer viewer;
    // Current turn
    private BoardModel.SquareType turn;
    // Robot opponent
    private RobotPlayer robot;

    /*
     * Constructor
     * param boardViewer Reference to its viewer
     */
    public BoardPresenter( BoardViewer boardViewer )
    {
        model = new BoardModel();
        viewer = boardViewer;
        turn = BoardModel.SquareType.CROSS;

        // Starts robot as second player
        robot = new RobotPlayer( BoardModel.swapType( turn ) );
    }

    /*
     * Action of the player of choosing a certain position on the board
     * @param position Board coordinates
     */
    public void choosePosition( Coordinates position )
    {
        if ( model.at( position ) != BoardModel.SquareType.EMPTY ) return;

        play( position, turn );

        Coordinates robotChoice = robot.decidesPlay( model );
        play( robotChoice, robot.side );
    }

    private void play( Coordinates position, BoardModel.SquareType player )
    {
        model.setPositionTo( position, player );
        viewer.setPositionTo( position, player );

        turn = BoardModel.swapType( turn );
        Debug.Log( model.computeWinner() );
    }
}
