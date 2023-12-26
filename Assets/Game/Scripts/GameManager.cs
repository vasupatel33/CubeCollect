using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] Animator GameOverPanelAnim;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    public void OnRetryBtnClicked()
    {
        Time.timeScale = 1;
        GameOverPanelAnim.SetBool("OverPanel", false);
        StartCoroutine(GameOverPanelWait());
    }
    public void GameOverPanelAnimation()
    {
        GameOverPanelAnim.SetBool("OverPanel", true);
        StartCoroutine(TimeScaleOff());
    }
    IEnumerator TimeScaleOff()
    {
        yield return new WaitForSeconds(2);
        Time.timeScale = 0;
    }
    IEnumerator GameOverPanelWait()
    {
        yield return new WaitForSeconds(0.5f);
        GameOverPanel.SetActive(false);
        SceneManager.LoadScene(1);
    }
    public void OnHomeBtnClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}