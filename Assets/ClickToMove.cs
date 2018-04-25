﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{

    private Animator mAnimator;

    private NavMeshAgent mNavMeshAgent;

    private bool mRunning = false;
    private bool mSwinging = false;
    // Use this for initialization
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                mNavMeshAgent.destination = hit.point;
            }
        }

        if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
        {
            mRunning = false;
        }
        else
        {
            mRunning = true;
        }

        mAnimator.SetBool("running", mRunning);

        if (Input.GetKeyDown("s"))
        {
            //mRunning = false;
            mAnimator.SetBool("swinging", mSwinging);
        }
    }
}