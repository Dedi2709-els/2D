using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    PlayerCtrl player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerCtrl>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ground") && player.jumping)
        {
            player.jumping = false;
        }
    }

  
}
