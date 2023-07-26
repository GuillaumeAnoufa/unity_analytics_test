using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*using UnityEngine.Windows;
*/
public class persoScript : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 50.0f;
    private Rigidbody2D rb2D;
    private Vector3 newPos = Vector3.zero;
    private Vector2 direction = Vector2.zero;
    private int jumpCtr = 0;
    private int maxNbOfJump = 2;
    [SerializeField] private Vector2 jump = new Vector2(0, 5000);

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCtr <= maxNbOfJump)
            {
                rb2D.AddForce(jump, ForceMode2D.Impulse);
                jumpCtr++;
            }
        }
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(direction.x * horizontalSpeed 
            * Time.fixedDeltaTime, rb2D.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "ground")
        {
            jumpCtr = 0;
        }
    }
}