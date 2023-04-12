using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    float time=3f;
    Animator m_amin;
    int lan = 0;
    public GameObject hpUi;
    // Start is called before the first frame update
    void Start()
    {
        m_amin = GetComponent<Animator>();

    }

    // Update is called once per frame
     void Update()
    {
       
        if (lan==1)
        {
            Danh();
        }
    }
    protected void Danh()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            m_amin.SetTrigger("Attack");
            UIManager.instance.ReduceHPPlayer();
            time = 3f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hpUi.activeInHierarchy)
        {
            lan = 1;
        }
        else
        {
            lan= 0;
        }
    }
}
