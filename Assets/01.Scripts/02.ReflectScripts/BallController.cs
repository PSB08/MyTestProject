using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 direction;

    private void Start()
    {
        direction = Vector2.up; // 공의 초기 방향
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            // 벽돌과 충돌 시 벽돌 제거
            Destroy(collision.gameObject);

            // 벽돌과의 충돌 시 반사 벡터 계산
            Vector2 normal = collision.contacts[0].normal;
            direction = Vector2.Reflect(direction, normal);
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        else if (collision.gameObject.CompareTag("Paddle"))
        {
            // 패들과 충돌 시 공의 방향을 설정
            Vector2 normal = collision.contacts[0].normal;

            // 패들에 맞은 위치에 따라 각도 조절
            float offset = transform.position.x - collision.transform.position.x;
            direction = new Vector2(offset, 1).normalized; // 패들에 맞은 위치에 따라 방향 설정

            // 반사 방향으로 속도 업데이트
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            // 벽과 충돌 시 반사 벡터 계산
            Vector2 normal = collision.contacts[0].normal;
            direction = Vector2.Reflect(direction, normal);
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }


}
