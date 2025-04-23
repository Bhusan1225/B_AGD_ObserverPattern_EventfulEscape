 using System.Collections.Generic;
using UnityEngine;

public class LightSwitchView : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Light> lightsources = new List<Light>();
    private SwitchState currentState;


    public delegate void LightSwitchDelegate();  //signature -  signature is return type should be void and there should no parameter
    public LightSwitchDelegate lightSwitch;      //instance

    private void Start() => currentState = SwitchState.Off;


    private void OnEnable()
    {
        lightSwitch = OnLightSwitchToggle;
    }
    public void Interact()
    {
      

        lightSwitch.Invoke(); // call the instance

    }
    private void toggleLights()
    {
        bool lights = false;

        switch (currentState)
        {
            case SwitchState.On:
                currentState = SwitchState.Off;
                lights = false;
                break;
            case SwitchState.Off:
                currentState = SwitchState.On;
                lights = true;
                break;
            case SwitchState.Unresponsive:
                break;
        }
        foreach (Light lightSource in lightsources)
        {
            lightSource.enabled = lights;
        }
    }

    private void OnLightSwitchToggle()
    {
        toggleLights();
        GameService.Instance.GetInstructionView().HideInstruction();
        GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.SwitchSound);
    }
}
