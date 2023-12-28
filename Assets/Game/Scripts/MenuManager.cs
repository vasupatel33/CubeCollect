using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject TapImage, SettingPanel, InputFieldPanel, BGClickRemoveImage;
    [SerializeField] TMP_InputField InputFieldText;
    [SerializeField] TextMeshProUGUI NameText;
    [SerializeField] Button VibrationBtn, SoundBtn;
    [SerializeField] Sprite VibrationOnImg, VibrationOffImg;
    [SerializeField] Sprite SoundOnImg, SoundOffImg;
    [SerializeField] AudioClip ClickSound;

    [SerializeField] bool isVibrationEnabled = true;

    public static MenuManager instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        TapImage.transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 1.3f).SetLoops(-1,LoopType.Yoyo);
        SoundSet();
    }
    public void OnNameButtonInputPanel()
    {
        Vibration();
        Common.InstanceC.gameObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>().PlayOneShot(ClickSound);
        Debug.Log("Working");
        InputFieldPanel.SetActive(true);
    }
    public void OnDoneButtonInputPanel()
    {
        Vibration();
        Common.InstanceC.gameObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>().PlayOneShot(ClickSound);
        InputFieldPanel.SetActive(false);
        NameText.text = InputFieldText.text;
    }
    public void OnSettingPanelOpen()
    {
        Common.InstanceC.gameObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>().PlayOneShot(ClickSound);
        Vibration();
        SettingPanel.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        BGClickRemoveImage.SetActive(true);
    }
    public void OnSettingPanelClose()
    {
        Vibration();
        Common.InstanceC.gameObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>().PlayOneShot(ClickSound);
        SettingPanel.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        BGClickRemoveImage.SetActive(false);
    }
    public void Vibration()
    {
        if(SystemInfo.supportsVibration && isVibrationEnabled)
        {
            Handheld.Vibrate();
            Debug.Log("Vibrating");
        }
    }
    public void OnVibrationOnOff()
    {
        isVibrationEnabled = !isVibrationEnabled;
        if(isVibrationEnabled)
        {
            VibrationBtn.GetComponent<Image>().sprite = VibrationOnImg;
        }
        else
        {
            VibrationBtn.GetComponent<Image>().sprite = VibrationOffImg;
        }
        Debug.Log("Vibration = " + isVibrationEnabled);
    }
    public void GameSceneLoad()
    {
        Time.timeScale = 1;
        Common.InstanceC.gameObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>().PlayOneShot(ClickSound);
        SceneManager.LoadScene(1);
    }
    public void SoundManagement()
    {
        if (Common.InstanceC.soundPlaying == true)
        {
            SoundBtn.GetComponent<Image>().sprite = SoundOffImg;
            Common.InstanceC.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = true;
            Common.InstanceC.soundPlaying = false;
        }
        else
        {
            SoundBtn.GetComponent<Image>().sprite = SoundOnImg;
            Common.InstanceC.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = false;
            Common.InstanceC.soundPlaying = true;
        }
    }
    public void SoundSet()
    {
        if (Common.InstanceC.soundPlaying == true)
        {
            Common.InstanceC.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = false;
            SoundBtn.GetComponent<Image>().sprite = SoundOnImg;
        }
        else
        {
            Common.InstanceC.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = true;
            SoundBtn.GetComponent<Image>().sprite = SoundOffImg;
        }
    }
    public void OnApplicationQuitt()
    {
        Application.Quit();
    }
}
