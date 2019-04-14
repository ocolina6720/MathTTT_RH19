using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // To manage files in directory

public class TouchTrail : MonoBehaviour
{
    [SerializeField] TrailRenderer trailPrefab;
    public TrailRenderer currentTrail;
    public GameObject userWrittenInput;

    public bool inputRecieved = false;
    public bool screenCapRecieved;
    public string ScreenCapDirectory;

    private void Start()
    {
        ScreenCapDirectory = Application.persistentDataPath + "/" ;
    }
    void Update() { 
        // If screen is being touched or mouse is held down  && user hasn't written any answers yet
        if (!inputRecieved && ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButton(0)) )
        {
           
            Plane objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);
            Ray nRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (objPlane.Raycast(nRay, out rayDistance) )
            {
                this.transform.position = nRay.GetPoint(rayDistance);
                if (currentTrail == null)
                {
                    currentTrail = Instantiate(trailPrefab, nRay.GetPoint(rayDistance), Quaternion.identity);
                }
                else
                {
                    currentTrail.transform.position = nRay.GetPoint(rayDistance);
                }
            }
            
        } else {
            
            if (currentTrail != null) {
                currentTrail = null;
            }

        }


        if ((Input.touchCount < 0 && Input.GetTouch(0).phase == TouchPhase.Ended )|| Input.GetMouseButtonUp(0))
        {
            inputRecieved = true;
        }
    }



    void OnGUI()
    {
        // Get Screenshot
        if (inputRecieved && !screenCapRecieved)
        {
            ScreenCapture.CaptureScreenshot(ScreenCapDirectory + "UserWrittenInput.png");
            screenCapRecieved = true;
            Debug.Log("Screen cap recieved and stored in: "  + ScreenCapDirectory);
            //reference image with ScreenCapDirectory + "UserWrittenInput.png"
        }
    }
}
