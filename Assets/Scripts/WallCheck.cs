﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    public PlayerController player;
    //public GameObject currentCollidingObject;
    // Use this for initialization
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag != "Checkpoint" && coll.gameObject.tag!="Ladder" && coll.gameObject.tag != "Trigger")
        {
            player.touchingWall = true;
        }
    }


    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag != "Checkpoint" && coll.gameObject.tag != "Ladder" && coll.gameObject.tag != "Trigger")
        {
            player.touchingWall = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag != "Checkpoint" && coll.gameObject.tag != "Ladder" && coll.gameObject.tag != "Trigger")
        {
            player.touchingWall = false;
        }
    }
}
