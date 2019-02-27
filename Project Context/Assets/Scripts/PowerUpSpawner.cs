using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    public float SpawnTime = 5;

    public float Timer;

    private Vector3 SpawnArea;

    public float SpawnHeight;

    // Start is called before the first frame update
    void Start()
    {
        Timer = SpawnTime;
        objectPooler = ObjectPooler.Instance;
        SpawnArea = new Vector3(Random.Range(-12, 12), SpawnHeight, Random.Range(-15, 15));
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            SpawnArea = new Vector3(Random.Range(-12, 12), SpawnHeight, Random.Range(-15, 15));
            objectPooler.SpawnFromPool("PowerUps", SpawnArea, Quaternion.identity);
            Timer = SpawnTime;
        }
    }
}
