using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    static BombSpawner instance;

    public static BombSpawner Instance {
        get { if (instance == null) instance = FindObjectOfType<BombSpawner>(); return instance;}
    }

    [SerializeField] List<Transform> spawnPositions = new List<Transform>();
    [SerializeField] ObjectPooler bombPool = null;

    [SerializeField] float spawnFrequency = 0.25f;
    Transform LastSpawnPos = null;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBombCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBomb(){
        Transform SpawnPos = null;
        do
        {
            SpawnPos = spawnPositions[Random.Range(0, spawnPositions.Count)];
        } while (SpawnPos == LastSpawnPos);

        bombPool.GetObjectFromPool(SpawnPos.position, Quaternion.identity);
        LastSpawnPos = SpawnPos;
    }

    IEnumerator SpawnBombCoroutine(){
        while (true)
        {
            SpawnBomb();
            yield return new WaitForSeconds(spawnFrequency);
        }
    }

    public void ReturnBombToBombPool(Bomb bomb){
        bombPool.AddObjectToPool(bomb.gameObject);
    }
}
