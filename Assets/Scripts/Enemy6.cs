﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6 : MonoBehaviour
{
    Vector2 pointA = new Vector2(34, 3);
    Vector2 pointB = new Vector2(36, 3);

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
    }
}
