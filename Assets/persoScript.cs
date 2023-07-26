using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*using UnityEngine.Windows;
*/
public class persoScript : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 50.0f;
    private Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        newPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            newPos.x += horizontalSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            newPos.x -= horizontalSpeed * Time.deltaTime;
        }
        transform.position = newPos;
    }
}
