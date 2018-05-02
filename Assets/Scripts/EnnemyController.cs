using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyController : MonoBehaviour {
    public GameObject shot;
    public GameObject shotSpawn;
    private float nextFire;
    public float fireRate;

    IEnumerator EnnemyShoots()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    //GameObject clone = 
                    Instantiate(shot, shotSpawn.GetComponent<Transform>().position, shotSpawn.GetComponent<Transform>().rotation);// as GameObject;
                    GetComponent<AudioSource>().Play();

                }
            }
            yield return new WaitForSeconds(1);
        }
    }
    void Start() {
        StartCoroutine(EnnemyShoots());

    }
}
