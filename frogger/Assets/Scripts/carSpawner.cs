using Random = UnityEngine.Random;
using UnityEngine;

public class carSpawner : MonoBehaviour
{
    public GameObject car;
    public Transform[] SpwanPoints;
    public float countDownSpawnTimer = 3f;
    int[] laneCounter;
    int numSpawns = 0;
    // Start is called before the first frame update
    void Start()
    {
        laneCounter = new int[SpwanPoints.Length];
        for (int i = 0; i < SpwanPoints.Length; i++)
        {
            laneCounter[i] = 1;
        }  
    }

    // Update is called once per frame
    void Update()
    {
        if (countDownSpawnTimer <= 0f){
            SpawnCar();
            countDownSpawnTimer = 2f;
        }
        else {
            countDownSpawnTimer -= Time.deltaTime;
        }
    }

    void SpawnCar()
    {
        int randomIndex = Random.Range(0, SpwanPoints.Length);
        if (numSpawns < SpwanPoints.Length)
        {
            while (laneCounter[randomIndex] == 0)
            {
                randomIndex = Random.Range(0, SpwanPoints.Length);
            }
            laneCounter[randomIndex] = 0;
        }
        
        Transform spawnPoint = SpwanPoints[randomIndex];
        Instantiate(car, spawnPoint.position, spawnPoint.rotation);
        
        numSpawns++;
    }

}
