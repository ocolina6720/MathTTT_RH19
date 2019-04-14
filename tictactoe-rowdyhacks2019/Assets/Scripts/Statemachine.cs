using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statemachine : MonoBehaviour
{
    public gameManager gm;
    public enum gamestate {
        START,
        WAITINGFORANSWER,
        RESULT, 
        END 
    };
    public gamestate gstate;
    public GameObject InputPanel;
    public GameObject TicTacToePanel;
    //TopBarPanel
    //Pause Panel
    public GameObject ResultPanel;
    public GameObject ReadyPanel;
    public GameObject DrawingPanel;
  
    public GameObject GameStartPanel;


    void Update()
    {
        switch (gstate) {
            case gamestate.START:
                // Set up default values 
                ReadyPanel.gameObject.SetActive(true);
                StartCoroutine(IntroCountdown(3)); // animate count down
                break;
            case gamestate.WAITINGFORANSWER:
                // Enable control functionallity to player 
                // Let user select a tile, pop up answer drawing panel
                //(let user see question, check for player hand writting input 
                // analize image file via google vision update ui feedback from google vision
                // allow for backspace on input (in case hand writting was bad) 
                // check for "submit" button input before time runs out 
                break;
            case gamestate.RESULT:
                // Check Who got answer correct first 
                // Update tiles accordingly 
                // go to waiting 
                break;
            case gamestate.END:
                //decide what player won and end game 
                break;
        }
        
    }


    IEnumerator IntroCountdown(float secs)
    {
        yield return new WaitForSeconds(secs);
        ReadyPanel.gameObject.GetComponentInChildren<Text>().text = "Go!";
        yield return new WaitForSeconds(.5f);
        ReadyPanel.gameObject.SetActive(false);
        gstate = gamestate.WAITINGFORANSWER;

    }

}
