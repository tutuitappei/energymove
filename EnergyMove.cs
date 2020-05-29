using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class EnergyMove : MonoBehaviour
{
    private float rotation;                             //回転速度
    [SerializeField] private double rotationSpeed = 0.0;

    [SerializeField] private int pattern = 0;           //行動番号

     private float startTime = 0.0f;                    //動き初めのタイミング
    [SerializeField] private float waittime = 0.0f;     //動くまでの間
    [SerializeField] private float Emovespeed = 0.0f;   //動きの速度

    private Vector3 startPosition;                      //動く前のポジション
    [SerializeField] private double width = 0.0;        //動きの幅

    private bool moveFlag = true;                       //折り返し用フラグ

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
        
        if ((startTime >= waittime)&&(width != 0.0))
        {
            switch (pattern)
            {
                case 1:
                    MoveLR();
                    break;
                case 2:
                    MoveFrontBack();
                    break;
                case 3:
                    MoveUpDown();
                    break;
                case 4:
                    MoveCircle();
                    break;
                case 5:
                    anotheCircle();
                    break;
                default:
                    break;
            }
        }
    }

    //左右移動
    void MoveLR()
    {
        //初動+方向
        if (width > 0)
        {
            if (moveFlag)
            {
                transform.position += new Vector3(Emovespeed * Time.deltaTime, 0f, 0f);
                if (transform.position.x >= startPosition.x + width)
                {
                    moveFlag = false;
                }
            }
            else
            {
                transform.position -= new Vector3(Emovespeed * Time.deltaTime, 0f, 0f);
                if (transform.position.x <= startPosition.x)
                {
                    moveFlag = true;
                }
            }
        }
        //初動-方向
        else
        {
            if (moveFlag)
            {
                transform.position -= new Vector3(Emovespeed * Time.deltaTime, 0f, 0f);
                if (transform.position.x <= startPosition.x + width)
                {
                    moveFlag = false;
                }
            }
            else
            {
                transform.position += new Vector3(Emovespeed * Time.deltaTime, 0f, 0f);
                if (transform.position.x >= startPosition.x)
                {
                    moveFlag = true;
                }
            }
        }    
    }
    //前後移動
    void MoveFrontBack()
    {
        //初動+方向
        if (width > 0)
        {
            if (moveFlag)
            {
                transform.position += new Vector3(0f, 0f, Emovespeed * Time.deltaTime);
                if (transform.position.z >= startPosition.z + width)
                {
                    moveFlag = false;
                }
            }
            else
            {
                transform.position -= new Vector3(0f, 0f, Emovespeed * Time.deltaTime);
                if (transform.position.z <= startPosition.z)
                {
                    moveFlag = true;
                }
            }
        }
        //初動-方向
        else
        {
            if (moveFlag)
            {
                transform.position -= new Vector3(0f, 0f, Emovespeed * Time.deltaTime);
                if (transform.position.z <= startPosition.z + width)
                {
                    moveFlag = false;
                }
            }
            else
            {
                transform.position += new Vector3(0f, 0f, Emovespeed * Time.deltaTime);
                if (transform.position.z >= startPosition.z)
                {
                    moveFlag = true;
                }
            }
        }
    }
    //上下移動
    void MoveUpDown()
    {
        //初動+方向
        if (width > 0)
        {
            if (moveFlag)
            {
                transform.position += new Vector3(0f, Emovespeed * Time.deltaTime, 0f);
                if (transform.position.y >= startPosition.y + width)
                {
                    moveFlag = false;
                }
            }
            else
            {
                transform.position -= new Vector3(0f, Emovespeed * Time.deltaTime, 0f);
                if (transform.position.y <= startPosition.y)
                {
                    moveFlag = true;
                }
            }
        }
        //初動-方向
        else
        {
            if (moveFlag)
            {
                transform.position -= new Vector3(0f, Emovespeed * Time.deltaTime, 0f);
                if (transform.position.y <= startPosition.y + width)
                {
                    moveFlag = false;
                }
            }
            else
            {
                transform.position += new Vector3(0f, Emovespeed * Time.deltaTime, 0f);
                if (transform.position.y >= startPosition.y)
                {
                    moveFlag = true;
                }
            }
        }

    }
    //時計回りの円運動
    //Y軸回転
    void MoveCircle()
    {
        transform.position = new Vector3((float)width * Mathf.Sin(Time.time * Emovespeed) + startPosition.x, startPosition.y, ((float)width * Mathf.Cos(Time.time * Emovespeed)) + startPosition.z);
    }
    void anotheCircle()
    {
        if (width > 0)
        {
            //X軸回転
            transform.position = new Vector3(startPosition.x, (float)width * Mathf.Sin(Time.time * Emovespeed) + startPosition.y, ((float)width * Mathf.Cos(Time.time * Emovespeed)) + startPosition.z);
        }
        else
        {
            //Z軸回転
            transform.position = new Vector3((float)+width * Mathf.Sin(Time.time * Emovespeed) + startPosition.x, ((float)+width * Mathf.Cos(Time.time * Emovespeed)) + startPosition.y, startPosition.z);
        }
    }
}
