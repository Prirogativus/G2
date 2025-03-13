using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DraggableObject : MonoBehaviour
{
    public Vector3 offset; // Смещение между мышью и объектом
    private Camera mainCamera;


    public float yCord = -5f;

    private void Awake()
    {
        mainCamera = Camera.main; // Получаем основную камеру
    }

    private void OnMouseDown()
    {
        // Вычисляем смещение между позицией объекта и позицией мыши
        Vector3 mousePosition = GetMouseWorldPosition();
        offset = transform.position - mousePosition;
    }

    private void OnMouseDrag()
    {
        // Обновляем позицию объекта во время перетаскивания
        Vector3 mousePosition = GetMouseWorldPosition();
        transform.position = new Vector3(mousePosition.x, yCord, mousePosition.z) + offset;

    }

    public Vector3 GetMouseWorldPosition()
    {
        // Получаем мировую позицию мыши
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = mainCamera.WorldToScreenPoint(transform.position).z; // Учитываем глубину
        return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }
}