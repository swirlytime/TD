using System.Collections;
using System.Linq;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public float range;
    public GameObject arrow;
    public float Damage;
    public float ReloadTime;

    private Component cone;
    private SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        StartCoroutine(WaitAndShoot());
    }

    private IEnumerator WaitAndShoot()
    {
        while (!GameManager.Instance.isDead)
        {
            var closest = GetClosest();
            if (closest != null && (closest.transform.position - transform.position).magnitude <= range)
                Shoot(closest);

            yield return new WaitForSeconds(ReloadTime);
        }
    }

    private Enemy GetClosest()
    {
        var enemies = spawnManager.GetEnemies();
        var ordered = enemies.OrderBy(e => (e.transform.position - transform.position).magnitude);
        var closest = ordered.FirstOrDefault();

        return closest;
    }

    private void Shoot(Enemy target)
    {
        Debug.Log("Shooting");
        var newArrow = Instantiate(arrow, transform.position, transform.rotation);
        var script = newArrow.GetComponent<ArrowScript>();
        script.Target = target;
        script.Damage = Damage;
    }
}
