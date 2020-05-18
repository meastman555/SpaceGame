using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Written by Mason Eastman
public class FailController : MonoBehaviour
{

    private SpriteRenderer retryButton;
    private SpriteRenderer quitButton;

    public Sprite retryMain;
    public Sprite quitMain;

    public Sprite retryAlt;
    public Sprite quitAlt;

    private int selectedIndex;

    // Start is called before the first frame update
    void Start()
    {
        retryButton = GameObject.Find("RetryButton").GetComponent<SpriteRenderer>();
        quitButton = GameObject.Find("QuitButton").GetComponent<SpriteRenderer>();
        selectedIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Determines which button is "selected" based on the directional input
        //accounts for wrapping

        //moving to the right on menu options
        if ((Input.GetKeyDown(KeyCode.Joystick1Button5) || Input.GetKeyDown(KeyCode.Joystick2Button5)) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedIndex++;
            if (selectedIndex == 2)
            {
                selectedIndex = 0;
            }
        }
        //moving to the left on menu options
        else if ((Input.GetKeyDown(KeyCode.Joystick1Button4) || Input.GetKeyDown(KeyCode.Joystick2Button4)) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedIndex--;
            if (selectedIndex == -1)
            {
                selectedIndex = 1;
            }
        }

        //update the sprites correctly based on which one is "selected"
        //retry button is selected
        if (selectedIndex == 0)
        {
            retryButton.sprite = retryAlt;
            quitButton.sprite = quitMain;
        }
        //quit button is selected
        else
        {
            retryButton.sprite = retryMain;
            quitButton.sprite = quitAlt;
        }
        //player presses return or "A" button on selected button
        if ((Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick2Button0)) || Input.GetKeyDown(KeyCode.Return))
        {
            //player on retry button
            if (selectedIndex == 0)
            {
                //replace with first level scene
                SceneManager.LoadScene("Level 1");
            }
            //player on quit button
            else
            {
                Application.Quit();
            }
        }
    }
}
