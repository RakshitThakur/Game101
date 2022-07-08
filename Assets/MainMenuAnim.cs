using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnim : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> eyeAnim = new List<GameObject>();

    [SerializeField]
    private AudioClip popSound;

    [SerializeField]
    private AudioSource audioSource;
    private IEnumerator Start()
    {
        foreach(var item in eyeAnim)
        {
            yield return new WaitForSecondsRealtime(UnityEngine.Random.Range(0.1f, 0.5f));
            item.SetActive(true);
            PlaySound(popSound);
        }
    }

    void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
