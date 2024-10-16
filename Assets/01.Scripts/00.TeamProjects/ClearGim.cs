using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ClearGim : MonoBehaviour
{
    public UnityEvent isClear;

    public void ClearMethod()
    {
        SceneManager.LoadScene("Stage3");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerCollider")
        {
            isClear?.Invoke();
        }
    }

}
