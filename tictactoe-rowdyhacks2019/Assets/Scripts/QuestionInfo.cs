using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionInfo : MonoBehaviour
{
    public string _name;
    public int num1;
    public int opnum;
    string[] opr = new string[] { "-", "+", "*", "/" };
    public int num2;

    public int ans;

    public Text equa;

    public void Start()
    {
        genQuestion();
    }

    public void genQuestion() {
        num1 = Random.Range(0, 10);
        num2 = Random.Range(0, 10);
        opnum = Random.Range(0, opr.Length);
        int ans = 0;

        switch (opnum)
        {
            case 0: ans = num1 - num2; break;
            case 1: ans = num1 + num2; break;
            case 2: ans = num1 * num2; break;
            case 3:
                if (num2 == 0) num2 += 1;
                ans = num1 / num2;
                break;
        }

        equa.text = num1 + opr[opnum] + num2;
    }

}
