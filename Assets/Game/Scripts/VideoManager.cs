using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;

public class VideoManager : MonoBehaviour
{
    public int indexEC;
    [SerializeField] private VideoPlayer fullVidHorizon;
    [SerializeField] private VideoPlayer fullVidVertical;
    [SerializeField] private GameObject ScreenHorizon; 
    [SerializeField] private GameObject ScreenVertical; 
    [SerializeField] private AudioSource audioBG;
    [SerializeField] private GameObject Bg_V;
    private bool isVertical = true;

    private void Awake()
    {
        DeviceOrientation.onLandscapeMode = OnHorizontal;
        DeviceOrientation.onPortraitMode = OnVertical;
        audioBG.Play();
        {
            fullVidHorizon.Play();
            fullVidVertical.Play();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TriggerCTA();
        }
    }

    private void OnHorizontal()
    {
        Bg_V.SetActive(false);
        ScreenHorizon.SetActive(true);
        ScreenVertical.SetActive(false);
    }
    private void OnVertical()
    {
        Bg_V.SetActive(true);
        ScreenVertical.SetActive(true);
        ScreenHorizon.SetActive(false);
    }
    public void TriggerCTA()
    {
        Debug.Log("triggerCTA");
        Luna.Unity.Playable.InstallFullGame("https://play.google.com/store/apps/details?id=com.gamee.familyisland.home.pin.gardenscapes");
        Luna.Unity.LifeCycle.GameEnded();
    }
}
