using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    protected string currentAnim;
    [SerializeField] protected Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void ChangeAnim(string animName)
    {
        // ham thay doi trang thai cua anim
        if (currentAnim != animName)
        {
            anim.ResetTrigger(currentAnim);
            currentAnim = animName;
            anim.SetTrigger(currentAnim);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag=="Enemy")
        {
            UIManager.instance.HpEnemy();
        }
    }
}
