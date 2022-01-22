using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Game3DragArea : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("click done");
        //throw new NotImplementedException();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("click begin");

        //throw new NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("clicking");
        //throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
