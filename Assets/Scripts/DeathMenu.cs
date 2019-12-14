﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public Text scoreText;
    public Image backgroundImage;

    private bool isShown = false;

    private float transition =0.0f;

	// Use this for initialization
	void Start () {
        
        gameObject.SetActive(false);
	
    }

    void Update () {

        if (!isShown)
            return;

        transition += Time.deltaTime;
        backgroundImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);

    }

    public void ToggleEndMenu (float score) {

        gameObject.SetActive(true);
        //Debug.Log(score);
        scoreText.text = ((int)score).ToString();
        isShown = true;

    }

    public void Restart () {

        SceneManager.LoadScene(1);

    }

    public void ToMenu () {

        SceneManager.LoadScene(0);

    }
}
