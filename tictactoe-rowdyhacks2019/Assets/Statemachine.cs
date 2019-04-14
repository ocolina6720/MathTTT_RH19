using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Update()
    {
        switch (gstate) {
            case gamestate.START:
                // wait for player to 
                // set up default values
                // go to waiting for answer

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
}
