using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform LargeTank;
	public float y;
	
    void Start()
    {
        LargeTank = GameObject.FindGameObjectWithTag("LargeTank").transform;
    }

    void Update()
    {
        transform.position = new Vector3(LargeTank.position.x, LargeTank.position.y, -10);
    }
}
