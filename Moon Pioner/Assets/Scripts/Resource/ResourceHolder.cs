using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHolder : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    private void OnTriggerEnter(Collider other)
    {
      // Объявляем метод, который будет вызываться при срабатывании триггера входа
      if (other.CompareTag("Resource1") || other.CompareTag("Resource2") || other.CompareTag("Resource3"))
     {
      // Вызываем метод MoveResource и передаем начальную позицию, конечною, и ложь для интега объекта
        other.gameObject.GetComponent<ResourceMovement>().MoveResource(other.gameObject, inventory, false);
     }
    }
}
