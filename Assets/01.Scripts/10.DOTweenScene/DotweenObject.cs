using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class DotweenObject : MonoBehaviour
{
    [SerializeField] private Transform trans;
    [SerializeField] private Transform trans2;

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        //StartDoTween();
        StartCoroutine(MoveDoObject());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.transform.position = Vector2.zero;
            sprite.color = Color.white;
            //StartDoTween();
            StartCoroutine(MoveDoObject());
        }
    }

    private void StartDoTween()
    {
        sprite.DOColor(Color.yellow, 2);

        #region SetLoops

        transform.DOMove(trans.position, 2f).SetLoops(1, LoopType.Yoyo);
        transform.DOMove(trans2.position, 2f).SetLoops(1, LoopType.Yoyo);
        //transform.DOMove(trans.position, 2f).SetLoops(2, LoopType.Restart);
        //transform.DOMove(trans.position, 2f).SetLoops(2, LoopType.Incremental);

        #endregion

        #region SetEase

        /*transform.DOMove(trans.position, 2f).SetEase(Ease.Linear);
        transform.DOMove(trans.position, 2f).SetEase(Ease.Flash);
        transform.DOMove(trans.position, 2f).SetEase(Ease.Unset);*/

        /*transform.DOMove(trans.position, 2f).SetEase(Ease.InBack);
        transform.DOMove(trans.position, 2f).SetEase(Ease.InBounce);
        transform.DOMove(trans.position, 2f).SetEase(Ease.InCirc);
        transform.DOMove(trans.position, 2f).SetEase(Ease.InCubic);
        transform.DOMove(trans.position, 2f).SetEase(Ease.InElastic);
        transform.DOMove(trans.position, 2f).SetEase(Ease.InExpo);
        transform.DOMove(trans.position, 2f).SetEase(Ease.InFlash);
        transform.DOMove(trans.position, 2f).SetEase(Ease.InQuad);
        transform.DOMove(trans.position, 2f).SetEase(Ease.InQuart);
        transform.DOMove(trans.position, 2f).SetEase(Ease.InQuint);
        transform.DOMove(trans.position, 2f).SetEase(Ease.InSine);*/

        /*transform.DOMove(trans.position, 2f).SetEase(Ease.InOutBack);
        transform.DOMove(trans.position, 2f).SetEase(Ease.InOutBounce);
        transform.DOMove(trans.position, 2f).SetEase(Ease.InOutCirc);
        transform.DOMove(trans.position, 2f).SetEase(Ease.InOutCubic);
        transform.DOMove(trans.position, 2f).SetEase(Ease.InOutElastic);
        transform.DOMove(trans.position, 2f).SetEase(Ease.InOutExpo);
        transform.DOMove(trans.position, 2f).SetEase(Ease.InOutFlash);
        transform.DOMove(trans.position, 2f).SetEase(Ease.InOutQuad);
        transform.DOMove(trans.position, 2f).SetEase(Ease.InOutQuart);
        transform.DOMove(trans.position, 2f).SetEase(Ease.InOutQuint);
        transform.DOMove(trans.position, 2f).SetEase(Ease.InOutSine);*/

        /*transform.DOMove(trans.position, 2f).SetEase(Ease.INTERNAL_Custom);
        transform.DOMove(trans.position, 2f).SetEase(Ease.INTERNAL_Zero);*/

        /*transform.DOMove(trans.position, 2f).SetEase(Ease.OutBack);
        transform.DOMove(trans.position, 2f).SetEase(Ease.OutBounce);
        transform.DOMove(trans.position, 2f).SetEase(Ease.OutCirc);
        transform.DOMove(trans.position, 2f).SetEase(Ease.OutCubic);
        transform.DOMove(trans.position, 2f).SetEase(Ease.OutElastic);
        transform.DOMove(trans.position, 2f).SetEase(Ease.OutExpo);
        transform.DOMove(trans.position, 2f).SetEase(Ease.OutFlash);
        transform.DOMove(trans.position, 2f).SetEase(Ease.OutQuad);
        transform.DOMove(trans.position, 2f).SetEase(Ease.OutQuart);
        transform.DOMove(trans.position, 2f).SetEase(Ease.OutQuint);
        transform.DOMove(trans.position, 2f).SetEase(Ease.OutSine);*/

        #endregion

       
    }

    private IEnumerator MoveDoObject()
    {
        transform.DOMove(trans.position, 2f).SetLoops(2, LoopType.Yoyo);
        yield return new WaitForSeconds(3f);
        transform.DOMove(trans2.position, 2f).SetLoops(2, LoopType.Yoyo);
        yield return new WaitForSeconds(3f);
        transform.DOMove(new Vector3(0, 0, 0), 2f);
    }

}
