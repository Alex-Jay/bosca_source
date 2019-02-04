using UnityEngine;
using UnityEngine.EventSystems;

public class AudioButtonNode : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    [SerializeField]
    private AudioSource audioSource;

    void Start ()
    {
        audioSource = AudioManager.instance.GetAudioSource(AudioManager.AudioSourceIDs.UI);
    }
    
    public void OnPointerEnter(PointerEventData ped)
    {
        audioSource.clip = AudioManager.instance.uiButtonHighlighted;
        audioSource.Play();
    }

    public void OnPointerDown(PointerEventData ped)
    {
        audioSource.clip = AudioManager.instance.uiButtonPressed;
        audioSource.Play();
    }
}
