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
    RaycastHit hit1;
    bool test;
    [SerializeField] LayerMask wallLayer;
    Controller ctl;
    // Start is called before the first frame update
    void Start()
    {
        m_amin = GetComponent<Animator>();
        test= true;
        ctl=FindObjectOfType<Controller>();
        UIManager.instance.UpdateCounting(UIManager.instance.heath + "/" + UIManager.instance.maxHeath);
    }

    // Update is called once per frame
     void Update()
    {
        

        if (Physics.Raycast(transform.position, Vector3.left, out hit1, Mathf.Infinity, wallLayer))
        {
            Debug.Log(hit1);
            if (Mathf.Abs(hit1.collider.transform.position.x - transform.position.x) <= 1f)
            {
                Debug.Log("thay");
            }

        }

        
        if (UIManager.instance.heath <= 0)
        {
            test= false;
            UIManager.instance.UpdateCounting("0/" + UIManager.instance.maxHeath);
            UIManager.instance.Lose();
        }
        if (test == false) return;
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
            UIManager.instance.heath -= 10f;
            UIManager.instance.UpdateCounting(UIManager.instance.heath + "/" + UIManager.instance.maxHeath);
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
