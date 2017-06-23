using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

    public float speed;
    public float moveSpeed = 1f;
    public float sprintSpeed = 2f;
    public float rotateTime = 1f;
    float positionError = 0.05f;
    Vector3 position;
    Vector3 rotation;
    bool turnCommand = false;
    bool safeToTurn = false;
    Vector3 rotate;
	// Use this for initialization
	void Start () {
        speed = moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, 0, Time.deltaTime * speed));
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            turnCommand = true;
            rotate = new Vector3(0, 90f, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            turnCommand = true;
            rotate = new Vector3(0, -90f, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            turnCommand = true;
            rotate = new Vector3(-90f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            turnCommand = true;
            rotate = new Vector3(90f, 0, 0);
        }
        if (turnCommand)
        {
            checkPosition();
            if (safeToTurn)
            {
                StartCoroutine(RotateMe(rotate, rotateTime));
                turnCommand = false;
            }
        }
        safeToTurn = false;
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        GameObject temp = new GameObject("temp");
        temp.transform.position = transform.position;
        temp.transform.rotation = transform.rotation;
        temp.transform.Rotate(rotate);
        Freeze();
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime){
            transform.rotation = (Quaternion.Lerp(transform.rotation, temp.transform.rotation, t));
            yield return null;
        }
        Destroy(temp);
        EulerAngleCorrection();
        Resume();
    }

    void Freeze()
    {
        speed = 0;
    }
    
    void Resume()
    {
        speed = moveSpeed;
    }
    void EulerAngleCorrection()
    {
        int factor = 90;
        rotation = transform.eulerAngles;
        transform.eulerAngles = new Vector3((float)Math.Round((rotation.x / (double)factor), MidpointRounding.AwayFromZero) * factor,
                                            (float)Math.Round((rotation.y / (double)factor), MidpointRounding.AwayFromZero) * factor,
                                            (float)Math.Round((rotation.z / (double)factor), MidpointRounding.AwayFromZero) * factor
                                            );
    }
    void checkPosition()
    {
        Vector3 pos = transform.position;
        Vector3 finalPos = new Vector3((float)Math.Ceiling(pos.x), (float)Math.Ceiling(pos.y), (float)Math.Ceiling(pos.z));
        if (Vector3.Distance(pos, finalPos) < positionError)
        {
            transform.position = finalPos;
            safeToTurn = true;
        }
    }
}
