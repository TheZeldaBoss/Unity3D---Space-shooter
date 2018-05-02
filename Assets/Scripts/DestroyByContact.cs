using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Boundary")
            {
                return;
            }
            //Debug.Log(other.name);
            Instantiate(explosion, GetComponent<Transform>().position, GetComponent<Transform>().rotation);// as GameObject;
            if (other.tag == "Player")
            {
                Instantiate(playerExplosion, other.GetComponent<Transform>().position, other.GetComponent<Transform>().rotation);// as GameObject;
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
}
