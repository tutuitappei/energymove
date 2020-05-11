using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class EnergyMove : MonoBehaviour
{
    private float rotation;
    [SerializeField] private double rotationSpeed = 0.0;

    [SerializeField] private int pattern = 0;

     private float startTime = 0.0f;
    [SerializeField] private float interval = 0.0f;

    private Vector3 startPosition;
    [SerializeField] private double width = 0.0;

    bool moveFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        rotation = (float)rotationSpeed;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;
        transform.Rotate(new Vector3(0,rotation,0));
        
        if (startTime >= interval)
        {
            switch (pattern)
            {
                case 0:
                    break;
                case 1:
                    MoveLR();
                    break;
                case 2:
                    MoveFrontBack();
                    break;
                case 3:
                    MoveUpDown();
                    break;
                default:
                    break;
            }
        }
    }

    void MoveLR()
    {
        if (moveFlag)
        {
            transform.position += new Vector3(2f * Time.deltaTime, 0f, 0f);
            if (transform.position.x >= startPosition.x + width)
            {
                moveFlag = false;
            }
        }
        else
        {
            transform.position -= new Vector3(2f * Time.deltaTime, 0f, 0f);
            if (transform.position.x <= startPosition.x)
            {
                moveFlag = true;
            }
        }
    }
    void MoveFrontBack()
    {
        if (moveFlag)
        {
            transform.position += new Vector3(0f, 0f, 2f * Time.deltaTime);
            if (transform.position.z >= startPosition.z + width)
            {
                moveFlag = false;
            }
        }
        else
        {
            transform.position -= new Vector3(0f, 0f, 2f * Time.deltaTime);
            if (transform.position.z <= startPosition.z)
            {
                moveFlag = true;
            }
        }
    }
    void MoveUpDown()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
