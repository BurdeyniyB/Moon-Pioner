using UnityEngine;
using TMPro;

public class ChildCount : MonoBehaviour
{
    [SerializeField] private Transform parentObject; // Transform родительского объекта, чьё количество дочерних объектов будет отслеживаться
    [SerializeField] private int maxChildCount; // Максимальное количество дочерних объектов, которые допустимы
    [SerializeField] private TextMeshProUGUI textMeshPro; // Ссылка на объект TextMeshPro, используемый для отображения количества дочерних объектов
    [SerializeField] private bool SetZone; // Флаг не являеися ли обьект зоной сбора
    private int childCount; // Количество дочерних объектов

    void Update()
    {
        childCount = parentObject.childCount; // Получение текущего количества дочерних объектов родительского объекта

        textMeshPro.text = "Child count: " + childCount; // Если количество дочерних элементов находится в пределах максимального предела количества, отображать только количество дочерних элементов
        MaxChildCount();

        if(!SetZone) // Проверяем,не является ли объект зоной сбора
        {
          if(GetComponent<ChildCountSetZone>().SetCountChild() == 0) // Проверяем, нет ли дочерних объектов у зоны
          {
            textMeshPro.text = "Not enough resources"; // Если дочерних объектов нет, выводим сообщение "Not enough resources"

            MaxChildCount();
          }
        }
    }

    public int SetMaxChildCount()
    {
      return maxChildCount;
    }

    private void MaxChildCount()
    {
    if (childCount >= maxChildCount) // Проверка, превышает ли количество дочерних объектов максимально допустимое количество
     {
       textMeshPro.text = "Child count: " + childCount + "\nFull"; // Если количество дочерних элементов больше или равно максимальному количеству, отобразить сообщение «Full»
     }
    }
}
