using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLocation : MonoBehaviour
{
  public GameObject prefab; // префаб объекта, который мы будем располагать
  public GameObject Player; // префаб объекта, который мы будем располагать
  public List<GameObject> objects; // список объектов, которые мы будем располагать
  public int columns; // количество столбцов
  public int rows; // количество строк
  public float spacing = 1.0f; // расстояние между объектами

  private void Update()
  {
      // Вычисляем ширину и высоту, которые нужно выделить под объекты
      float width = columns * prefab.transform.localScale.x * spacing;
      float height = rows * prefab.transform.localScale.y * spacing;

      // Вычисляем позицию центра
      Vector3 centerPosition = transform.position;

      // Очищаем список объектов
      objects.Clear();

      // Получаем все дочерние объекты нашего объекта
      foreach (Transform child in transform)
      {
          // Добавляем дочерний объект в список
          objects.Add(child.gameObject);
      }

      // Проходим по всем объектам из списка
      for (int i = 0; i < objects.Count; i++)
      {
          // Измениям ротацию объекта на ротацию Player
          objects[i].transform.rotation = Player.transform.rotation;

          // Вычисляем индекс столбца и строки
          int column = i % columns;
          int row = i / columns;

          // Вычисляем позицию объекта
          Vector3 position = centerPosition + new Vector3(0, row * prefab.transform.localScale.y * spacing + 0.5f, (column-1) * prefab.transform.localScale.z * spacing);

          // Устанавливаем позицию объекта
          objects[i].transform.position = position;
      }
  }
}