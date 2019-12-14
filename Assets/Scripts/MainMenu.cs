﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text highscoreText;

	// Use this for initialization
	void Start () {

        highscoreText.text = "Highscore : " + (int)(PlayerPrefs.GetFloat("HighScore"));
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToGame () {

        SceneManager.LoadScene(1);

    }

    public void ExitGame () {

        //Debug.Log("Quit");
        Application.Quit();

    }
}
