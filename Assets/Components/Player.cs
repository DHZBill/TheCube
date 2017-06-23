using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject trailSpawn;
    public GameObject body;
    public Transform trail;
    public Transform trailPrefab;
    public float speed = 2;
    private Vector3 intPosition;
    private Vector3 newPosition;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int intX = (int)Mathf.Round(trailSpawn.transform.position.x);
        int intY = (int)Mathf.Round(trailSpawn.transform.position.y);
        int intZ = (int)Mathf.Round(trailSpawn.transform.position.z);
        newPosition = new Vector3(intX, intY, intZ);
        if (newPosition != intPosition)
        {
            Vector3 trailPosition = new Vector3(Mathf.Round(trailSpawn.transform.position.x - 0.5f) - 0.5f, Mathf.Round(trailSpawn.transform.position.y + 0.5f) - 0.5f, Mathf.Round(trailSpawn.transform.position.z - 0.5f) + 0.5f);
            Instantiate(trailPrefab, trailPosition, Quaternion.identity, trail);
            intPosition = newPosition;
        }
        else
        {
            intPosition = newPosition;
        }

        transform.Translate(-Time.deltaTime * speed, 0, 0);
        //body.transform.localScale += new Vector3(-Time.deltaTime * 4, 0, 0);
    }

    void onTriggerEnter(Collider other)
    {
        Debug.Log("hey");
    }
}