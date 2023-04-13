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
    [SerializeField] GameObject hpBot;
    [SerializeField] Image damagePlayer;
    [SerializeField] Image hpPlayer;
    [SerializeField] Image hpEnemy;
    [SerializeField] Image hpBotDragon;
    public string curentScene;
    public string nextScene;
    public Text couting;
    public float time = 15f;
    public float timeline = 20f;
    public float checkDam=1f;
    public float checkBot=1f;
    public float heath;
    public float maxHeath;
    // Start is called before the first frame update
    void Start()
    {
        maxHeath = heath;
    }



    public void Replay()
    {

        SceneManager.LoadScene(curentScene);
    }
    public void ReduceHPEnemy()
    {
        hpEnemy.fillAmount = hpEnemy.fillAmount - 0.15f;
    }
    public void ReduceHPBot()
    {
        hpBotDragon.fillAmount -= 0.06f;
        checkBot= hpBotDragon.fillAmount;
    }
    public void LoadHP()
    {
        hpEnemy.fillAmount = 1f;
        hpBotDragon.fillAmount = 1f;
    }
    public void ReduceDamage()
    {
        damagePlayer.fillAmount = damagePlayer.fillAmount - 0.05f;
        checkDam = damagePlayer.fillAmount;
    }
    public void ReduceHPPlayer()
    {
        hpPlayer.fillAmount -= 0.05f;
    }
    public void ReduceHPPlayer1()
    {
        hpPlayer.fillAmount -= 0.06f;
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
    public void HpBot()
    {
        hpBot.SetActive(true);
    }
    public void DieBot()
    {
        hpBot.SetActive(false);
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
                checkDam = damagePlayer.fillAmount;
                time = 15f;
            }
        }
    }
    public void AddHpPlayer()
    {
       

        if (hpPlayer.fillAmount < 1f)
        {
            timeline -= Time.deltaTime;
            if (timeline <= 0)
            {
                if (heath + 50f >200f)
                {
                    heath = maxHeath;
                }
                else
                {
                    heath += 50f;
                }
                hpPlayer.fillAmount += 0.25f;
                UpdateCounting(heath + "/" + maxHeath);
                timeline = 20f;
            }
        }
    }
    public void InstructBtn()
    {
        winUI.SetActive(true) ;
    }
    public void ExitBtn()
    {
        winUI.SetActive(false);
    }
    public void lateTime() 
    {
        StartCoroutine(AddDamage());
    }
    IEnumerator ActivateUI(GameObject ui)
    {
        yield return new WaitForSeconds(3f);
        ui.SetActive(true);
    }
    IEnumerator AddDamage()
    {
        yield return new WaitForSeconds(1f);
    }
}
