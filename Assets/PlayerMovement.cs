using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;

    //[space]
    public GameObject bulletPrefab;
    public GameObject targetPrefab;
    public Transform bulletSpawn;
    public bool bulletFired = false;
    public int shot;
    public float delayInSeconds;
    public GameObject[] targets;
    
	// Use this for initialization
	void Start () {
	}
	
	// FixedUpdate is called instead of Update to interact with physics
	void FixedUpdate () {
        if (shot > 0)
        {
            shot = 0;
        }
        //Add a forward force

        if (Input.GetKey("d"))
        {
            rb.transform.position += transform.right;
        }
        if (Input.GetKey("a"))
        {
            rb.transform.position -= transform.right;
        }
        if (Input.GetKey("w"))
        {
            rb.transform.position += transform.forward;
        }
        if (Input.GetKey("s"))
        {
            rb.transform.position -= transform.forward;
        }
        if (Input.GetKey("q"))
        {
            transform.Rotate(Vector3.up);
        }
        if (Input.GetKey("e"))
        {
            transform.Rotate(Vector3.down);
        }
        //Main mouse button
        if (Input.GetMouseButton(0))
        {

        }
        //Second mouse button
        if (Input.GetMouseButton(1))
        {

        }
        //Middle mouse button
        if (Input.GetMouseButton(2))
        {

        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (shot == 0 && bulletFired == true)
            {
                shot = 1;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.DrawLine(ray.origin, hit.point);
                    Debug.Log("Origin ("+ray.origin.x + ","+ray.origin.y + " ,"+ray.origin.z + " ), Hit (" +hit.point.x + "," + hit.point.y + " ," + hit.point.z + " )");
                }
                Fire(100f, 20f);
                bulletFired = false;
                StartCoroutine(ShootDelay());
            }
        }
    }
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        bulletFired = true;
    }
    void Fire(float distance, float expansionRadius)
    {
        bulletFired = true;
        //Create the Bullet from the Bullet Prefab
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bulletFired = false;
    }
}
