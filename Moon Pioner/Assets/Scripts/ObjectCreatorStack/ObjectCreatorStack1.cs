using UnityEngine;

public class ObjectCreatorStack1 : MonoBehaviour
{
    [SerializeField] private GameObject spawnObject; // префаб создаваемого объекта
    [SerializeField] private float spawnDelay; // задержка между созданием объектов
    [SerializeField] private int maxSpawnCount; // максимальное количество создаваемых объектов
    [SerializeField] private Transform spawnZone; // зона, в которой будет создаваться объект

    private int currentSpawnCount; // текущее количество созданных объектов
    private bool spawnAllowed = true; // флаг, разрешающий создание объектов

    private void Start()
    {
        InvokeRepeating("SpawnObject", spawnDelay, spawnDelay); // создаем объекты с заданной задержкой
    }

    private void Update()
    {
     if(!spawnAllowed && spawnZone.childCount < maxSpawnCount) //проверяем если спавн прекращен количество дочерних объектов
     {
       ResumeSpawn();
     }
    }

    private void SpawnObject()
    {
        if (!spawnAllowed) return; // если спавн не разрешен, выходим из функции

        if (currentSpawnCount >= maxSpawnCount)
        {
            spawnAllowed = false; // останавливаем спавн объектов
            return;
        }

        GameObject newObject = Instantiate(spawnObject, GetRandomPosition(), Quaternion.identity); // создаем новый объект
        newObject.transform.SetParent(spawnZone); // Делаем объект дочерним

        currentSpawnCount = spawnZone.childCount;
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(spawnZone.position.x - spawnZone.localScale.x / 2, spawnZone.position.x + spawnZone.localScale.x / 2);
        float y = Random.Range(spawnZone.position.y - spawnZone.localScale.y / 2, spawnZone.position.y + spawnZone.localScale.y / 2);
        float z = Random.Range(spawnZone.position.z - spawnZone.localScale.z / 2, spawnZone.position.z + spawnZone.localScale.z / 2);

        return new Vector3(x, y, z);
    }

    // функция для возобновления спавна объектов
    public void ResumeSpawn()
    {
        currentSpawnCount = spawnZone.childCount;
        spawnAllowed = true;
    }
}
