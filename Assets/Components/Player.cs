using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject trailSpawn;
    public GameObject body;
    public Transform trailPrefab;
    private Vector3 intPosition;
    private Vector3 newPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int intX = (int) Mathf.Round(trailSpawn.transform.position.x);
        int intY = (int) Mathf.Round(trailSpawn.transform.position.y);
        int intZ = (int) Mathf.Round(trailSpawn.transform.position.z);
        newPosition = new Vector3(intX, intY, intZ);
        if (newPosition != intPosition)
        {
            Debug.Log(newPosition);
            Instantiate(trailPrefab, newPosition + new Vector3(-0.5f, 0.5f, -0.5f), Quaternion.identity);
            intPosition = newPosition;
        }
        else
        {
            intPosition = newPosition;
        }

        transform.Translate (-Time.deltaTime * 2, 0, 0);
        //body.transform.localScale += new Vector3(-Time.deltaTime * 4, 0, 0);
	}
}
