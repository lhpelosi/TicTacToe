/*
 * SideChoiceUI.cs - Class that reacts to the SideChoicePanel buttons.
 * @author lhpelosi
 */

using UnityEngine;

public class SideChoiceUI : MonoBehaviour
{
    // References a next canvas to load
    public GameObject nextChoice;

    /*
     * Cross button callback
     */
    public void choseCross()
    {
        GameSettings.Instance.humanSide = BoardModel.SquareType.CROSS;
        proceed();
    }

    /*
     * Nought button callback
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
        nextChoice.SetActive( true );
        gameObject.SetActive( false );
    }
}
