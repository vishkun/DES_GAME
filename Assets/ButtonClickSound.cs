using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
    public AudioClip clickSound;   
    public Button[] buttons;          
    void Start()
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(PlayClickSound);
        }
    }

    void PlayClickSound()
    {
        
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = clickSound;        
        
        audioSource.Play();
    }
}