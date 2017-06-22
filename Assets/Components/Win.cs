using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour {
    public ScenePlay scene;
    public Text winText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Head")
        {
            float time = scene.timer;
            int ms = (int)(((float)(time - (int)time)) * 1000);
            int m = (int)time / 60;
            int s = (int)(time - m * 60);

            string timeString = m.ToString("D2") + ":" + s.ToString("D2") + ":" + ms.ToString("D3");
            winText.text = "Best: " + timeString;
            SceneManager.LoadScene("Play");
        }
    }
}
