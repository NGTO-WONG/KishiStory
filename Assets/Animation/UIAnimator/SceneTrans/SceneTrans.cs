using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrans : BasePanel
{
    public void HideOver()
    {
        UIManager.GetInstance().HidePanel("SceneTrans");
        Destroy(gameObject);
    }
}
