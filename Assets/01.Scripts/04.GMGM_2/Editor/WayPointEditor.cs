using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WayPoint))]
public class WayPointEditor : Editor
{
    WayPoint _wayPoint => target as WayPoint;

    private void OnSceneGUI()
    {
        EditorGUI.BeginChangeCheck();

        for (int i = 0; i < _wayPoint.Points.Length; i++)
        {
            Handles.color = Color.blue;
            //핸들 위치 지정
            Vector3 currentWaypoint = _wayPoint.Points[i] + _wayPoint.CurrentPos;
            //핸들 생성
            Vector3 newWayPoint = Handles.FreeMoveHandle(currentWaypoint, 0.7f, new Vector3(0.3f, 0.3f, 0.3f), Handles.SphereHandleCap);

            GUIStyle gui = new GUIStyle();
            gui.fontStyle = FontStyle.Bold;
            gui.fontSize = 16;
            gui.normal.textColor = Color.yellow;

            //텍스트 위치
            Vector3 textPosition = Vector3.down * 0.35f + Vector3.right * 0.35f;
            Handles.Label(_wayPoint.Points[i] + _wayPoint.CurrentPos + textPosition, $"{i + 1}", gui);

            EditorGUI.EndChangeCheck();

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Free Move Handle");
                _wayPoint.Points[i] = newWayPoint - _wayPoint.CurrentPos;
            }
        }

    }
}
