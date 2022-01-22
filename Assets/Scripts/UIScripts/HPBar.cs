using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public float maxHp = 100;
    public float nowHp = 100;
    public Image Image_hpFollower;
    public Image Image_hp;
    // Start is called before the first frame update
    void Start()
    {
    }

    float _hpfillValue;
    protected virtual void UpdateHPBar(float newHP)
    {
        nowHp = newHP;
        _hpfillValue = nowHp / maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Image_hp.fillAmount >= _hpfillValue)
        {
            Image_hp.fillAmount -= 0.03f;
        }

        if (Image_hp.fillAmount < _hpfillValue)
        {
            Image_hp.fillAmount = _hpfillValue;
        }

        if (Image_hpFollower.fillAmount >= Image_hp.fillAmount)
        {
            Image_hpFollower.fillAmount -= 0.0025f;
        }
        if (Image_hpFollower.fillAmount < Image_hp.fillAmount)
        {
            Image_hpFollower.fillAmount = Image_hp.fillAmount;
        }
    }

}
