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
    public Text inputPanelProblem;
    public GameObject TicTacToePanel;
    //TopBarPanel
    //Pause Panel
    public GameObject ResultPanel;
    public GameObject GameStartPanel;
    public QuestionInfo qi;
    public tictactoeMaster tttm;
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

                // check if won  if so go to end 

                tttm.checkIfWon();
                if (tttm.winnerFound) {
                    gstate = gamestate.END;
                }
                // Set up default values 
                TicTacToePanel.transform.position = new Vector3(TicTacToePanel.transform.position.x, TicTacToePanel.transform.position.y, 0f);

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
                TicTacToePanel.transform.position = new Vector3(TicTacToePanel.transform.position.x, TicTacToePanel.transform.position.y, 9999f);

                //TicTacToePanel.gameObject.SetActive(false);
                InputPanel.gameObject.SetActive(true);
                if (qi != null)
                    inputPanelProblem.text = qi.num1 + opr[qi.opnum] + qi.num2;
                else
                    inputPanelProblem.text = "";
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
                        inputPanelProblem.text = "CORRECT!";
                        if (qi._name == "A1")
                        {
                            tttm.A1 = 1;
                        }
                        else if (qi._name == "A2")
                        {
                            tttm.A2 = 1;
                        }
                        else if (qi._name == "A3")
                        {
                            tttm.A3 = 1;
                        }
                        else if (qi._name == "B1")
                        {
                            tttm.B1 = 1;
                        }
                        else if (qi._name == "B2")
                        {
                            tttm.B2 = 1;
                        }
                        else if (qi._name == "B3")
                        {
                            tttm.B3 = 1;
                        }
                        else if (qi._name == "C1")
                        {
                            tttm.C1 = 1;
                        }
                        else if (qi._name == "C2")
                        {
                            tttm.C2 = 1;
                        }
                        else if (qi._name == "C3")
                        {
                            tttm.C3 = 1;
                        }
                  break;
                    case answerState.ansWrong:
                        // update panel  WRONG checkmark object 
                        inputPanelProblem.text = "WRONG!";
                        tttm.buttonSelected = qi._name;

                        if (qi._name == "A1")
                        {
                            tttm.A1 = 0;
                        }
                        else if (qi._name == "A2")
                        {
                            tttm.A2 = 0;
                        }
                        else if (qi._name == "A3")
                        {
                            tttm.A3 = 0;
                        }
                        else if (qi._name == "B1")
                        {
                            tttm.B1 = 0;
                        }
                        else if (qi._name == "B2")
                        {
                            tttm.B2 = 0;
                        }
                        else if (qi._name == "B3")
                        {
                            tttm.B3 = 0;
                        }
                        else if (qi._name == "C1")
                        {
                            tttm.C1 = 0;
                        }
                        else if (qi._name == "C2")
                        {
                            tttm.C2 = 0;
                        }
                        else if (qi._name == "C3")
                        {
                            tttm.C3 = 0;
                        }

                        break;

                    case answerState.ansNull:
                        //error
                        break;

                
                }
                StartCoroutine(roundEndCountdown(1.5f)); // animate count down
                break;
            case gamestate.END:
                if (tttm.winnerNum == 1) {
                    ResultPanel.SetActive(true);
                }

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
         qi = in_qi ;
        if (qi != null)
        {
            Debug.Log("Got qi:" + qi.name);
            tttm.buttonSelected = qi._name;
        }
    }

    public void tileSelected(){
         gstate = gamestate.WAITINGFORANSWER;
    }


    IEnumerator roundEndCountdown(float secs)
    {
        yield return new WaitForSeconds(secs);
        gstate = gamestate.START;
    }


    IEnumerator GameEndCountdown(float secs)
    {
        yield return new WaitForSeconds(secs);
        Application.LoadLevel("Menu");
    }
}
