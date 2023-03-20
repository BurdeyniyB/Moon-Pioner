using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCountSetZone : MonoBehaviour
{
    [SerializeField] private Transform[] parentObject; // Массив родительских объектов, чье количество дочерних объектов будет отслеживаться
    private int count;  // Количество дочерних объектов

    // Метод для установки количества дочерних объектов родительского объекта
    public int SetCountChild()
    {
        count = parentObject[0].childCount; // Устанавливаем количество дочерних объектов первого родительского объекта в массиве
        foreach(Transform go in parentObject) // Перебираем все родительские объекты в массиве
        {
            if(go.childCount < count) // Если количество дочерних объектов текущего родительского объекта меньше, чем установленное ранее
            {
                count = go.childCount; // Обновляем количество дочерних объектов
            }
        }
        return count; // Возвращаем текущее количество дочерних объектов родительского объекта
    }
}
