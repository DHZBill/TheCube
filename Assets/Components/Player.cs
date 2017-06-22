using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject body;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate (-Time.deltaTime * 2, 0, 0);
        //body.transform.localScale += new Vector3(-Time.deltaTime * 4, 0, 0);
	}
}
