using UnityEngine;
using UnityEngine.SceneManagement;

public class SideChoice : MonoBehaviour
{
    /*
     * Cross button action
     */
    public void choseCross()
    {
        GameSettings.Instance.humanSide = BoardModel.SquareType.CROSS;
        proceed();
    }

    /*
     * Nought button action
     */
    public void choseNought()
    {
        GameSettings.Instance.humanSide = BoardModel.SquareType.NOUGHT;
        proceed();
    }

    /*
     * Go to next step
     */
    private void proceed()
    {
        SceneManager.LoadScene( "game", LoadSceneMode.Single );
    }
}
