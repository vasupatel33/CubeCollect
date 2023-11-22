using UnityEngine;
using DG.Tweening;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject TapImage, SettingPanel;

    private bool isVibrationEnabled = true;

    private void Start()
    {
        TapImage.transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 1.3f).SetLoops(-1,LoopType.Yoyo);
    }
    public void OnSettingPanelOpen()
    {
        SettingPanel.SetActive(true);
    }
    public void OnSettingPanelClose()
    {
        SettingPanel.SetActive(false);
    }
    public void Vibration()
    {
        if(SystemInfo.supportsVibration && isVibrationEnabled)
        {
            Handheld.Vibrate();
        }
    }
    public void OnVibrationOnOff()
    {
        isVibrationEnabled = !isVibrationEnabled;
        Debug.Log("Vibration = " + isVibrationEnabled);
    }
    public void GameSceneLoad()
    {
        SceneManager.LoadScene(1);
    }    
}
