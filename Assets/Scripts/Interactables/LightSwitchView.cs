using System;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchView : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Light> lightsources = new List<Light>();
    private SwitchState currentState;


    

    public static event Action lightToggledAction;
    private void Start() => currentState = SwitchState.Off;


    private void OnEnable()
    {
        lightToggledAction += OnLightSwitchToggle;   //subscription
    }
    private void OnDisable()
    {
        lightToggledAction -= OnLightSwitchToggle;  //unsubsriribe
    }

    public void Interact()
    {


        lightToggledAction?.Invoke(); 

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
