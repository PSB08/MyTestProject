using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectObject : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 direction;

    void Start()
    {
        // �ʱ� ���� ����
        direction = new Vector2 (1, -0.2f);
    }

    void Update()
    {
        // ��ü �̵�
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹 �� �ݻ� ���� ���
        Vector2 normal = collision.contacts[0].normal;
        direction = Vector2.Reflect(direction, normal);
    }
}
