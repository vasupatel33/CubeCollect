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
    [SerializeField] AudioClip ClickSound;
    [SerializeField] bool isVibrationEnabled = true;
    [SerializeField] Sprite SoundOnImg, SoundOffImg;

    public static MenuManager instance;
    private void Start()
    {
        instance = this;
        OnVibrationOnOff();
        TapImage.transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 1.3f).SetLoops(-1, LoopType.Yoyo);
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
        if (SystemInfo.supportsVibration && isVibrationEnabled)
        {
            Handheld.Vibrate();
            Debug.Log("Vibrating");
        }
    }
    public void OnVibrationOnOff()
    {
        isVibrationEnabled = !isVibrationEnabled;
        if (isVibrationEnabled)
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
        Common.InstanceC.gameObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>().PlayOneShot(ClickSound);
        SceneManager.LoadScene(1);
    }
    public void SoundManager()
    {
        Common.InstanceC.gameObject.transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(ClickSound);
        if (Common.InstanceC.isSoundPlaying == false)
        {
            Common.InstanceC.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = false;
            SoundBtn.GetComponent<Image>().sprite = SoundOnImg;
            Common.InstanceC.isSoundPlaying = true;
        }
        else
        {
            Common.InstanceC.gameObject.transform.GetChild(0).GetComponent<AudioSource>().mute = true;
            SoundBtn.GetComponent<Image>().sprite = SoundOffImg;
            Common.InstanceC.isSoundPlaying = false;
        }
    }
    public void SoundSet()
    {
        if (Common.InstanceC.isSoundPlaying == false)
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
}