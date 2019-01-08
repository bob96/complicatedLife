using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour {

    //public
    public GameObject node;
    //public GameObject connexion;
    public static int coreSize;
    public static Vector3 coreBox;
    public static int nodeCount;
    public static int goodNodeCount;
    public static int badNodeCount;
    public float SpeedOfRotaiton;
    

    //private
    public static List<GameObject> coreNodes = new List<GameObject>();
    private Rigidbody rb;
    //private List<GameObject> coreConnexion = new List<GameObject>();

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Start()
    {
        coreBox = new Vector3(1.5f, 1.5f, 0);
        if (!GameController.instantiated)
        {
            CoreGenerator();
        }
    }

    public void CoreGenerator()
    {
        Vector3 previousPos = new Vector3(0, 0, 0);
        for(int i = 0; i< coreSize; i++)
        {

            Vector3 randPosInBox = GenerateRandomPos();
            while(Vector3.Distance(randPosInBox, previousPos)< 2f)
            {
                randPosInBox = GenerateRandomPos();
            }
            float randScale = Random.Range(0.2f, 0.5f);
            GameObject nodeClone =Instantiate(node, randPosInBox, Quaternion.identity);
            nodeClone.transform.localScale = new Vector3(randScale, randScale, randScale);
            nodeClone.transform.parent = gameObject.transform;
            coreNodes.Add(nodeClone);
            previousPos = randPosInBox;
        }
       
    }

    Vector3 GenerateRandomPos()
    {
        float randX = Random.Range(-coreBox.x, coreBox.x);
        float randY = Random.Range(-coreBox.y, coreBox.y);
        
        Vector3 randPos = new Vector3(randX, randY, 0);
        return randPos;
    }

    private void FixedUpdate()
    {
        rb.transform.Rotate(Vector3.forward * SpeedOfRotaiton * Time.deltaTime);
    }



}
