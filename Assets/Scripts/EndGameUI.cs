/*
 * EndGameUI.cs - Class that interfaces the EndGamePanel
 * @author lhpelosi
 */

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour {

    // Object cointaining the text of the game result
    public GameObject winnerText;

    /*
     * "Play again" button callback
     */
    public void playAgain()
    {
        SceneManager.LoadScene( "game", LoadSceneMode.Single );
    }

    /*
     * "Back to title" button callback
     */
    public void backToTitle()
    {
        SceneManager.LoadScene( "title", LoadSceneMode.Single );
    }
    
    /*
     * Modify the winning text according to result
     * @param winner Who is the winner: cross, nought or draw (EMPTY)
     */
    public void setWinner( BoardModel.SquareType winner )
    {
        string text = "";
        switch ( winner )
        {
            case BoardModel.SquareType.EMPTY:
                text = "It's a draw!";
                break;
            case BoardModel.SquareType.CROSS:
                text = "Crosses are the winners!";
                break;
            case BoardModel.SquareType.NOUGHT:
                text = "Noughts are the winners!";
                break;
        }

        winnerText.GetComponent<Text>().text = text;
    }
}
