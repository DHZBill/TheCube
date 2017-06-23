using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
	public int numCubes = 5;
	public bool grav = false;
	public GameObject obstaclePrefab;
	// Use this for initialization
	void Start () {
		Debug.Log ("hello");
		for (int i = 0; i < numCubes; i++)
		{
			Vector3 position = new Vector3(Random.Range(-9, 10), Random.Range(-9, 10), Random.Range(-9, 10));
			Instantiate (obstaclePrefab, position, Quaternion.identity);
		}

		for (int i = -1; i <= 1; i++)
			for (int j = -1; j <= 1; j++)
				for (int k = -1; k <= 1; k++)
					if (i != 0 || j != 0 || k == -1)
						putCube (i, j, k);
	}

	// Update is called once per frame
	void Update () {

	}

	private void putCube(int x, int y, int z)	{
		Instantiate (obstaclePrefab, new Vector3 (x, y, z), Quaternion.identity);
	}
}
