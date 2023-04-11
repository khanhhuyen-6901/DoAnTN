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
    public string curentScene;
    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    public void OnInit()
    {

    }


    public void Replay()
    {

        SceneManager.LoadScene(curentScene);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextScene);
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
    IEnumerator ActivateUI(GameObject ui)
    {
        yield return new WaitForSeconds(3f);
        ui.SetActive(true);
    }
}
