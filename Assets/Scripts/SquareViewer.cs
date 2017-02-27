using UnityEngine;

public class SquareViewer : MonoBehaviour
{
    private int positionX = -1;
    private int positionY = -1;

    public BoardPresenter presenter;

	public void linkToPosition( int x, int y )
    {
        positionX = x;
        positionY = y;
    }

    void OnMouseDown()
    {
        presenter.choosePosition(positionX, positionY);
    }
}
