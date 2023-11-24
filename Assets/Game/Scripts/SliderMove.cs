using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SliderMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Slider slider;

    public UnityEvent OnSliderClick;

    
    // UnityEvent for when the user releases the click on the slider
    public UnityEvent OnSliderRelease;

    public float moveSpeed;
    //public float maxForce;

    [SerializeField] GameObject CurrentPlayer;
    [SerializeField] GameObject parent;
    [SerializeField] List<GameObject> CubePref;
    [SerializeField] AudioClip AddForceSound;
    private Rigidbody rb;

    private void Update()
    {
        if (CurrentPlayer != null)
        {
            float sliderValue = slider.value;

            // Map the slider value to the position of the cube
            float newPositionX = Mathf.Lerp(-1.5f, 1.5f, (sliderValue + 1f) / 2f); // Adjust the range as needed
                                                                                   // Smoothly move the cube's position
            CurrentPlayer.transform.position = Vector3.Lerp(CurrentPlayer.transform.position, new Vector3(newPositionX, CurrentPlayer.transform.position.y, CurrentPlayer.transform.position.z), moveSpeed * Time.deltaTime);
        }
    }
    void SpawnCube()
    {
        int randomVal = Random.Range(0, CubePref.Count);
        CurrentPlayer = Instantiate(CubePref[randomVal], new Vector3(0, 4f, -5.5f), Quaternion.identity, parent.transform);
        CurrentPlayer.transform.DOScale(new Vector3(0,0,0), 0.01f);
        CurrentPlayer.transform.DOScale(new Vector3(1, 1, 1), .8f).SetEase(Ease.OutBounce);
    }
    public void OnCLickRelease()
    {
        Debug.Log("Force applied");
        CurrentPlayer.GetComponent<Rigidbody>().AddForce(Vector3.forward * moveSpeed, ForceMode.VelocityChange);
        //this.transform.SetParent(newParent);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Ensure the slider component is not null
        if (slider != null)
        {
            // Add this script as a listener for pointer events
            EventTrigger eventTrigger = slider.gameObject.GetComponent<EventTrigger>();
            if (eventTrigger == null)
            {
                eventTrigger = slider.gameObject.AddComponent<EventTrigger>();
            }

            // Add pointer down and up event listeners
            AddEventTriggerListener(eventTrigger, EventTriggerType.PointerDown, HandleSliderClick);
            AddEventTriggerListener(eventTrigger, EventTriggerType.PointerUp, HandleSliderRelease);
        }
        else
        {
            Debug.LogError("Slider is not assigned in the inspector!");
        }
    }

    // Method to be called when the slider is clicked
    void HandleSliderClick(BaseEventData eventData)
    {
        OnSliderClick.Invoke(); // Invoke any additional events or actions
    }

    // Method to be called when the slider click is released
    void HandleSliderRelease(BaseEventData eventData)
    {
        Common.InstanceC.gameObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>().PlayOneShot(AddForceSound);
        MenuManager.instance.Vibration();
        OnSliderRelease.Invoke(); // Invoke any additional events or actions
        Invoke("SpawnCube", 0.4f);
    }
    
    void AddEventTriggerListener(EventTrigger trigger, EventTriggerType eventType, UnityAction<BaseEventData> callback)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventType;
        entry.callback.AddListener((data) => callback.Invoke(data));
        trigger.triggers.Add(entry);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
    }
    public void OnPointerUp(PointerEventData eventData)
    {
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}