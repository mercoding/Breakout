﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     [SerializeField] private GameObject brickPrefab;
     [SerializeField] private GameObject ball;
    [SerializeField] private float inputFaktor = 10;
    [SerializeField] private Global global;

    // Start is called before the first frame update
    void Start()
    {
        GenerateBricks();
    }

    void GenerateBricks() {
        //create bricks on Playground
        for (int x = 0; x < 11; x++)
            for (int y = 0; y < 6; y++)
                Instantiate(brickPrefab, new Vector3(x * 1.2f - 6.0f, y * 0.75f - 0.25f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(global.gameOver) return;

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xNew = transform.position.x + xInput * inputFaktor * Time.deltaTime;
        if (xNew < -6) xNew = -6;
        if (xNew > 6) xNew = 6;
        transform.position = new Vector3(xNew, transform.position.y, 0);
    }
}
