using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float timeBtwSpawn;
    public float maxTimeBtwSpawn;
    public GameObject[] toSpawn;
    public Vector2 xAreaToSpawn;
    public Vector2 yAreaTospawn;
    private Vector3[] randvec = new Vector3[4];


    private void Start()
    {
        SetRandVec();
        
    }


    private void Update()
    {
        Spawn();
    }
    public void Spawn()
    {
        SetRandVec();
        int rand = Random.Range(0, 4);
        int randOmSpawn = Random.Range(0, toSpawn.Length);
        if (timeBtwSpawn <= 0)
        {
            //instantiate the gameobject
            Instantiate(toSpawn[randOmSpawn],randvec[rand], Quaternion.identity);
            // reset timer
            timeBtwSpawn = maxTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

    void SetRandVec()
    {
        randvec[0] = new Vector3(
                Random.Range(-xAreaToSpawn.y, -xAreaToSpawn.x),
                Random.Range(-yAreaTospawn.y, yAreaTospawn.y),
                0f);
        randvec[1] = new Vector3(
                Random.Range(xAreaToSpawn.x, xAreaToSpawn.y),
                Random.Range(-yAreaTospawn.y, yAreaTospawn.y),
                0f);
        randvec[2] = new Vector3(
                Random.Range(-xAreaToSpawn.y, xAreaToSpawn.y),
                Random.Range(-yAreaTospawn.y, -yAreaTospawn.x),
                0f);
        randvec[3] = new Vector3(
                Random.Range(-xAreaToSpawn.y, xAreaToSpawn.y),
                Random.Range(yAreaTospawn.x, yAreaTospawn.y),
                0f);
    }
}
