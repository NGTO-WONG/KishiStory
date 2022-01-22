using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageNumber : BasePanel
{
    public void Init(Transform parent,int damage)
    {
        //transform.SetParent(parent);
        GetComponent<RectTransform>().localPosition = WorldV3ToCanvansV2(parent)+new Vector2(-10f,200f);
        GetComponent<RectTransform>().sizeDelta = new Vector2(222f, 111f);
        //Debug.Log(parent.localPosition);
        //Debug.Log(parent.position) ;
        GetComponent<Text>().text = "-"+damage.ToString();

        Invoke("AddForce", 0.2f);
        Invoke("HideThis", 2f);
    }

    void AddForce()
    {

        GetComponent<Rigidbody2D>().AddForce(new Vector2(1,5).normalized * 120f, ForceMode2D.Impulse);
    }
    void HideThis()
    {
        UIManager.GetInstance().HidePanel("DamageNumber");
    }



    RectTransform rectCanvas;
    Vector2 WorldV3ToCanvansV2(Transform worldV3)
    {
        rectCanvas = transform.parent.parent.GetComponent<RectTransform>();

        Vector2 canvasSize = rectCanvas.sizeDelta;
        Vector3 viewPortPos3d = Camera.main.WorldToViewportPoint(worldV3.position);
        Vector2 viewPortRelative = new Vector2(viewPortPos3d.x - 0.5f, viewPortPos3d.y - 0.5f);
        Vector2 cubeScreenPos = new Vector2(viewPortRelative.x * canvasSize.x, viewPortRelative.y * canvasSize.y);

        //Debug.LogError("ScrrenSize=" + canvasSize
        //    + ",cube.position=" + worldV3.position
        //    + ",viewPortPos3d=" + viewPortPos3d + ",screenPos=" + cubeScreenPos + ",newPos=" + viewPortRelative);


        return cubeScreenPos;
    }
}
