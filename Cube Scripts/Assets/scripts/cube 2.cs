using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    public float speed = 100;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (count > 199 && count < 400) { transform.Rotate(speed, 0, 0); count += 1; }
        else if (count < 200) { transform.Rotate(0, speed, 0); count += 1; }
        else if (count > 399 && count < 600) { transform.Rotate(0, 0, speed); count += 1; }
        else { count = 0; }

    }
}
