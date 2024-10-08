using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Global global;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(300, 200));
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Brick") {
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Floor") {
            global.gameOver = true;
            global.OnStop();
        }
    }
}
