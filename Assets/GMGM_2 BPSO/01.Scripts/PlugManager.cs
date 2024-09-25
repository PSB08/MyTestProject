using System.Collections.Generic;
using UnityEngine;

public class PlugManager : MonoBehaviour
{
    private Dictionary<PlugEnum, PlugBase> plugDictionary = new Dictionary<PlugEnum, PlugBase>();
    private PlugBase currentPlug;

    // Plug �߰�
    public void AddPlug(PlugEnum plugType, PlugBase plug)
    {
        if (!plugDictionary.ContainsKey(plugType))
        {
            plugDictionary.Add(plugType, plug);
        }
    }

    // Ư�� Plug ����
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

    // Plug ������Ʈ ȣ��
    private void Update()
    {
        currentPlug?.UpdatePlug(gameObject);
    }
}
