using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    [SerializeField]
    private RectTransform dragRectangle;            // ���콺�� �巡���� ������ ����ȭ�ϴ� Image UI�� RectTransform

    private Rect dragRect;              // ���콺�� �巡�� �� ���� (xMin~xMax, yMin~yMax)
    private Vector2 start = Vector2.zero;   // �巡�� ���� ��ġ
    private Vector2 end = Vector2.zero;     // �巡�� ���� ��ġ

    private Camera mainCamera;
    private RTSUnitController rtsUnitController;

    private void Awake()
    {
        mainCamera = Camera.main;
        rtsUnitController = GetComponent<RTSUnitController>();

        // start, end�� (0, 0)�� ���·� �̹����� ũ�⸦ (0, 0)���� ������ ȭ�鿡 ������ �ʵ��� ��
        DrawDragRectangle();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            start = Input.mousePosition;    // ���콺 ��ġ���� ����
            dragRect = new Rect();  // �޸� �Ҵ��س���
        }

        if (Input.GetMouseButton(0))
        {
            end = Input.mousePosition;  // ��ư�� ������ ������ end ������ ���� ���콺 ��ġ���� ����

            // ���콺�� Ŭ���� ���·� �巡�� �ϴ� ����(start���� end����) �巡�� ������ �̹����� ǥ��
            DrawDragRectangle();
        }

        if (Input.GetMouseButtonUp(0))
        {
            // ���콺 Ŭ���� ������ �� �巡�� ���� ���� �ִ� ���� ����
            CalculateDragRect();    // ȭ��� �巡�� ���� ����
            SelectUnits();  // �巡�� ���� ���Ե� ���� ���� ó��

            // ���콺 Ŭ���� ������ �� �巡�� ������ ������ �ʵ���
            // start, end ��ġ�� (0, 0)���� �����ϰ� �巡�� ������ �׸���
            start = end = Vector2.zero;
            DrawDragRectangle();
        }
    }

    private void DrawDragRectangle()
    {
        // �巡�� ������ ��Ÿ���� Image UI�� ��ġ
        dragRectangle.position = (start + end) * 0.5f;
        // �巡�� ������ ��Ÿ���� Image UI�� ũ��
        dragRectangle.sizeDelta = new Vector2(Mathf.Abs(start.x - end.x), Mathf.Abs(start.y - end.y));
    }

    private void CalculateDragRect()
    {
        if (Input.mousePosition.x < start.x)
        {
            dragRect.xMin = Input.mousePosition.x;
            dragRect.xMax = start.x;
        }
        else
        {
            dragRect.xMin = start.x;
            dragRect.xMax = Input.mousePosition.x;
        }

        if (Input.mousePosition.y < start.y)
        {
            dragRect.yMin = Input.mousePosition.y;
            dragRect.yMax = start.y;
        }
        else
        {
            dragRect.yMin = start.y;
            dragRect.yMax = Input.mousePosition.y;
        }
    }

    private void SelectUnits()
    {
        // ��� ������ �˻�
        foreach (UnitController unit in rtsUnitController.UnitList)
        {
            // ������ ���� ��ǥ�� ȭ�� ��ǥ�� ��ȯ�� �巡�� ���� ���� �ִ��� �˻�
            if (dragRect.Contains(mainCamera.WorldToScreenPoint(unit.transform.position)))
            {
                rtsUnitController.DragSelectUnit(unit);
            }
        }
    }
}
