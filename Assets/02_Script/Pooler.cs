using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    public static Pooler Instance = null; // �̱���, �� ��ũ��Ʈ���� �� �� �ʿ�
    [SerializeField] private List<GameObject> poolList = new List<GameObject>(); // �� Ǯ������ �̸� ���صδ� ����Ʈ
    private Dictionary<string, Stack<GameObject>> pools = new Dictionary<string, Stack<GameObject>>(); // Ǯ���� ���� ���� ���� ��� Ǯ���� ���⼭ ��
    private void Awake() // ����Ƽ ����������Ŭ �� ù��°
    {
        if (Instance == null) { Instance = this; } // �̱��� ���� �� ��ũ��Ʈ�� �����ؼ� ���⼭ Ǯ���� �̷����� ��

        foreach (GameObject pref in poolList)
        {
            pools.Add(pref.name, new Stack<GameObject>()); // Ǯ����Ʈ�� SerializeField�ϱ� �̸� �����Ѱ��� ��ųʸ��� ������
        }
    }
    public GameObject Spawn(GameObject prefab) // ������ �� ���� �޼��� ���� : GameObject item = Pooler.Instance.Spawn(������);
    {
        GameObject temp = null; // ����� ����
        if (pools[prefab.name].Count <= 0) // �������̸��� Ű�� �༭ ������ ���� �� ī��Ʈ�� 0���� �۰ų� ũ�� �ν�ź�ÿ���Ʈ ��
        {
            temp = Instantiate(prefab, transform); // �ν�ź�ÿ���Ʈ
            temp.name = temp.name.Replace("(Clone)", null); // �̸����� ã�Ƽ� Ǯ���ϴ°Ŵϱ� Ŭ���� ������
        }
        else // �������̸��� Ű�� �༭ ������ ���� �� ī��Ʈ�� 1 �̻�( �׷��ϱ� ���ÿ� �ϴ� ���� ��� ���� �� ���� )
        {
            temp = pools[prefab.name].Pop(); // �� ���ÿ��� ���ִ°��� �׷��� ���� ���� ����
        }
        temp.SetActive(true); // �ѱ�
        return temp; // ����� ���� ����
    }
    public void DeSpawn(GameObject prefab) // ��Ʈ������ �� ���� �޼��� ���� : Pooler.Instance.DeSpawn(������);
    {
        pools[prefab.name].Push(prefab); // �������̸��� Ű�� �༭ ������ ���ÿ� �������� �־���
        prefab.SetActive(false); // ����
    }
}
