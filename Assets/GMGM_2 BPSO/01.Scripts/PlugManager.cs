using System.Collections.Generic;
using UnityEngine;

public class PlugManager : MonoBehaviour
{
    private Dictionary<PlugEnum, PlugBase> plugDictionary = new Dictionary<PlugEnum, PlugBase>();
    private PlugBase currentPlug;

    // Plug 추가
    public void AddPlug(PlugEnum plugType, PlugBase plug)
    {
        if (!plugDictionary.ContainsKey(plugType))
        {
            plugDictionary.Add(plugType, plug);
        }
    }

    // 특정 Plug 실행
    public void SetPlugActive(PlugEnum plugType)
    {
        if (plugDictionary.ContainsKey(plugType))
        {
            if (currentPlug != null)
            {
                currentPlug.Exit(gameObject);
            }

            currentPlug = plugDictionary[plugType];
            currentPlug.Execute(gameObject);
        }
    }

    // Plug 업데이트 호출
    private void Update()
    {
        currentPlug?.UpdatePlug(gameObject);
    }
}
