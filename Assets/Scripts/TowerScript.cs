using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class TowerScript : MonoBehaviour
{
    public float range;
    public GameObject arrow;

    private Component cone;
    private SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Add delay
        var enemies = spawnManager.GetEnemies();
        var ordered = enemies.OrderBy(e => (e.transform.position - transform.position).magnitude);
        var closest = ordered.FirstOrDefault();

        if (closest != null && (closest.transform.position - transform.position).magnitude <= range)
            Shoot(closest);
    }

    private void Shoot(GameObject target)
    {
        var newArrow = Instantiate(arrow, transform.position, transform.rotation);
        newArrow.GetComponent<ArrowScript>().Target = target;
    }
}
