using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public GameObject Tunnel;
    public GameObject Player;


   


    public void OnTriggerEnter2D(Collider2D other)
    {
        //if (Input.GetKeyDown(KeyCode.Z))
        
            if (other.gameObject.tag == "Player")
            {
                StartCoroutine(Teleport());
            }
        
    }
    
     
    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1);
        Player.transform.position = new Vector2(Tunnel.transform.position.x, Tunnel.transform.position.y);

    }

    
}
