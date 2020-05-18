using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Written by Mason Eastman
public class MainMenuController : MonoBehaviour
{

    private SpriteRenderer startButton;
    private SpriteRenderer controlsButton;
    private SpriteRenderer quitButton;

    public Sprite startMain;
    public Sprite controlMain;
    public Sprite quitMain;

    public Sprite startAlt;
    public Sprite controlAlt;
    public Sprite quitAlt;

    private int selectedIndex;
    private bool onControls;

    public Camera myCamera;

    // Start is called before the first frame update
    void Start()
    {
        startButton = GameObject.Find("StartButton").GetComponent<SpriteRenderer>();
        controlsButton = GameObject.Find("ControlsButton").GetComponent<SpriteRenderer>();
        quitButton = GameObject.Find("QuitButton").GetComponent<SpriteRenderer>();
        selectedIndex = 0;
        onControls = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Determines which button is "selected" based on the directional input
        //accounts for wrapping

        //moving down the menu options
        if((Input.GetKeyDown(KeyCode.Joystick1Button5) || Input.GetKeyDown(KeyCode.Joystick2Button5)) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedIndex++;
            if(selectedIndex == 3)
            {
                selectedIndex = 0;
            }
        }
        //moving up the menu options
        else if((Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.Joystick2Button4)) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedIndex--;
            if(selectedIndex == -1)
            {
                selectedIndex = 2;
            }
        }

        //update the sprites correctly based on which one is "selected"
        //start button selected
        if(selectedIndex == 0)
        {
            startButton.sprite = startAlt;
            controlsButton.sprite = controlMain;
            quitButton.sprite = quitMain;
        }
        //controls button selected
        else if(selectedIndex == 1)
        {
            startButton.sprite = startMain;
            controlsButton.sprite = controlAlt;
            quitButton.sprite = quitMain;
        }
        //quit button selected
        else
        {
            startButton.sprite = startMain;
            controlsButton.sprite = controlMain;
            quitButton.sprite = quitAlt;
        }
        //If player hits return or presses "A" button on selected option
        if ((Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick2Button0)) || Input.GetKeyDown(KeyCode.Return))
        {
            //on start
            if (selectedIndex == 0)
            {
                //replace with first level scene
                SceneManager.LoadScene("Level 1");
            }
            //on controls
            //it is not a separate scene, but a screen displaced from the main menu screen, outside menu camera's bounds
            else if (selectedIndex == 1 && !onControls)
            {
                myCamera.transform.position = new Vector3(myCamera.transform.position.x, myCamera.transform.position.y + 1000, myCamera.transform.position.z);
                onControls = true;
            }
            //on quit
            else
            {
                Application.Quit();
            }
        }
        //if player is on controls screen and presses escape or "B" button, return them to main menu screen
        if(((Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick2Button1)) || Input.GetKeyDown(KeyCode.Escape)) && selectedIndex == 1)
        {
            myCamera.transform.position = new Vector3(myCamera.transform.position.x, myCamera.transform.position.y - 1000, myCamera.transform.position.z);
            onControls = false;
        }
    }
}
