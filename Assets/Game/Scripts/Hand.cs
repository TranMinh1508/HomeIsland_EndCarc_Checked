using System;
using System.Collections;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private Animator anim;

    private void Start()
    {
        SetUp();
    }

    public void SetUp()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(Click());
        }
    }

    IEnumerator Click()
    {
        if (!gameObject.activeSelf)
        {
            yield break;
        }
        source.Play();
        anim.ResetTrigger("click");
        anim.SetTrigger("click");
        yield return new WaitForSeconds(1f);
        if (!gameObject.activeSelf)
        {
            yield break;
        }
        StartCoroutine(Click());
    }
}
