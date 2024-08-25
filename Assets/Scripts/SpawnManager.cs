using Assets.Scripts;
using Assets.Scripts.Constans;
using Assets.Scripts.Enums;
using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SpawnManager : MonoBehaviour
{
    public int minDistance;
    public int maxDistance;
    public GameObject portal;
    public List<Wave> waves;

    private LayoutScript _layoutScript;
    private readonly List<Enemy> EnemyList = new();

    // Start is called before the first frame update
    public void Start()
    {
        _layoutScript = GameObject.Find("Plane").GetComponent<LayoutScript>();
        StartCoroutine(SpawnWaves());
    }

    public List<Enemy> GetEnemies() => EnemyList;

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void Remove(Enemy enemy)
    {
        EnemyList.Remove(enemy);
    }

    private (int, float, int) GetSemiRandomPosition()
    {
        var xDist = Random.Range(minDistance, maxDistance + 1);
        var zDist = Random.Range(minDistance, maxDistance + 1);
        var xCord = Random.Range(0, 2) == 0 ?
            0 + xDist :
            0 - xDist;
        var zCord = Random.Range(0, 2) == 0 ?
            0 + zDist :
            0 - zDist;

        return (xCord, portal.transform.position.y, zCord);
    }

    private IEnumerator SpawnWaves()
    {
        foreach(var wave in waves)
        {
            yield return new WaitForSeconds(wave.InitialDelay);
            KeepSpawningEnemies(wave);
        }
    }

    private void KeepSpawningEnemies(Wave wave)
    {
        var randompos = GetSemiRandomPosition();
        var portalPos = new Vector3(randompos.Item1, randompos.Item2, randompos.Item3);

        _layoutScript.Add(Tile.Portal, new Cord(randompos.Item1, randompos.Item3));
        Instantiate(portal, portalPos, portal.transform.rotation);

        var delay = 0f;
        foreach(var enemy in wave.EnemyList)
        {
            delay += wave.SpawnDelay;
            StartCoroutine(SpawnEnemy(enemy, portalPos, delay));
        }
    }

    private IEnumerator SpawnEnemy(Enemy enemy, Vector3 position, float delay)
    {
        yield return new WaitForSeconds(delay);
        var newEnemy = Instantiate(enemy, position, enemy.transform.rotation);
        EnemyList.Add(newEnemy);
    }
}
