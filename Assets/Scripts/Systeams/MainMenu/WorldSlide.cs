using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorldSlide : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{

    float minX;
    float maxX;
    float y;
    RectTransform rectTransform;
    public float slipSensitivity = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        minX =-GetComponent<RectTransform>().rect.width / 2 + (-transform.parent.GetComponent<RectTransform>().rect.x * 2);
        maxX = GetComponent<RectTransform>().rect.width / 2;
        y = transform.parent.GetComponent<RectTransform>().rect.y;
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        AreaLimit();
    }

    private void AreaLimit()
    {
        if (rectTransform.position.x > maxX)
        {
            rectTransform.position = new Vector2(maxX, -y);
        }
        if (rectTransform.position.x < minX)
        {
            rectTransform.position = new Vector2(minX, -y);
        }
        //rectTransform.position.y=
        //throw new NotImplementedException();
    }




    Vector2 beganDragPoint;
    Vector2 offsetV3;
    public void OnEndDrag(PointerEventData eventData)   
    {
        beganDragPoint = eventData.position;
        offsetV3 = eventData.position;
        //throw new NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        offsetV3 = beganDragPoint - eventData.position;
        rectTransform.position -= new Vector3( offsetV3.x,0,0)* slipSensitivity;
        //throw new NotImplementedException();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        beganDragPoint = eventData.position;
        offsetV3 = eventData.position;

        //throw new NotImplementedException();
    }
}
