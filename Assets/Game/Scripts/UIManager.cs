using UnityEngine;

public class UIManager : MonoBehaviour
{
     public void TriggerCTA()
    {
        Debug.Log("triggerCTA");
        Luna.Unity.Playable.InstallFullGame("https://play.google.com/store/apps/details?id=com.gamee.dragon.kingdom.castle.match.story.puzzle");
        Luna.Unity.LifeCycle.GameEnded();
    }
}
