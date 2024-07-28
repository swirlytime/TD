using Assets.Scripts;
using Assets.Scripts.Constans;
using Assets.Scripts.Enums;
using Assets.Scripts.Models;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int minDistance;
    public int maxDistance;
    public GameObject portal;
    public GameObject enemy;

    private float startDelay = 5.0f;
    private float nextDelay = 1.2f;
    private LayoutScript _layoutScript;
    private readonly List<GameObject> EnemyList = new();

    // Start is called before the first frame update
    public void Start()
    {
        _layoutScript = GameObject.Find("Plane").GetComponent<LayoutScript>();

        PositionSemiRandom();
        Instantiate(portal, transform.position, portal.transform.rotation); // need to add randomnes to rotation
        Invoke(nameof(KeepSpawningEnemies), startDelay);
    }

    public List<GameObject> GetEnemies() => EnemyList;

    // Update is called once per frame
    public void Update()
    {
        
    }

    private void PositionSemiRandom()
    {
        var xDist = Random.Range(minDistance, maxDistance + 1);
        var zDist = Random.Range(minDistance, maxDistance + 1);
        var xCord = Random.Range(0, 2) == 0 ?
            0 + xDist :
            0 - xDist;
        var zCord = Random.Range(0, 2) == 0 ?
            0 + zDist :
            0 - zDist;

        transform.position = new Vector3(xCord, portal.transform.position.y, zCord);
        _layoutScript.Add(Tile.Portal, new Cord(xCord, zCord));
    }

    private void KeepSpawningEnemies()
    {
        var newEnemy = Instantiate(enemy, transform.position, enemy.transform.rotation);
        EnemyList.Add(newEnemy);
        Invoke(nameof(KeepSpawningEnemies), nextDelay);
    }
}
