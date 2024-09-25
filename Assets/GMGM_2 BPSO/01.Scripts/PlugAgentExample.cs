using UnityEngine;

public class PlugAgentExample : MonoBehaviour
{
    public PlugBase currentPlug; // 현재 활성화된 플러그

    void Start()
    {
        // 초기 플러그 설정 (예: 인스펙터에서 할당)
        currentPlug?.Execute(gameObject);
    }

    void Update()
    {
        // 플러그가 활성화된 동안 업데이트 메서드 호출
        currentPlug?.UpdatePlug(gameObject);
    }

    void OnDisable()
    {
        // 플러그 종료 시 Exit 메서드 호출
        currentPlug?.Exit(gameObject);
    }
}
