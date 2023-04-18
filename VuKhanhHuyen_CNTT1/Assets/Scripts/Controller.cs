using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] protected float rightPlayer;
    [SerializeField] protected float leftPlayer;
    [SerializeField] protected float speed;
    float heathEnenmy = 100f;
    float heathBot = 250f;
    Rigidbody2D m_rb;
    Animator m_amin;
    bool is_start;
    protected bool is_finish;
    Enemy em;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_amin = GetComponent<Animator>();
        em = FindObjectOfType<Enemy>();
        is_start = true;
        is_finish = true;
        UIManager.instance.UpdateCounting(UIManager.instance.heath + "/" + UIManager.instance.maxHeath);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (is_finish == false) return;
        UIManager.instance.AddDamPlayer();
        UIManager.instance.AddHpPlayer();
        if (UIManager.instance.checkDam <= 0) return;
        if (is_start == false) return;
        if (UIManager.instance.heath == 0)
        {
            if (m_amin)
            {
                m_amin.SetTrigger("Die");
            }
            is_finish= false;
        }
        if (Input.GetKey(KeyCode.A) && gameObject.transform.position.x > leftPlayer)
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
        else if (Input.GetKey(KeyCode.D)&&gameObject.transform.position.x<rightPlayer)
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
        if (col.tag == "Finish")
        {
            UIManager.instance.HpBot();
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
                UIManager.instance.DieEnemy();
                Destroy(col.gameObject);
                heathEnenmy = 100f;
                UIManager.instance.LoadHP();
            }
        }
        if (col.tag == "Bot")
        {
            Debug.Log("bot");
            heathBot = heathBot - 15f;
            UIManager.instance.ReduceHPBot();
            UIManager.instance.ReduceDamage();
            if (heathBot <= 0)
            {
                is_finish = false;
                UIManager.instance.DieBot();
                Destroy(col.gameObject,2f);
                heathBot = 200f;
                UIManager.instance.LoadHP();
                UIManager.instance.Win();
            }
        }
        

    }
}
