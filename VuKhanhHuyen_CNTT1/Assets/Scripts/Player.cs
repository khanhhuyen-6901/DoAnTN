using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float move;
    public float speed;
    Rigidbody2D m_rb;
    Animator m_amin;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        m_rb=GetComponent<Rigidbody2D>();
        m_amin=GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Flip();
        //transform.position= new Vector3(Mathf.Clamp(transform.position.x,0f,37f),transform.position.y,transform.position.z);
    }
    private void FixedUpdate()
    {
        MoveHandle();
    }
    void Flip()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
        }
    }
    void MoveHandle()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (m_rb)
            {
                m_rb.velocity = new Vector2(-1f, m_rb.velocity.y) * speed;
            }
            if (m_amin)
            {
                m_amin.SetTrigger("Run");
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (m_rb)
            {
                m_rb.velocity = new Vector2(1f, m_rb.velocity.y) * speed;
            }
            if (m_amin)
            {
                m_amin.SetTrigger("Run");
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (m_amin)
            {
                m_amin.SetTrigger("Get Hit");
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {
            if (m_amin)
            {
                m_amin.SetTrigger("Attack");
            }
        }
        else
        {
            if (m_rb)
            {
                m_rb.velocity = new Vector2(0, m_rb.velocity.y);
            }
            if (m_amin)
            {
                m_amin.SetTrigger("Idle");
            }
        }
    }
}
