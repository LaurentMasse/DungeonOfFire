using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour {
    public GameObject bullet;
    public GameObject targetPrefab;
    GameObject target;
	// Use this for initialization
	void Start () {
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10.0f;
        Debug.Log("Bullet: \n(" + bullet.transform.position.x + ", " + bullet.transform.position.y + ", " + bullet.transform.position.z + ")");

        target = Instantiate(targetPrefab, bullet.transform.position + transform.forward * 120f, bullet.transform.rotation);
        target.transform.localScale = new Vector3(5f, 5f, 5f);
        
        Rigidbody RigidTarget = target.GetComponent<Rigidbody>();
        RigidTarget.constraints = RigidbodyConstraints.FreezeAll;
        Debug.Log("Target: \n(" + target.transform.position.x + ", " + target.transform.position.y + ", " + target.transform.position.z + ")");
    }
    IEnumerator ExpandDelay(GameObject bullet, float expansionRadius)
    {
        yield return new WaitForSeconds(1.0f);
        bullet.transform.localScale = new Vector3(expansionRadius, expansionRadius, expansionRadius);
    }
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(ExpandDelay(bullet, 20.0f));
        Rigidbody RigidBullet = bullet.GetComponent<Rigidbody>();
        RigidBullet.constraints = RigidbodyConstraints.FreezeAll;
        Destroy(target, 2.0f);
        Destroy(bullet, 2.0f);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
