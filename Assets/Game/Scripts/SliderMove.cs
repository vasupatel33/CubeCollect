using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections.Generic;

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
    //void OnSliderValueChanged(float value)
    //{
    //    // Calculate the force based on the slider value
    //    float forceMagnitude = value * maxForce;

    //    transform.Translate(new Vector3(forceMagnitude * Time.deltaTime * moveSpeed,0,0));
    //    transform.position = Vector3.Lerp()
    //    // Apply force to move the player
    //    //rb.velocity = new Vector3(forceMagnitude, 0f, 0f) * moveSpeed;
    //}
}