using UnityEngine;

public class PlugAgentExample : MonoBehaviour
{
    public PlugBase currentPlug; // ���� Ȱ��ȭ�� �÷���

    void Start()
    {
        // �ʱ� �÷��� ���� (��: �ν����Ϳ��� �Ҵ�)
        currentPlug?.Execute(gameObject);
    }

    void Update()
    {
        // �÷��װ� Ȱ��ȭ�� ���� ������Ʈ �޼��� ȣ��
        currentPlug?.UpdatePlug(gameObject);
    }

    void OnDisable()
    {
        // �÷��� ���� �� Exit �޼��� ȣ��
        currentPlug?.Exit(gameObject);
    }
}
