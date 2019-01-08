using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCenter : MonoBehaviour {

    public float speed;
    private Vector3 moveTo = Vector3.zero;
    private GameObject randomNode ;

    private void Awake()
    {
        RandomNode(gameObject.tag);
    }

    private void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        moveTo = randomNode.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, moveTo, step);
        if (transform.position == Vector3.zero)
        {
            Destroy(gameObject);
        }

    }

    void RandomNode(string tag)
    {
        
        List<GameObject> nodesForVirus = new List<GameObject>();
        List<GameObject> nodes = new List<GameObject>();
        nodesForVirus.AddRange(GameObject.FindGameObjectsWithTag("Node"));
        nodesForVirus.AddRange(GameObject.FindGameObjectsWithTag("GoodNode"));

        nodes.AddRange(GameObject.FindGameObjectsWithTag("Node"));
        nodes.AddRange(GameObject.FindGameObjectsWithTag("CorruptedNode"));


        if(tag == "Virus")
        {
            if (nodesForVirus.Count == 0) { moveTo = Vector3.zero; }
            int rand = Random.Range(0, nodesForVirus.Count);
            randomNode= nodesForVirus[rand].gameObject;
        }
        else if(tag == "Heart")
        {

            Debug.Log(gameObject.tag);
            if(nodes.Count == 0) { moveTo = Vector3.zero; }
            int rand = Random.Range(0, nodes.Count);
            randomNode = nodes[rand].gameObject;
        }

    }
}
