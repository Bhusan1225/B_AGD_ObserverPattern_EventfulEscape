using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController 
{
    public Action baseAction;

    public void AddListener(Action listener) => baseAction += listener;
    
    public void removeListener(Action listener) => baseAction -= listener;
   
    public void InvokeEvent() => baseAction?.Invoke();
   
}
