using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tictactoeMaster : MonoBehaviour
{
    public int A1, A2, A3, B1, B2, B3, C1, C2, C3;
    public bool winnerFound = false;
    public int winnerNum = 0;
    public string buttonSelected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //1 == player 1, 0 == null/ empty, 2 == player 2
    public void checkIfWon()
    {
        if(A1 == 1 && A2 == 1 && A3 == 1)
        {
            winnerFound = true;
            winnerNum = 1;
        }else if(B1 == 1 && B2 == 1 && B3 == 1)
        {
            winnerFound = true;
            winnerNum = 1;
        }else if (C1 == 1 && C2 == 1 && C3 == 1)
        {
            winnerFound = true;
            winnerNum = 1;
        } else if (A1 == 1 && B1 == 1 && C1 == 1)
        {
            winnerFound = true;
            winnerNum = 1;
        }else if (A2 == 1 && B2 == 1 && C2 == 1)
        {
            winnerFound = true;
            winnerNum = 1;
        }else if (A3 == 1 && B3 == 1 && C3 == 1)
        {
            winnerFound = true;
            winnerNum = 1;
        }
        else if (A1 == 1 && B2 == 1 && C3 == 1)
        {
            winnerFound = true;
            winnerNum = 1;
        }
        else if (A3 == 1 && B2 == 1 && C1 == 1)
        {
            winnerFound = true;
            winnerNum = 1;
        }

        //Now for the player 2
        if (A1 == 2 && A2 == 2 && A3 == 2)
        {
            winnerFound = true;
            winnerNum = 2;
        }
        else if (B1 == 2 && B2 == 2 && B3 == 2)
        {
            winnerFound = true;
            winnerNum = 2;
        }
        else if (C1 == 2 && C2 == 2 && C3 == 2)
        {
            winnerFound = true;
            winnerNum = 2;
        }
        else if (A1 == 2 && B1 == 2 && C1 == 2)
        {
            winnerFound = true;
            winnerNum = 2;
        }
        else if (A2 == 2 && B2 == 2 && C2 == 2)
        {
            winnerFound = true;
            winnerNum = 2;
        }
        else if (A3 == 2 && B3 == 2 && C3 == 2)
        {
            winnerFound = true;
            winnerNum = 2;
        }
        else if (A1 == 2 && B2 == 2 && C3 == 2)
        {
            winnerFound = true;
            winnerNum = 2;
        }
        else if (A3 == 2 && B2 == 2 && C1 == 2)
        {
            winnerFound = true;
            winnerNum = 2;
        }
    }
}
