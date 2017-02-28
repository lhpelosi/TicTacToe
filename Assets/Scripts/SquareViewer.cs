/*
 * SquareViewer.cs - Class that connects the square prefabs on interface with the board.
 * @author lhpelosi
 */

using UnityEngine;

public class SquareViewer : MonoBehaviour
{
    // Reference to the board presenter
    public BoardPresenter presenter;

    // Position referring the board coordinates
    private Coordinates position;

    /*
     * Attaches this particular square to the model coordinate system.
     * @param position Position in the board
     */
    public void linkToPosition( Coordinates position )
    {
        this.position = position;
    }

    // MouseDown calllback
    void OnMouseDown()
    {
        presenter.humanMove( position );
    }
}
