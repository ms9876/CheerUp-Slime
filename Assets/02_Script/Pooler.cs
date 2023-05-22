using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    public static Pooler Instance = null; // 싱글톤, 딴 스크립트에서 쓸 떄 필요
    [SerializeField] private List<GameObject> poolList = new List<GameObject>(); // 뭘 풀링할지 미리 정해두는 리스트
    private Dictionary<string, Stack<GameObject>> pools = new Dictionary<string, Stack<GameObject>>(); // 풀링의 뼈대 같은 느낌 모든 풀링은 여기서 함
    private void Awake() // 유니티 라이프사이클 맨 첫번째
    {
        if (Instance == null) { Instance = this; } // 싱글톤 지정 이 스크립트로 지정해서 여기서 풀링이 이뤄지게 함

        foreach (GameObject pref in poolList)
        {
            pools.Add(pref.name, new Stack<GameObject>()); // 풀리스트가 SerializeField니까 미리 세팅한것을 딕셔너리에 세팅함
        }
    }
    public GameObject Spawn(GameObject prefab) // 스폰할 떄 쓰는 메서드 사용법 : GameObject item = Pooler.Instance.Spawn(프리팹);
    {
        GameObject temp = null; // 저장용 변수
        if (pools[prefab.name].Count <= 0) // 프리팹이름을 키로 줘서 나오는 스택 의 카운트가 0보다 작거나 크면 인스탄시에이트 함
        {
            temp = Instantiate(prefab, transform); // 인스탄시에이트
            temp.name = temp.name.Replace("(Clone)", null); // 이름으로 찾아서 풀링하는거니까 클론을 지워줌
        }
        else // 프리팹이름을 키로 줘서 나오는 스택 의 카운트가 1 이상( 그러니까 스택에 일단 뭔가 들어 있을 때 재사용 )
        {
            temp = pools[prefab.name].Pop(); // 그 스택에서 빼주는거임 그래서 빼준 놈을 저장
        }
        temp.SetActive(true); // 켜기
        return temp; // 저장된 값을 리턴
    }
    public void DeSpawn(GameObject prefab) // 디스트로이할 떄 쓰는 메서드 사용법 : Pooler.Instance.DeSpawn(없엘꺼);
    {
        pools[prefab.name].Push(prefab); // 프리팹이름을 키로 줘서 나오는 스택에 없엘꺼를 넣어줌
        prefab.SetActive(false); // 끄기
    }
}
