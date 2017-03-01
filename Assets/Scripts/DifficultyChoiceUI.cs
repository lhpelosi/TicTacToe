/*
 * SideChoiceUI.cs - Class that reacts to the DifficultyChoicePanel buttons.
 * @author lhpelosi
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyChoiceUI : MonoBehaviour
{
    /*
     * Easy button callback
     */
    public void choseEasy()
    {
        GameSettings.Instance.difficulty = GameSettings.Difficulty.EASY;
        proceed();
    }

    /*
     * Normal button callback
     */
    public void choseNormal()
    {
        GameSettings.Instance.difficulty = GameSettings.Difficulty.NORMAL;
        proceed();
    }
    /*
     * Hard button callback
     */
    public void choseHard()
    {
        GameSettings.Instance.difficulty = GameSettings.Difficulty.HARD;
        proceed();
    }

    /*
     * Start the game
     */
    private void proceed()
    {

        SceneManager.LoadScene( "game", LoadSceneMode.Single );
    }
}
