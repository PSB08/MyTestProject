using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 direction;

    private void Start()
    {
        direction = Vector2.up; // ���� �ʱ� ����
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            // ������ �浹 �� ���� ����
            Destroy(collision.gameObject);

            // �������� �浹 �� �ݻ� ���� ���
            Vector2 normal = collision.contacts[0].normal;
            direction = Vector2.Reflect(direction, normal);
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        else if (collision.gameObject.CompareTag("Paddle"))
        {
            // �е�� �浹 �� ���� ������ ����
            Vector2 normal = collision.contacts[0].normal;

            // �е鿡 ���� ��ġ�� ���� ���� ����
            float offset = transform.position.x - collision.transform.position.x;
            direction = new Vector2(offset, 1).normalized; // �е鿡 ���� ��ġ�� ���� ���� ����

            // �ݻ� �������� �ӵ� ������Ʈ
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            // ���� �浹 �� �ݻ� ���� ���
            Vector2 normal = collision.contacts[0].normal;
            direction = Vector2.Reflect(direction, normal);
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }


}
