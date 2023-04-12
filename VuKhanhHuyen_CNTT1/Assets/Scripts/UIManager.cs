using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : Singleton<UIManager>
{

    [SerializeField] GameObject winUI;
    [SerializeField] GameObject loseUI;
    [SerializeField] GameObject hpUI;
    [SerializeField] Image damagePlayer;
    [SerializeField] Image hpPlayer;
    [SerializeField] Image hpEnemy;
    public string curentScene;
    public string nextScene;
    public Text couting;
    public float time = 20f;
    public float timeline = 3f;
    public float checkDam=1f;
    // Start is called before the first frame update
    void Start()
    {
       
    }



    public void Replay()
    {

        SceneManager.LoadScene(curentScene);
    }
    public void ReduceHPEnemy()
    {
        hpEnemy.fillAmount = hpEnemy.fillAmount - 0.15f;
    }
    public void LoadHP()
    {
        hpEnemy.fillAmount = 1f;
    }
    public void ReduceDamage()
    {
        damagePlayer.fillAmount = damagePlayer.fillAmount - 0.05f;
        checkDam = damagePlayer.fillAmount;
    }
    public void ReduceHPPlayer()
    {
        hpPlayer.fillAmount -= 0.025f;
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(nextScene);
    }
    public void UpdateCounting(string score)
    {
        if (couting)
        {
            couting.text = score;
        }
    }
    public void Win()
    {
        
        StartCoroutine(ActivateUI(winUI));
    }

    public void Lose()
    {    
        StartCoroutine(ActivateUI(loseUI));
    }
    public void HpEnemy()
    {
        hpUI.SetActive(true);
    }
    public void DieEnemy()
    {
        hpUI.SetActive(false);
    }
    public void AddDamPlayer()
    {

        if (damagePlayer.fillAmount < 1f) 
        {
            time -= Time.deltaTime;
            if(time <= 0)
            {   
                damagePlayer.fillAmount += 0.2f;
                time = 20f;
            }
        }
    }
    public void changeAnim()
    {
        timeline -= Time.deltaTime;
        if (timeline <= 0)
        {
            timeline = 3f;
        }
    }
    IEnumerator ActivateUI(GameObject ui)
    {
        yield return new WaitForSeconds(3f);
        ui.SetActive(true);
    }
    IEnumerator AddDamage()
    {
        yield return new WaitForSeconds(3f);
    }
}
