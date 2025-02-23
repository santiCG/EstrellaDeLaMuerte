using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SelectSound(int index)
    {
        switch (index)
        {
            case 1:
                audioSource.clip = clips[0];
                audioSource.Play();
                break;
            case 2:
                audioSource.clip = clips[2];
                audioSource.Play();
                break;

            case 3:
                audioSource.clip = clips[1];
                audioSource.Play();
                break;
        }
    }
}
