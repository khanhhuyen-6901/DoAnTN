using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Controller
{
    

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Flip();
        //transform.position= new Vector3(Mathf.Clamp(transform.position.x,0f,37f),transform.position.y,transform.position.z);
    }
    
    void Flip()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            }
        }
    }
    
}
