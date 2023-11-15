using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject unitPrefab;  // 복제해서 생성하는 프리펩
    [SerializeField]
    private int maxUnitCount;   // 생성 가능한 최대 유닛 수

    private Vector2 minSize = new Vector2(-22, -22);    // 유닛 생성 최소 위치 변수
    private Vector2 maxSize = new Vector2(22, 22);      // 유닛 생성 최대 위치 변수

    public List<UnitController> SpawnUnits()
    {
        // 생성한 유닛 정보를 반환하는 SpawnUnits()
        List<UnitController> unitList = new List<UnitController>(maxUnitCount);
        // Unitlist 변수 선언 / maxUnitCount 수 만큼 메모리 할당.

        for (int i = 0; i < maxUnitCount; ++i)
        {
            // maxUnitCount 숫자만큼 반복
            Vector3 position = new Vector3(Random.Range(minSize.x, maxSize.x), 1, Random.Range(minSize.y, maxSize.y));

            GameObject clone = Instantiate(unitPrefab, position, Quaternion.identity);  // 유닛 복제 중
            UnitController unit = clone.GetComponent<UnitController>();

            unitList.Add(unit); // 생성한 정보 저장
        }

        return unitList;    // 유닛 생성 완료하면 유닛 정보 반환
    }
}
