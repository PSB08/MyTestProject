using Unity.VisualScripting;
using UnityEngine;

public abstract class PlugBase : ScriptableObject
{
    // Plug ���� �� ȣ��Ǵ� �޼���
    public virtual void Execute(GameObject owner)
    {
        Debug.Log($"Entering {this.GetType().Name} Plug");
    }

    // Plug�� Ȱ��ȭ�� ���� ȣ��Ǵ� �޼���
    public virtual void UpdatePlug(GameObject owner) { }

    // Plug�� ����� �� ȣ��Ǵ� �޼���
    public virtual void Exit(GameObject owner)
    {
        Debug.Log($"Exiting {this.GetType().Name} Plug");
    }
}
