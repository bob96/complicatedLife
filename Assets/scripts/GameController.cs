using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int level;
    private Core core;
    public GameObject corePrefab;
    public static bool instantiated = false;
    private bool gameOver = false;

    private void Awake()
    {
        core = corePrefab.GetComponent<Core>();
    }

    private void Start()
    {
        level = 1;
        Core.coreSize = 10;
        if (!instantiated)
        {
            Instantiate(corePrefab, transform.position, Quaternion.identity);
        }
        
    }



    void UpgradeCore()
    {
        
        Core.coreSize = level * 2 + 10;
        Debug.Log("black :" + Core.badNodeCount + "Normal:" + Core.coreSize);
        Core.nodeCount = Core.coreSize; ;
        Core.goodNodeCount = 0;
        GameObject coreGo = Instantiate(corePrefab, transform.position, Quaternion.identity);
        core = coreGo.GetComponent<Core>();
        core.CoreGenerator();
        

    }
    private void FixedUpdate()
    {
        Debug.Log("Good : " + Core.goodNodeCount +"black :" + Core.badNodeCount + "Normal:" + Core.coreSize);
        if(Core.badNodeCount == Core.coreSize)
        {
            gameOver = true;
        }
        else if(Core.goodNodeCount == Core.coreSize)
        {
            instantiated = true;
            level++;
            if (GameObject.FindGameObjectWithTag("Core") == null) return;
            Destroy(GameObject.FindGameObjectWithTag("Core"));
            UpgradeCore();
        }
    }


}
