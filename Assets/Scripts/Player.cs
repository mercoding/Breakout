using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     [SerializeField] private GameObject brickPrefab;
     [SerializeField] private GameObject ball;
    [SerializeField] private float inputFaktor = 10;
    [SerializeField] private Global global;
    [SerializeField] private Transform bricks;

    // Start is called before the first frame update
    void Start()
    {
        GenerateBricks();
    }

    void GenerateBricks() {    
        //create bricks on Playground
        for (int x = 0; x < 11; x++)
            for (int y = 0; y < 6; y++) {
                GameObject brick = Instantiate(brickPrefab, new Vector3(x * 1.2f - 6.0f, y * 0.75f - 0.25f, 0), Quaternion.identity);
                brick.transform.parent = bricks;
            }
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        
        if (global.gameOver && yInput > 0) {
            global.OnStart();
        }
        else if(global.gameOver) {
            MovePlayer(xInput);
            MoveBall(xInput);
        }
        else {
            MovePlayer(xInput);
        }
    }


    void MovePlayer(float xInput) {
        float xNew = transform.position.x + xInput * inputFaktor * Time.deltaTime;
        if (xNew < -6) xNew = -6;
        if (xNew > 6) xNew = 6;
        transform.position = new Vector3(xNew, transform.position.y, 0);
    }

    void MoveBall(float xInput) {
        float xNew = ball.transform.position.x + xInput * inputFaktor * Time.deltaTime;
        if (xNew < -6) xNew = -6;
        if (xNew > 6) xNew = 6;
        ball.transform.position = new Vector3(xNew, ball.transform.position.y, 0);
    }
}
