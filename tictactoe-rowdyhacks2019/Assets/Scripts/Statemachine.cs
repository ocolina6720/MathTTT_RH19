using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statemachine : MonoBehaviour
{
    public gameManager gm;
    public enum gamestate {
        START,
        WAITINGFORTILE,
        WAITINGFORANSWER,
        RESULT, 
        END 
    };
    public gamestate gstate;


    public enum matchResult
    {
        PLAYER1WIN,
        PLAYER2WIN,
        DRAW
    };
    public matchResult mResult;


    public GameObject InputPanel;
    public GameObject TicTacToePanel;
    //TopBarPanel
    //Pause Panel
    public GameObject ResultPanel;
    public GameObject GameStartPanel;


    void Update()
    {
        switch (gstate) {
            case gamestate.START:
                // Set up default values 
                TicTacToePanel.gameObject.SetActive(false);
                InputPanel.gameObject.SetActive(false);
                ReadyPanel.gameObject.SetActive(true);
                StartCoroutine(IntroCountdown(3)); // animate count down
                break;
            case gamestate.WAITINGFORTILE:
                // Enable control functionallity to player 
                // Let user select a tile, pop up answer drawing panel
                InputPanel.gameObject.SetActive(true);

                // open panel
                break;
            case gamestate.WAITINGFORANSWER:
                // Enable draw functionallity to player 
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
        gstate = gamestate.WAITINGFORTILE;

    }

    public void GobacktoStart() {
        gstate = gamestate.START;
    }

}
