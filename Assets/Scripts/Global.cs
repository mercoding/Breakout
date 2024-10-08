using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public bool gameOver = false;
    public bool ballMoving = false;
    [SerializeField] Player player;
    [SerializeField] Ball ball;


    public void OnStart() {
        player.gameObject.SetActive(true);
        player.transform.position = new Vector3(0, -4.55f, 0);

        ball.gameObject.SetActive(true);
        ball.transform.position = new Vector3(0, -4.1f, 0);

    }

}
