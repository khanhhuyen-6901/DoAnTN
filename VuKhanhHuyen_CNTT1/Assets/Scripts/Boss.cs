using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    float timeline = 8f;
    Animator m_amin;
    int boss = 0;
    public GameObject hpUiBoss;
    bool test;
    // Start is called before the first frame update
    void Start()
    {
        m_amin = GetComponent<Animator>();
        test= true;
        UIManager.instance.UpdateCounting(UIManager.instance.heath + "/" + UIManager.instance.maxHeath);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (UIManager.instance.heath <= 0)
        {
            test= false;
            UIManager.instance.UpdateCounting("0/" + UIManager.instance.maxHeath);
            UIManager.instance.Lose();
        }
        if (test == false) return;
        if (boss == 1)
        {
            BossDanh();
        }
        if (UIManager.instance.checkBot == 0)
        {
            m_amin.SetTrigger("Die");
            test = false;
        }
    }
    protected void BossDanh()
    {
        timeline -= Time.deltaTime;
        if (timeline <= 0)
        {
            m_amin.SetTrigger("Attack");
            UIManager.instance.ReduceHPPlayer1();
            UIManager.instance.heath -= 15f;
            UIManager.instance.UpdateCounting(UIManager.instance.heath + "/" + UIManager.instance.maxHeath);
            timeline = 8f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hpUiBoss.activeInHierarchy)
        {
            boss = 1;
        }
        else
        {
            boss = 0;
        }
    }
}
