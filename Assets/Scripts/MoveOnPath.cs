﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPath : MonoBehaviour {

    public EditorPath pathToFollow;
    public int currentWaypointID = 0;
    public float speed;
    public float reachDist = 0f;
    public float rotationSpeed = 5f;
    public bool stall = false;
    public float distance;
    public string pathName;
    float originalSpeed;
    Vector3 lastPosition;
    Vector3 currentPosition;

    void Start() {
        //pathToFollow = GameObject.Find(pathName).GetComponent<EditorPath>();
        lastPosition = transform.position;
        originalSpeed = speed;
    }

    void Update() {
        if (currentWaypointID < pathToFollow.pathObjs.Count)
        {
            if (stall && currentWaypointID == 2)
            {
                StartCoroutine(makeSpeedZeroForXSeconds(2f));
            }
            distance = Vector3.Distance(pathToFollow.pathObjs[currentWaypointID].position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, pathToFollow.pathObjs[currentWaypointID].position, Time.deltaTime * speed);

            //Quaternion rotation = Quaternion.LookRotation(pathToFollow.pathObjs[currentWaypointID].position - transform.position);
            //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
        if (distance <= reachDist)
        {
            currentWaypointID++;
        }

    }

    IEnumerator makeSpeedZeroForXSeconds(float time){
        
        speed = 0;
        yield return new WaitForSeconds(time);
        speed = originalSpeed;
        stall = false;
    }

    }