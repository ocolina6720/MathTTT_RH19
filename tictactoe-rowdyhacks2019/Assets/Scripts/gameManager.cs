using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour{


    public Text counterText;

    //Change the startTime if too long or too short
    public float startTime = 10;
    public float currentTime;
    // look into player prefs to store highscores 
    public Text question; // equation 
    public Text TallyScore; // look into player prefs to store highscores 
    public Statemachine sm;
    public bool timeStarted = false;


    // Start is called before the first frame update
    void Start(){
       
    }
    // Update is called once per frame
    void Update(){

        if (sm.gstate == Statemachine.gamestate.WAITINGFORANSWER)
        {
            if (!timeStarted)
            {
                currentTime = startTime;
                counterText.text = ":" + startTime.ToString("00");
                timeStarted = true;
            }
            else
            {
                currentTime -= 1 * Time.deltaTime;
                counterText.text = currentTime.ToString("00");

                if (currentTime <= 1)
                {
                    currentTime = 0;
                    counterText.color = Color.red;
                    sm.ansState = Statemachine.answerState.ansWrong;
                }
            }
        }
    }
}
