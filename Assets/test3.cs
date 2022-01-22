using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test3 : MonoBehaviour
{
    public Transform a;
    public Transform b;
    public EnemyInfo enemyInfo;
    public GameObject _obj;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //enemyInfo = new EnemyInfo()
        //{
        //    obj = this._obj,
        //    animator = _obj.GetComponent<Animator>(),

        //};

        animationInfo = _obj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
    }
    AnimatorStateInfo animationInfo;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animationInfo = _obj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
            //动画的状态信息
            //当前动画状态所在的层
            //animationInfo.
            //Sequence quence = DOTween.Sequence();
            //Tweener tweener = a.DOMove(b.position, 1f);
            //Tweener tweener2 = a.DOMove(a.position, 1f);
            //tweener.onComplete += () => { Debug.Log("nmsl"); };
            //tweener2.onComplete += () => { tweener.PlayBackwards(); };
            //quence.Append(tweener);
            //quence.AppendInterval(1);
            //quence.Append(tweener2);
            _obj.GetComponent<Animator>().Play("death");
            //animationInfo = enemyInfo.animator.GetCurrentAnimatorStateInfo(0);
            if ((animationInfo.normalizedTime > 0.99f) && (animationInfo.IsName("death")))
            {
                Debug.Log("aaaa");
            }
        }
        Debug.Log(_obj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("death"));
        Debug.Log(animationInfo.IsName("death"));
        if ((_obj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f) && (_obj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("death")))
        {
            Debug.Log("aaaa");
        }
    }
}
