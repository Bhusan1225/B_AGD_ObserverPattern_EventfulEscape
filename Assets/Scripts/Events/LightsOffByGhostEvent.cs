using UnityEngine;

public class LightsOffByGhostEvent : MonoBehaviour
{
    [SerializeField]
    int KeysReqiredToTrigger;
    [SerializeField]
    SoundType soundType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerView>() != null && KeysReqiredToTrigger == GameService.Instance.GetPlayerController().KeysEquipped)
        {
            EventService.Instance.OnLightsOffByGhostEvent.InvokeEvent();
            GameService.Instance.GetSoundView().PlaySoundEffects(soundType);
            this.enabled = false;
        }
    }
}