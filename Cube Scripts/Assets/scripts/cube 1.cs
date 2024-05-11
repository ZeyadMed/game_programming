using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 5f;
    public bool left = false;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        float xx = transform.position.x;
        float zz = transform.position.z;
        position(xx, zz);



    }

    void position(float x, float z)
    {
        //? Move right if x is less than 13
        if (x < 13 && z < -8.97 && left == false)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        //? Move forward if x is greater than 13 and z is less than or equal to 8.009366
        else if (x > 13 && z <= 8.009366)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            left = true;
        }
        //? Move left if z is greater than 8
        else if (left == true && x > -13)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        //? Default: Move right
        else
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
            left = false;

        }
    }
}