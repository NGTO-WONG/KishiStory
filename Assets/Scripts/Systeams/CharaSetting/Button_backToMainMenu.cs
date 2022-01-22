using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_backToMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneLoadSvc.GetInstance().LoadSceneWithFX("MainMenu", null);
            UIManager.GetInstance().HidePanel("Panel_LevelFailed");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
