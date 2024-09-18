using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadelController : MonoBehaviour
{
    public float speed = 10f;

    private void Update()
    {
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * move * speed * Time.deltaTime);
    }
}
