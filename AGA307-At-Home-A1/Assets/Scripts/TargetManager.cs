using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType
{
    T1,
    T2,
    T3
}
public class TargetManager : Singleton<TargetManager>
{
    public GameObject[] targetTypes;
    public Transform[] spawnPoints;

    public List<GameObject> targets;
    public GameObject target;

    void SpawnEnemies()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int rnd = Random.Range(0, targetTypes.Length);
            GameObject enemy = Instantiate(targetTypes[rnd], spawnPoints[i].position, spawnPoints[i].rotation);
        }
        targets.Add(target);
        ShowEnemyCount();
       
    }

    public void SpawnAtRandom()
    {
        int rnd = Random.Range(0, targetTypes.Length);
        Instantiate(targetTypes[rnd], spawnPoints[rnd].position, spawnPoints[rnd].rotation);
        targets.Add(target);
        ShowEnemyCount();
        
    }

    void ShowEnemyCount()
    {
        _UI.UpdateTargetCount(targets.Count);
    }

    public void KillTarget(GameObject _target)
    {
        if (targets.Count == 0)
            return;

        Destroy(_target);
        targets.Remove(_target);
        ShowEnemyCount();
    }

    public Transform GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
}
