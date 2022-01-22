using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Loading3 : BasePanel
{

    Animator animator;
    public bool ShowDone=false;
    UnityAction callback ;
    UnityAction callback2;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Init(string SceneName="testScene", UnityAction m_callback=null, UnityAction m_callback2 = null)
    {
        GetControl<Text>("Text_SceneName").text = SceneName;
        callback = () => { };
        callback2 = () => { };
        callback += m_callback;
        callback2 += m_callback2;
        
    }
    private void Update()
    {
        var info = animator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("hide") && info.normalizedTime >= 0.99f)
        {
            Debug.Log("hidethis");
            UIManager.GetInstance().HidePanel("Loading3");
            if (callback2 != null)
            {
                callback2.Invoke();
                //callback.Invoke();
                //callback = () => { };

            }

        }
        if (info.IsName("showBlack") && info.normalizedTime >= 0.99f&&!ShowDone)
        {
            ShowDone = true;

            if (callback != null)
            {
                //callback2.Invoke();
                callback.Invoke();
                //callback2 = () => { };
            }
        }
    }
    public void Hide()
    {
        animator.SetBool("hide", true);
    }
}
