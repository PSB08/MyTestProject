using Unity.VisualScripting;
using UnityEngine;

public abstract class PlugBase : ScriptableObject
{
    // Plug 실행 시 호출되는 메서드
    public virtual void Execute(GameObject owner)
    {
        Debug.Log($"Entering {this.GetType().Name} Plug");
    }

    // Plug가 활성화된 동안 호출되는 메서드
    public virtual void UpdatePlug(GameObject owner) { }

    // Plug가 종료될 때 호출되는 메서드
    public virtual void Exit(GameObject owner)
    {
        Debug.Log($"Exiting {this.GetType().Name} Plug");
    }
}
