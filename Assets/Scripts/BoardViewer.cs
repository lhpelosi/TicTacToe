using UnityEngine;

public class BoardViewer : MonoBehaviour
{

    public GameObject squarePrefab;
    public Sprite emptySprite;
    public Sprite crossSprite;
    public Sprite noughtSprite;

    private GameObject[,] squares;
    private BoardPresenter presenter;

    // Use this for initialization
    void Start ()
    {
        presenter = new BoardPresenter(this);
        const float SPACING = 2.5f;
        squares = new GameObject[3, 3];

        for (int x = 0; x < squares.GetLength(0); x++)
        {
            for (int y = 0; y < squares.GetLength(1); y++)
            {
                GameObject square = (GameObject)Instantiate(squarePrefab, transform.position, transform.rotation);
                square.transform.parent = transform;
                square.transform.Translate(-SPACING + SPACING * x, -SPACING + SPACING * y, 0);
                SquareViewer squareViewer = square.GetComponent<SquareViewer>();
                squareViewer.linkToPosition(x, y);
                squareViewer.presenter = presenter;
                squareViewer.GetComponent<SpriteRenderer>().sprite = emptySprite;

                squares[x, y] = square;
            }
        }
    }

    public void setPositionTo( int x, int y, BoardModel.SquareType type )
    {
        SpriteRenderer renderer = squares[x, y].GetComponent<SpriteRenderer>();
        if ( type == BoardModel.SquareType.CROSS )
        {
            renderer.sprite = crossSprite;
        }
        else if ( type == BoardModel.SquareType.NOUGHT )
        {
            renderer.sprite = noughtSprite;
        }
    }
}