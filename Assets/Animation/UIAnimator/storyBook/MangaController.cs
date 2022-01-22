using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MangaController : MonoBehaviour
{
    public Button MangaPage;
    int page = 1;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextManga()
    {
        try
        {
            animator.Play(page.ToString());
            
        }
        catch
        {
            Debug.Log("none");
        }
        page++;

    }




    public void SoundClick()
    {
        Debug.Log("aaa0");
        MusicMgr.GetInstance().PlaySound("Click", false);
    }
    public void SoundPageChange()
    {

        MusicMgr.GetInstance().PlaySound("PageChange", false,(s)=> 
        {
            s.time = 1f;
        });
    }
}
