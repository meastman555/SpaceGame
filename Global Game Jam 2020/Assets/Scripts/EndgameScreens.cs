using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Written by Mason Eastman
public class EndgameScreens : MonoBehaviour
{
    public Camera myCamera;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("TimedScreens");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //waits on a screen, moves camera to the next, then loads the main menu 
    IEnumerator TimedScreens()
    {
        yield return new WaitForSeconds(4);
        myCamera.transform.position = new Vector3(myCamera.transform.position.x + 20, myCamera.transform.position.y, myCamera.transform.position.z);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Main Menu");
    }
}
