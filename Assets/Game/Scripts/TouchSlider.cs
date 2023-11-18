using UnityEngine;
using UnityEngine.UI;

public class TouchSlider : MonoBehaviour
{
    public Slider slider;
    public float moveSpeed;
    public float maxForce;

    private Rigidbody rb;

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();

    //    // Attach the callback method to the onValueChanged event of the slider
    //    slider.onValueChanged.AddListener(OnSliderValueChanged);
    //}

    private void Update()
    {
        float sliderValue = slider.value;

        // Map the slider value to the position of the cube
        float newPositionX = Mathf.Lerp(-2f, 2f, (sliderValue + 1f) / 2f); // Adjust the range as needed

        // Smoothly move the cube's position
        transform.position = Vector3.Lerp(transform.position, new Vector3(newPositionX, transform.position.y, transform.position.z), moveSpeed * Time.deltaTime);
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
