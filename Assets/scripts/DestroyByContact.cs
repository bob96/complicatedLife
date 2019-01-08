using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Node" && gameObject.tag == "Virus")
        {
            //change the node color to black
            other.gameObject.tag = "CorruptedNode";
            other.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
            Core.badNodeCount++;
            Core.nodeCount--;
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Node" && gameObject.tag == "Heart")
        {
            //change the node color to pink
            other.gameObject.tag = "GoodNode";
            other.gameObject.GetComponent<Renderer>().material.color = new Color(0.255f, 0.089f, 0.151f);
            Core.goodNodeCount++;
            Core.nodeCount--;
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "GoodNode" && gameObject.tag == "Virus")
        {
            other.gameObject.tag = "Node";
            other.gameObject.GetComponent<Renderer>().material.color = new Color(0.400f, 0.400f, 0.255f);
            Core.nodeCount++;
            Core.goodNodeCount--;
            Core.badNodeCount--;
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "CorruptedNode" && gameObject.tag == "Heart")
        {
            other.gameObject.tag = "GoodNode";
            other.gameObject.GetComponent<Renderer>().material.color = new Color(0.255f, 0.089f, 0.151f);
            Core.goodNodeCount++;
            Core.badNodeCount--;
            Destroy(gameObject);
        }
        
        if (other.gameObject.tag == "Player" && gameObject.tag == "Virus")
        {
            Destroy(gameObject);
        }
    }
}
