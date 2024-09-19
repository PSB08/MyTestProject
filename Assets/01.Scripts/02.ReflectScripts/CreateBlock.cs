using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{
    public GameObject blockPrefab; // �� ������
    public int numberOfBlocks = 10; // ������ ���� ��
    public float spawnAreaWidth = 10f; // ���� ������ �ʺ�
    public float spawnAreaHeight = 5f; // ���� ������ ����
    public float blockWidth = 1f; // ���� �ʺ� (Collider2D�� ũ��� ��ġ�ؾ� ��)
    public float blockHeight = 0.5f; // ���� ���� (Collider2D�� ũ��� ��ġ�ؾ� ��)

    private void Start()
    {
        SpawnBlocks();
    }

    private void SpawnBlocks()
    {
        int blocksSpawned = 0;

        while (blocksSpawned < numberOfBlocks)
        {
            // ������ ��ġ ����
            Vector2 spawnPosition = new Vector2(
                Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2),
                Random.Range(-spawnAreaHeight / 2, spawnAreaHeight / 2)
            );

            // ���� ��ġ���� Ȯ��
            if (!IsPositionOccupied(spawnPosition))
            {
                // �� ����
                Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
                blocksSpawned++;
            }
        }
    }

    private bool IsPositionOccupied(Vector2 position)
    {
        // �־��� ��ġ�� Collider2D�� �ִ��� Ȯ��
        Collider2D[] colliders = Physics2D.OverlapBoxAll(position, new Vector2(blockWidth, blockHeight), 0);
        return colliders.Length > 0;
    }
}
