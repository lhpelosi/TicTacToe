/*
 * EndGameUI.cs - Class that interfaces the EndGamePanel
 * @author lhpelosi
 */

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour {

    public GameObject winnerText;

	public void playAgain()
    {
        SceneManager.LoadScene( "game", LoadSceneMode.Single );
    }
	
	public void backToTitle()
    {
        SceneManager.LoadScene( "title", LoadSceneMode.Single );
    }

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
