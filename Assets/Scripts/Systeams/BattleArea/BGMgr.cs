using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMgr : MonoBehaviour
{
    //public Image _far;
    //public Image _mid;
    //public Image _ground;

    public GameObject far;
    public GameObject mid;
    public GameObject ground;

    public static BGMgr instance;
    public bool BGCanMove=false;
    public float BGMoveSpeed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        EventCenter.GetInstance().AddEventListener(EventDic.BGMoveAbleChange, BGMoveAbleChange);
    }

    void BGMoveAbleChange()
    {
        BGCanMove = !BGCanMove;
    }
    // Update is called once per frame
    void Update()
    {
        if (BGCanMove)
        {
            BGmove();
        }
    }

    public void BGmove()
    {
        far.transform.position -= new Vector3(BGMoveSpeed * 0.1f, 0, 0);
        mid.transform.position -= new Vector3(BGMoveSpeed * 0.5f, 0, 0);
        ground.transform.position -= new Vector3(BGMoveSpeed, 0, 0);
    }
}
