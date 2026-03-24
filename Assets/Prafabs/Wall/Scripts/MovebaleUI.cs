using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovebaleUI : MonoBehaviour
{
    [SerializeField] LayerMask UIlayer;
    private EventHandler OnScreenTouche;


    private void Start()
    {
        
    }


    private void Update()
    {
        MoveUI();
    }
    private void MoveUI()
    {
        if(UIRayCast() != null)
        {

            UIRayCast().position = InputPos() ;
        }
    }


    private Transform UIRayCast()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = InputPos()
        };
     

        List<RaycastResult> hit = new();
        EventSystem.current.RaycastAll(pointerData, hit);
       
        
        foreach (RaycastResult hitResult in hit)
        {
            if (hitResult.gameObject.transform.CompareTag("UI"))
            {
                
                return hitResult.gameObject.transform;
            }
        }
        return null;    
    }




    private Vector2 InputPos()
    {
        if(Input.touchCount > 0)
        {
            
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                Vector2 touchePos = touch.position;
                return touchePos;
            }
        } 
        return Vector2.zero;
    }
}
