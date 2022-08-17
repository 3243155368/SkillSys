using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonCtrl : MonoBehaviour, IEventSystemHandler, ISubmitHandler,IPointerClickHandler
{
    public class Click_EventInt : UnityEvent<string> { }

    public Click_EventInt click_EventInt = new Click_EventInt();

    public void OnPointerClick(PointerEventData eventData)
    {
        click_EventInt.Invoke(name);
    }

    public void OnSubmit(BaseEventData eventData)
    {

    }
}

