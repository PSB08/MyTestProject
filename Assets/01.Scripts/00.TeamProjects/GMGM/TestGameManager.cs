using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestGameManager : MonoBehaviour
{
    private Dictionary<Type, IPlugComponent> components; //Dictionary 선언

    private void Awake()
    {
        components = new Dictionary<Type, IPlugComponent>(); //Dictionary 초기화

        SetCompo();
    }

    private void SetCompo()
    {
        GetComponentsInChildren<IPlugComponent>().ToList().ForEach(x => components.Add(x.GetType(), x)); // 비용이 진짜 높아.
        //자식에서 IPlugCompo 구현?한놈 다 가져오기, 추가
        components.Values.ToList().ForEach(compo => compo.Initialize(this)); //Dictionary에 Initialize 호출
    }

    public T GetCompo<T>(bool isDerived = false) where T : IPlugComponent //제네릭 타입 T에 해당하는 컴포 반환
    {
        Type t = typeof(T);

        if (components.TryGetValue(t, out IPlugComponent compo)) //타입에 해당하는 놈 찾기
        {
            return (T)compo;  //있으면 T로 가져오기
        }
        if (isDerived)
        {
            Type type = components.Keys.FirstOrDefault(t => t.IsSubclassOf(typeof(T))); //components에 keys를 다 돌면서 메소드 실행
            //FirstOrDefault > 조건에 맞는 요소 반환 없으면 기본값
            //IsSubclassOf > 하위 클래스까지 싹 다 가져오기
            if (type != null)  //type이 널이 아니면 
                return (T)components[type];  //제네릭 T로 변환한 components에 type들을 리턴함
        }

        return default; //없으면 default > 기본값으로 반환하기
    }
}
