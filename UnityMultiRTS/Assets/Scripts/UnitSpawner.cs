using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject unitPrefab;  // �����ؼ� �����ϴ� ������
    [SerializeField]
    private int maxUnitCount;   // ���� ������ �ִ� ���� ��

    private Vector2 minSize = new Vector2(-22, -22);    // ���� ���� �ּ� ��ġ ����
    private Vector2 maxSize = new Vector2(22, 22);      // ���� ���� �ִ� ��ġ ����

    public List<UnitController> SpawnUnits()
    {
        // ������ ���� ������ ��ȯ�ϴ� SpawnUnits()
        List<UnitController> unitList = new List<UnitController>(maxUnitCount);
        // Unitlist ���� ���� / maxUnitCount �� ��ŭ �޸� �Ҵ�.

        for (int i = 0; i < maxUnitCount; ++i)
        {
            // maxUnitCount ���ڸ�ŭ �ݺ�
            Vector3 position = new Vector3(Random.Range(minSize.x, maxSize.x), 1, Random.Range(minSize.y, maxSize.y));

            GameObject clone = Instantiate(unitPrefab, position, Quaternion.identity);  // ���� ���� ��
            UnitController unit = clone.GetComponent<UnitController>();

            unitList.Add(unit); // ������ ���� ����
        }

        return unitList;    // ���� ���� �Ϸ��ϸ� ���� ���� ��ȯ
    }
}
