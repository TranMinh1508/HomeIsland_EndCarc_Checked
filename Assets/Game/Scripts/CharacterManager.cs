using System.Collections;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private AudioSource audio;

    private void Start()
    {
        StartCoroutine(LoopSound());
    }

    IEnumerator LoopSound()
    {
        yield return new WaitForSeconds(5f);
        audio.Play();
        StartCoroutine(LoopSound());
    }
}
