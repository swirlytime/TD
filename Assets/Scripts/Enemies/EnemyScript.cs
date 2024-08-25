using Assets.Scripts.Constans;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 chestPos;
    private SpawnManager spawnManager;

    public float Speed;
    public float Health;
    public float Damage;

    // Start is called before the first frame update
    void Start()
    {
        chestPos = GameObject.Find(ProjectConstants.Player).transform.position;
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var direction = new Vector3(chestPos.x - transform.position.x, 0, chestPos.z - transform.position.z).normalized;

        //Debug.Log($"Curr hp: {Health}");
        if (Health <= 0)
        {
            spawnManager.Remove(this);
            Destroy(gameObject);
            return;
        }
        if (direction.magnitude == 0)
        {
            DealDamage();
            spawnManager.Remove(this);
            Destroy(gameObject);
            return;
        }
        transform.position += direction * Speed * Time.deltaTime;
    }

    private void DealDamage()
    {
        GameManager.Instance.TakeDamage(Damage);
    }

    public virtual void TakeDamage(float damage)
    {
        Debug.Log($"Curr hp: {Health}.");
        Health -= damage;
    }
}
