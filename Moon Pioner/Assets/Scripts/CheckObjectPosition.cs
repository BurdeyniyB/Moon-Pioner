using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObjectPosition : MonoBehaviour
{
    [SerializeField] private GameObject objectToCheck; // объект, находящийся в рамках которого нужно проверять позицию
    [SerializeField] private string Tag; // тег, по которому определяются объекты, которые нужно перемещать
    [SerializeField] private List<GameObject> childObjectsList; // список объектов, находящихся внутри объекта для проверки

    private void Update()
    {
        if (objectToCheck != null)
        {
            // получаем позиции объектов на осях x и z
            float x1 = transform.position.x;
            float z1 = transform.position.z;
            float x2 = objectToCheck.transform.position.x;
            float z2 = objectToCheck.transform.position.z;

            // проверяем, находится ли объект в рамках другого объекта по осям x и z
            if (x2 >= x1 - transform.localScale.x  && x2 <= x1 + transform.localScale.x  &&
                z2 >= z1 - transform.localScale.z  && z2 <= z1 + transform.localScale.z )
            {
                // создаем список объектов, находящихся внутри объекта для проверки
                childObjectsList = new List<GameObject>();
                foreach (Transform child in objectToCheck.transform)
                {
                    childObjectsList.Add(child.gameObject);
                }

                // вызываем отложенное действие через 2 секунды
                StartCoroutine(DelayedAction());
            }
        }
    }

    IEnumerator DelayedAction()
    {
        for (int i = 0; i < childObjectsList.Count; i++)
        {
            if (i < childObjectsList.Count)
            {
                GameObject go = childObjectsList[i];
                ResourceMovement resourceMovement = null;

                if (go != null && go.CompareTag(Tag))
                {
                    resourceMovement = go.GetComponent<ResourceMovement>();
                    yield return new WaitForSeconds(0.1f * (i + 1)); // добавляем задержку

                    if (resourceMovement != null) // проверяем, что скрипт ResourceMovement существует
                    {
                        resourceMovement.MoveResource(go, this.gameObject, true);
                    }
                }
            }
        }
    }
}
