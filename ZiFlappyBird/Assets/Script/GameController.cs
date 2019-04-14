using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool isEndGame;
    bool isStartGame;
    int point;
    public Text txtPoint;
    public GameObject pnlEnd;
    public Text txtFinalPoint;
    public Button btnRestart;
    public Button btnExit;
    public Sprite imgDefault; //hinh anh mac dinh
    public Sprite imgClick; //hinh anh thay doi khi click
    public Sprite imgHoverMouse; //hinh anh khi chuot di chuyen qua


	// Use this for initialization
	void Start ()
    {
        isEndGame = false;
        isStartGame = true;
        Time.timeScale = 0;
        point = 0;
        pnlEnd.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(isEndGame)
        {
            if(Input.GetMouseButton(0) && isStartGame)
            {
                Restart();
            }
        }
        else
        {
            if(Input.GetKey("space") || Input.GetKey("up") || Input.GetMouseButton(0))
            {
                Time.timeScale = 1;
            }
        }

        if(Input.GetKey("escape"))
        {
            QuitGame();
        }

        if(Input.GetKey("p"))
        {
            PauseGame();
        }
	}

    public void GetPoint()
    {
        point++;
        txtPoint.text = "Point: " + point.ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        StartGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void EndGame()
    {
        PauseGame();
        isEndGame = true;
        isStartGame = false;
        pnlEnd.SetActive(true);
        txtFinalPoint.text = "YOUR POINT\n" + point.ToString();
    }

    public void ImgDefaultForBtnRestart()
    {
        btnRestart.GetComponent<Image>().sprite = imgDefault;
    }

    public void ImgClickForBtnRestart()
    {
        btnRestart.GetComponent<Image>().sprite = imgClick;
    }

    public void ImgHoverMouseForBtnRestart()
    {
        btnRestart.GetComponent<Image>().sprite = imgHoverMouse;
    }

    public void DefaultSizeBtnExit()
    {
        btnExit.GetComponent<RectTransform>().sizeDelta = new Vector2(35, 35);
    }

    public void ResizeBtnExit()
    {
        btnExit.GetComponent<RectTransform>().sizeDelta = new Vector2(40, 40);
    }
}