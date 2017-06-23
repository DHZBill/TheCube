using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
	public int numCubes = 5;
	public bool grav = false;
	// Use this for initialization
	void Start () {
		Debug.Log ("hello");
		for (int i = 0; i < numCubes; i++)
		{
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.AddComponent<Rigidbody>();
			cube.GetComponent<Rigidbody>().useGravity = grav;
			Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
			cube.transform.position = position;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
