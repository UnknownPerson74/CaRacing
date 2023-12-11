using UnityEngine;

public class CarSound : MonoBehaviour
{
    private AudioSource carAudio;
    public AudioClip engineSound;
    public AudioClip brakeSound;
    private Rigidbody rb;

    public float minSpeed;
    public float maxSpeed;
    public float minPitch;
    public float maxPitch;
    public float brakePitchMultiplier = 0.5f; // Adjust as needed for brake sound
    public float brakeSpeedThreshold = 2.0f;  // Adjust as needed for when to trigger brake sound


    void Start()
    {
        carAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        carAudio.clip = engineSound;

        carAudio.Play();
    }

    private void Update()
    {
        EngineSound();
        BrakeSound();
    }

    void EngineSound()
    {
        float normalizedSpeed = Mathf.InverseLerp(minSpeed, maxSpeed, rb.velocity.magnitude);

        // Clamp normalized speed between 0 and 1 to ensure it stays within the range
        normalizedSpeed = Mathf.Clamp01(normalizedSpeed);

        // Calculate pitch based on the normalized speed
        float pitch = Mathf.Lerp(minPitch, maxPitch, normalizedSpeed);

        // Apply the pitch to the audio source
        carAudio.pitch = pitch;
    }
    void BrakeSound()
    {
        // Check if the space key is pressed and the car is moving
        if (Input.GetKey(KeyCode.Space) && rb.velocity.magnitude > brakeSpeedThreshold)
        {
            // If the audio clip is not the brake sound, switch to it
            if (carAudio.clip != brakeSound)
            {
                carAudio.clip = brakeSound;
                carAudio.Play(); // Start playing the brake sound
            }
        }
        else
        {
            // If the brake key is released or the speed is below the threshold, switch back to the engine sound
            if (carAudio.clip == brakeSound)
            {
                carAudio.clip = engineSound;
                carAudio.Play(); // Start playing the engine sound
            }
        }
    }

}



