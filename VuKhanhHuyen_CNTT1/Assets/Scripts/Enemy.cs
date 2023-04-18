using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    float time=3f;
    Animator m_amin;
    [SerializeField] GameObject hpUi;
    public Transform player;
    RaycastHit hit1;
    bool test;
    [SerializeField] LayerMask wallLayer;
    [SerializeField] Image hpEnemy;
    float heathEnenmy = 100f;

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
        if(Mathf.Abs(transform.position.x - player.transform.position.x) <= 3f) 
        {
            hpUi.SetActive(true);
            Danh();
            if (UIManager.instance.timedie == 2)
            {
                m_amin.SetTrigger("Get Hit");
                ReduceHPEnemy();
                heathEnenmy -= 15f;
                Debug.Log(hpEnemy.fillAmount);
                
            }
        }
        else
        {
            hpUi.SetActive(false);
        }
        if (heathEnenmy <= 0)
        {
            m_amin.SetTrigger("Die");
            Destroy(gameObject, 1f);
            test= false;
        }

    }
    
    protected void Danh()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            m_amin.SetTrigger("Attack");
            UIManager.instance.ReduceHPPlayer();
            UIManager.instance.heath -= 10f;
            UIManager.instance.UpdateCounting(UIManager.instance.heath + "/" + UIManager.instance.maxHeath);
            time = 3f;
           
        }
    }
    protected void ReduceHPEnemy()
    {
        hpEnemy.fillAmount = hpEnemy.fillAmount - 0.15f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
    }
}
