/*
 * BoardViewer.cs - Class responsible for the board visualization, connecting with the Unity interface.
 * @author lhpelosi
 */

using UnityEngine;

public class BoardViewer : MonoBehaviour
{
    // Prefab for the interactive squares
    public GameObject squarePrefab;
    // Object for the end game screen
    public GameObject endGameCanvas;
    // Sprites for each square state
    public Sprite emptySprite;
    public Sprite crossSprite;
    public Sprite noughtSprite;

    // Matrix of the interactive squares objects
    private GameObject[,] squares;
    // Reference to its presenter
    private BoardPresenter presenter;

    /*
     * Initializer
     */
    void Start ()
    {
        presenter = new BoardPresenter(this);
        const float SPACING = 2.5f;
        squares = new GameObject[3, 3];

        // Instantiate each of the interactive squares and position them on the screen
        for (int x = 0; x < squares.GetLength(0); x++)
        {
            for (int y = 0; y < squares.GetLength(1); y++)
            {
                GameObject square = (GameObject)Instantiate(squarePrefab, transform.position, transform.rotation);
                square.transform.parent = transform;
                square.transform.Translate(-SPACING + SPACING * x, -SPACING + SPACING * y, 0);
                SquareViewer squareViewer = square.GetComponent<SquareViewer>();
                squareViewer.linkToPosition( new Coordinates( x, y ) );
                squareViewer.presenter = presenter;
                squareViewer.GetComponent<SpriteRenderer>().sprite = emptySprite;

                squares[x, y] = square;
            }
        }
    }

    void Update()
    {
        if ( presenter == null ) return;

        // The robot might play if it can
        presenter.robotMove();
    }

    /*
     * Change the rendering of a square for a type ( cross or nought )
     * @param position The position on the board
     * @param type The type of the square ( cross or nought )
     */
    public void setPositionTo( Coordinates position, BoardModel.SquareType type )
    {
        SpriteRenderer renderer = squares[ position.x, position.y ].GetComponent<SpriteRenderer>();
        if ( type == BoardModel.SquareType.CROSS )
        {
            renderer.sprite = crossSprite;
        }
        else if ( type == BoardModel.SquareType.NOUGHT )
        {
            renderer.sprite = noughtSprite;
        }
    }

    public void endGame( BoardModel.SquareType winner )
    {
        endGameCanvas.SetActive( true );
        endGameCanvas.GetComponent<EndGameUI>().setWinner( winner );
    }
}