using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript2 : MonoBehaviour
{
    public float speed = 5f;
    public bool yy = false;
    public float count = 0; float pos, posy, posx;
    Vector3 temp;
    // todo Start is called before the first frame update
    void Start()
    {

    }

    // todo Update is called once per frame
    void Update()
    {
        temp = transform.localScale;
        pos = transform.localScale.y;
        posx = transform.localScale.x;
        scale(pos, posx);
        transform.localScale = temp;
    }

    int scale(float pos, float posx)
    {

        if (pos < 7 && posx < 32 && yy == false) { temp.x += speed * Time.deltaTime; }
        else if (posx >= 32 && pos <= 7) { temp.y += speed * Time.deltaTime; }
        else if (posx >= 2 && pos >= 7) { temp.x -= speed * Time.deltaTime; yy = true; }
        else if (pos > 1 && yy == true) { temp.y -= speed * Time.deltaTime; }
        else { yy = false; }
        Debug.Log(pos);
        Debug.Log(posx);

        return 0;
    }


}
