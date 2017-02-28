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

        // Starts robot as opposite player
        robot = new RobotPlayer( BoardModel.swapType( GameSettings.Instance.humanSide ) );
    }

    /*
     * Action of the human player choosing a certain position on the board
     * @param position Board coordinates
     */
    public void humanMove( Coordinates position )
    {
        if ( turn != GameSettings.Instance.humanSide ) return;
        if ( model.at( position ) != BoardModel.SquareType.EMPTY ) return;

        play( position );
    }
    
    /*
     * Action of the robot player
     */
    public void robotMove()
    {
        if ( turn != robot.side ) return;

        Coordinates robotChoice = robot.decidesPlay( model );
        play( robotChoice );
    }

    /*
     * Make a move
     * @param position Board coordinates
     */
    private void play( Coordinates position )
    {
        model.setPositionTo( position, turn );
        viewer.setPositionTo( position, turn );

        turn = BoardModel.swapType( turn );
        Debug.Log( model.computeWinner() );
    }
}
