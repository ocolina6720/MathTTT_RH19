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

    // Start is called before the first frame update
    void Start(){
        currentTime = startTime;
        counterText.text = ":" + startTime.ToString("00");
    }
    // Update is called once per frame
    void Update(){
        currentTime -= 1 * Time.deltaTime;
        counterText.text = currentTime.ToString("00");

        if(currentTime <= 1)
        {
            currentTime = 0;
            counterText.color = Color.red;
        }
    }
}
