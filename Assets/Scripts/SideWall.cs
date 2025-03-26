using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        if (hitInfo.name == "Ball")
        {
            // Debug.Log(hitInfo.name + " hit " + gameObject.name);
            string wallName = gameObject.name;
						
            GameManager.instance.Score(wallName);
						
            hitInfo.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
            // Debug.Log(" sent ");
        }
    }
}