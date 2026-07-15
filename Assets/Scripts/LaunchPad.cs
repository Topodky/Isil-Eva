using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    public AudioClip compressSound;
    public AudioClip launchSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCompressSound()
    {
        audioSource.PlayOneShot(compressSound);
    }

    public void PlayLaunchSound()
    {
        audioSource.PlayOneShot(launchSound);
    }
}