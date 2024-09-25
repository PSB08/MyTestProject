using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private Vector3[] points;

    public Vector3[] Points => points;

    public Vector3 CurrentPos => _currentPos;

    //게임 오브젝트 transform 변경 시 기즈모도 같이 움직이게 하기
    private Vector3 _currentPos;
    private bool _isGameStart = false;

    private void Start()
    {
        _currentPos = transform.position;
        _isGameStart = true;
    }

    //기즈모 그리기
    private void OnDrawGizmos()
    {

        if (!_isGameStart && transform.hasChanged)
        {
            _currentPos = transform.position;
        }
        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(points[i] + _currentPos, 0.5f);

            if (i < points.Length - 1)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(points[i] + _currentPos, points[i + 1] + _currentPos);
            }
        }
    }

    public Vector3 GetWaypointPosition(int index)
    {
        return points[index] + _currentPos;
    }
}
