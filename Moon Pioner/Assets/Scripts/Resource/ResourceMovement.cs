using UnityEngine;

public class ResourceMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f; // Скорость перемещения

    private GameObject startMarker; // Начальный объект перемещения
    private GameObject endMarker; // Конечный объект перемещения
    private float startTime; // Время начала перемещения
    private float journeyLength; // Длина пути

    private bool isMoving = false; // Флаг, указывающий, что ресурс находится в движении

    private void Update()
    {
        // Если ресурс находится в движении
        if (isMoving)
        {
            // Вычисляем пройденное расстояние
            float distCovered = (Time.time - startTime) * speed;

            // Вычисляем прогресс перемещения (от 0 до 1)
            float journeyProgress = distCovered / journeyLength;

            // Вычисляем новую позицию ресурса с помощью линейной интерполяции
            Vector3 newPosition = Vector3.Lerp(startMarker.transform.position, endMarker.transform.position, journeyProgress);

            // Перемещаем ресурс в новую позицию
            transform.position = newPosition;

            // Если ресурс достиг конечной точки перемещения
            if (journeyProgress >= 1f)
            {
                // Сбрасываем флаг в false, указывая, что ресурс больше не находится в движении
                isMoving = false;

                // Очищаем начальный и конечный объекты перемещения
                startMarker = null;
                endMarker = null;
            }
        }
    }

    // Перемещение ресурса от одной точки к другой
    public void MoveResource(GameObject start, GameObject end, bool Untagged)
    {
        if(end.transform.childCount >= end.GetComponent<ChildCount>().SetMaxChildCount())
        {
          return;
        }

        if(Untagged)
        {
          this.gameObject.tag = "Untagged"; // удаляем тег, чтобы не было дополнительных перемещений
        }

        // Запоминаем начальную и конечную точки перемещения
        startMarker = start;
        endMarker = end;

        // Делаем объект дочерним
        transform.parent = endMarker.transform;

        // Вычисляем длину пути
        journeyLength = Vector3.Distance(startMarker.transform.position, endMarker.transform.position);

        // Запоминаем время начала перемещения
        startTime = Time.time;

        // Устанавливаем флаг в true, указывая, что ресурс находится в движении
        isMoving = true;
    }
}
