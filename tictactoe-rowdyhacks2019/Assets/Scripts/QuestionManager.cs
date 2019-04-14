using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    string[]  opr = new string[] { "-", "+", "*", "/" };
   public 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PopulateQuestion(Text t , QuestionInfo qi) { // add answer componenet
        int num1 = Random.Range(0, 10);
        int num2 = Random.Range(0, 10);
        int opnum = Random.Range(0, opr.Length);
        int ans = 0;
        t.text =  num1 + opr[opnum] + num2;

        switch (opnum) {
            case 0: ans = num1 - num2; break;
            case 1: ans = num1 + num2; break;
            case 2: ans = num1 * num2; break;
            case 3: ans = num1 / num2; break;
        }
        qi.ans = ans;
    }
}
