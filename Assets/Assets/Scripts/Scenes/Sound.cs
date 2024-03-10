using UnityEngine;

public class Sound: MonoBehaviour
{
    public AudioClip jumpSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            Jump();
        }
    }

    private void Jump()
    {
       
        if (jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }
}

