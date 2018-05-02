using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    //game over
    public int nbLives;
    public GameObject player;
    void Update()
    {
        GameObject tmpPlayer;
        //player's death
        if (!(GameObject.Find("Player") || GameObject.Find("Player(Clone)")))
        {
            nbLives--;
            if (nbLives > 0)
            {
                Vector3 spawnPosition = new Vector3(0, 0, -6);
                Quaternion spawnRotation = Quaternion.identity;
                tmpPlayer = Instantiate(player, spawnPosition, spawnRotation);
            }
            else
            {
                Debug.Log("Player is dead");
                //change scene to game over screen
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while(true)
        { 
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-(spawnValues.x - 1), spawnValues.x - 1), 0, 16);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

   
}
