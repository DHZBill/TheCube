using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour {
    public ScenePlay scene;
    public Text winText;
    private float bestTime;
    private string bestTimeString;
	// Use this for initialization
	void Start () {
        if (bestTime > 0) {
            winText.text = "Best: " + bestTimeString;
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Head")
        {
            if (scene.timer < bestTime || bestTime < 1f) {
                float time = scene.timer;
                int ms = (int)(((float)(time - (int)time)) * 1000);
                int m = (int)time / 60;
                int s = (int)(time - m * 60);

                string timeString = m.ToString("D2") + ":" + s.ToString("D2") + ":" + ms.ToString("D3");
                bestTimeString = timeString;
                bestTime = time;
            }

            SceneManager.LoadScene("Play");
        }
    }
}
