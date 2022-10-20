using System.Collections;
using UnityEngine;


public class SpawnSystem 
{
    private GameObject _similarObject;
    private GameObject _discreteObject;
    private GameObject _universalObject;
    private Vector3 _spawnPosition;

    public SpawnSystem(GameObject similarObject, GameObject disreteObject, GameObject universalObject, Vector3 spawnPosition)
    {
        _similarObject = similarObject;
        _discreteObject = disreteObject;
        _universalObject = universalObject;
        _spawnPosition = spawnPosition;
    }

    public void Similar()
    {
        Spawner(_similarObject);
    }

    public void Discrete()
    {
        Spawner(_discreteObject);
    }

    public void Universal()
    {
        Spawner(_universalObject);
    }

    private void Spawner(GameObject spawnObject)
    {
        GameObject newObject = GameObject.Instantiate(spawnObject, _spawnPosition, Quaternion.identity);
        EventBus.onSpawnObject?.Invoke(newObject);
    }
}
