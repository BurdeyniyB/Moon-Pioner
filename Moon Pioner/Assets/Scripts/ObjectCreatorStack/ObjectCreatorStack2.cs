using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreatorStack2 : MonoBehaviour
{
    public GameObject objectPrefab; // префаб создаваемого объекта
    public GameObject parentObjectStack1; // объект-родитель для полученых объектов
    public GameObject parentObjectStack2; // объект-родитель для созданных объектов
    public float creationInterval = 1.0f; // интервал между созданием объектов
    public int maxObjects = 10; // максимальное количество создаваемых объектов
    public List<GameObject> childObjectsStack1; // список дочерних объектов которые уничтожыем
    public List<GameObject> childObjectsStack2; // список дочерних объектов которые создаем
    private bool isSpawning = true; // флаг, указывающий, нужно ли продолжать спавнить объекты

    void Start()
    {
        InvokeRepeating("CreateObject", 0, creationInterval); // запускаем создание объектов с интервалом
    }

    void CreateObject()
    {
        FillingLists();

        if (childObjectsStack1.Count <= 0) // если количество объектов стало равно 0, прекращаем спавнить объекты
        {
           isSpawning = false;
        }
        else
        {
           isSpawning = true;
        }

        if (isSpawning && childObjectsStack1.Count != 0 && childObjectsStack2.Count < maxObjects) // если достигли максимального количества объектов
        {
            GameObject lastObject = childObjectsStack1[childObjectsStack1.Count - 1]; // получаем последний объект из списка
            childObjectsStack1.RemoveAt(childObjectsStack1.Count - 1); // удаляем последний объект из списка
            Destroy(lastObject); // уничтожаем объект

            GameObject newObject = Instantiate(objectPrefab, parentObjectStack2.transform.position, Quaternion.identity); // создаем новый объект
            newObject.transform.SetParent(parentObjectStack2.transform); // Делаем объект дочерним
        }
    }

    private void FillingLists()
    {
        childObjectsStack1 = new List<GameObject>();
        childObjectsStack2 = new List<GameObject>();

        foreach (Transform child in parentObjectStack1.transform)
        {
           childObjectsStack1.Add(child.gameObject);
        }

        foreach (Transform child in parentObjectStack2.transform)
        {
           childObjectsStack2.Add(child.gameObject);
        }
    }
}
