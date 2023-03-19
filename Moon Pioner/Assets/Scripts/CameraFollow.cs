using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance; // Статический экземпляр синглтона для скрипта CameraFollow

    [SerializeField] private Transform target; // Цель, за которой следует камера
    [SerializeField] private Vector3 offset; // Смещение между камерой и целью

    void Awake () {
        if (instance == null) // Проверяем, существует ли уже экземпляр синглтона
            instance = this; // Если не существует, устанавливаем его на текущий экземпляр
    }

    void Update()
    {
        if(target != null){ // Проверяем, не является ли цель null и включена ли тряска камеры
            transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, target.position.z + offset.z); // Обновляем позицию камеры на основе позиции цели и смещения
        }
    }
}