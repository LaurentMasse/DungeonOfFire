using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    public Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = new Vector3(0f, 10f, -10f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.TransformPoint(offset);
        transform.LookAt(player);
	}
}
