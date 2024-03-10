using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;
        [Range(0f, 1f)]
        public float spawnChance;
    }

    public SpawnableObject[] objects;

    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;
    public float minSpawnHeight = 0f;
    public float maxSpawnHeight = 5f; 

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        float spawnChance = Random.value;
        float spawnHeight = Random.Range(minSpawnHeight, maxSpawnHeight);

        foreach (var obj in objects)
        {
            if (spawnChance < obj.spawnChance)
            {
                GameObject spawnedObject = Instantiate(obj.prefab);
                spawnedObject.transform.position = new Vector3(transform.position.x, spawnHeight, transform.position.z);
                break;
            }

            spawnChance -= obj.spawnChance;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }
}

