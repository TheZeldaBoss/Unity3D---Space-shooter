using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    public GameObject shot;
    public GameObject shotSpawn;
    public float fireRate;
    private float nextFire;

    public GameObject player;
	void Update () {
        

            if (Input.GetButton("Fire1") && Time.time > nextFire)
        {

            nextFire = Time.time + fireRate;
            //GameObject clone = 
            Instantiate(shot, shotSpawn.GetComponent<Transform>().position, shotSpawn.GetComponent<Transform>().rotation);// as GameObject;
            GetComponent<AudioSource>().Play();
        }
    }
    public float speed;
    public float tilt;
    public Boundary boundary;
    void FixedUpdate ()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical= Input.GetAxis("Vertical");

        Vector3 Movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = Movement* speed;

        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, GetComponent<Rigidbody>().velocity.x * -tilt);
    }
}
