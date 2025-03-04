using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TextEffect : MonoBehaviour
{
    [SerializeField] private Transform txt1;
    [SerializeField] private Transform txt2;
    [SerializeField] SpriteRenderer spriteRenderer1;
    [SerializeField] SpriteRenderer spriteRenderer2;
    [SerializeField] float timeDelay1;
    [SerializeField] float timeDelay2;
    private Sequence sequence;
    private float deltaTime;
    private void Start()
    {
        spriteRenderer1.enabled = false;
        spriteRenderer2.enabled = false;
        deltaTime = timeDelay2 - timeDelay1;
        StartCoroutine(OnEffect1());
        StartCoroutine(OnEffect2());
    }

    IEnumerator OnEffect1()
    {
        yield return new WaitForSeconds(timeDelay1);
        spriteRenderer1.enabled = true;
        Vector3 scale = txt1.localScale;
        // Khởi tạo Sequence bên trong phương thức
        txt1.DOScale(scale + new Vector3(0.02f, 0.02f, 0.02f), 0.2f)
            .SetEase(Ease.Linear);
        txt1.DOMove(txt1.position + new Vector3(0, 0.15f, 0), 0.2f)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                txt1.DOMove(txt1.position - new Vector3(0, 0.13f, 0), 0.2f)
                    .SetEase(Ease.Linear);
                txt1.DOScale(scale, 0.2f)
                    .SetEase(Ease.Linear);
            });

        yield return new WaitForSeconds((deltaTime > 0) ? 2 : (2 + deltaTime));
        spriteRenderer1.enabled = false;
        StartCoroutine(OnEffect1());
    }
    IEnumerator OnEffect2()
    {
        yield return new WaitForSeconds(timeDelay2);
        spriteRenderer2.enabled = true;
        Vector3 scale = txt2.localScale;
        // Khởi tạo Sequence bên trong phương thức
        txt2.DOScale(scale + new Vector3(0.02f, 0.02f, 0.02f), 0.2f)
            .SetEase(Ease.Linear);
        txt2.DOMove(txt2.position + new Vector3(0, 0.15f, 0), 0.2f)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                txt2.DOMove(txt2.position - new Vector3(0, 0.13f, 0), 0.2f)
                    .SetEase(Ease.Linear);
                txt2.DOScale(scale, 0.2f)
                    .SetEase(Ease.Linear);
            });

        yield return new WaitForSeconds((deltaTime > 0) ? (2 - deltaTime) : 2);
        spriteRenderer2.enabled = false;
        StartCoroutine(OnEffect2());
    }
}