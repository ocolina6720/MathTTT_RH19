using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statemachine : MonoBehaviour
{
    string[] opr = new string[] { "-", "+", "*", "/" };
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
    public Text inputPanelTitle;
    public GameObject TicTacToePanel;
    //TopBarPanel
    //Pause Panel
    public GameObject ResultPanel;
    public GameObject GameStartPanel;
    public QuestionInfo qi;

    public enum answerState {
        ansNull,
        ansCorrect,
        ansWrong
    }
    public answerState ansState;

    void Update()
    {
        switch (gstate) {
            case gamestate.START:
                // Set up default values 
                TicTacToePanel.gameObject.SetActive(false);
                InputPanel.gameObject.SetActive(false);
                GameStartPanel.gameObject.SetActive(true);
                StartCoroutine(IntroCountdown(3)); // animate count down
                break;
            case gamestate.WAITINGFORTILE:
                // Enable control functionallity to player 
                // Let user select a tile, pop up answer drawing panel
                TicTacToePanel.gameObject.SetActive(true);

                // open panel
                break;
            case gamestate.WAITINGFORANSWER:
                TicTacToePanel.gameObject.SetActive(false);
                InputPanel.gameObject.SetActive(true);
                inputPanelTitle.text = qi.num1 + opr[qi.opnum] + qi.num2;
                
                // Enable draw functionallity to player 
                //(let user see question, check for player hand writting input 
                // analize image file via google vision update ui feedback from google vision
                // allow for backspace on input (in case hand writting was bad) 
                // check for "submit" button input before time runs out 
                // if time runs out automatically wrong
                // otherwise if input recieved automatically right for demo 
                break;
            case gamestate.RESULT:
                // Check Who got answer correct first 
                // Update tiles accordingly 
                // go to waiting 

                switch (ansState)
                {
                    case answerState.ansCorrect:
                        // update panel  CORRECT checkmark object

                        break;
                    case answerState.ansWrong:
                        // update panel  WRONG checkmark object 
                        break;

                    case answerState.ansNull:
                        //error
                        break;

                        // check if won 
                        //if so go ot end.
                }
                break;
            case gamestate.END:
                //decide what player won and end game 
                break;
        }

    }


    IEnumerator IntroCountdown(float secs)
    {
        yield return new WaitForSeconds(secs);
        GameStartPanel.gameObject.GetComponentInChildren<Text>().text = "Go!";
        yield return new WaitForSeconds(.5f);
        GameStartPanel.gameObject.SetActive(false);
        gstate = gamestate.WAITINGFORTILE;

    }

    public void GobacktoStart() {
        gstate = gamestate.START;
    }

    public void getQuestionInfo(QuestionInfo in_qi) {
        in_qi = qi;
    }

    public void tileSelected(){
         gstate = gamestate.WAITINGFORANSWER;
    }
}
