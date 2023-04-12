using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] protected float heath;
    [SerializeField] protected float damage;
    [SerializeField] protected float speed;
    [SerializeField] LayerMask wallLayer;
    float heathEnenmy = 100f;
    float maxHeath;
    Rigidbody2D m_rb;
    Animator m_amin;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_amin = GetComponent<Animator>();
        maxHeath = heath;
        UIManager.instance.UpdateCounting(heath + "/" + maxHeath);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        UIManager.instance.AddDamPlayer();
        //Debug.Log(UIManager.instance.checkDam);
        //if (UIManager.instance.checkDam <= 0) return;
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
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Wall")
        {
            UIManager.instance.HpEnemy();
            Destroy(col.gameObject);
        }
        if (col.tag=="Enemy")
        {
            Debug.Log("cham");
            heathEnenmy = heathEnenmy - 15f;
            UIManager.instance.ReduceHPEnemy();
            UIManager.instance.ReduceDamage();
            if (heathEnenmy <= 0)
            {
                Destroy(col.gameObject);
                UIManager.instance.DieEnemy();
                heathEnenmy = 100f;
                UIManager.instance.LoadHP();
            }
        }
        
    }
}
