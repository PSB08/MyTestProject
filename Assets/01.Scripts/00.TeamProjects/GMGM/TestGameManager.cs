using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestGameManager : MonoBehaviour
{
    private Dictionary<Type, IPlugComponent> components; //Dictionary ����

    private void Awake()
    {
        components = new Dictionary<Type, IPlugComponent>(); //Dictionary �ʱ�ȭ

        SetCompo();
    }

    private void SetCompo()
    {
        GetComponentsInChildren<IPlugComponent>().ToList().ForEach(x => components.Add(x.GetType(), x)); // ����� ��¥ ����.
        //�ڽĿ��� IPlugCompo ����?�ѳ� �� ��������, �߰�
        components.Values.ToList().ForEach(compo => compo.Initialize(this)); //Dictionary�� Initialize ȣ��
    }

    public T GetCompo<T>(bool isDerived = false) where T : IPlugComponent //���׸� Ÿ�� T�� �ش��ϴ� ���� ��ȯ
    {
        Type t = typeof(T);

        if (components.TryGetValue(t, out IPlugComponent compo)) //Ÿ�Կ� �ش��ϴ� �� ã��
        {
            return (T)compo;  //������ T�� ��������
        }
        if (isDerived)
        {
            Type type = components.Keys.FirstOrDefault(t => t.IsSubclassOf(typeof(T))); //components�� keys�� �� ���鼭 �޼ҵ� ����
            //FirstOrDefault > ���ǿ� �´� ��� ��ȯ ������ �⺻��
            //IsSubclassOf > ���� Ŭ�������� �� �� ��������
            if (type != null)  //type�� ���� �ƴϸ� 
                return (T)components[type];  //���׸� T�� ��ȯ�� components�� type���� ������
        }

        return default; //������ default > �⺻������ ��ȯ�ϱ�
    }
}
