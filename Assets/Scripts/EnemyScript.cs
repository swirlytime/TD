using Assets.Scripts.Constans;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Vector3 chestPos;
    public float speed;

    private 

    // Start is called before the first frame update
    void Start()
    {
        chestPos = GameObject.Find(ProjectConstants.Player).transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var direction = new Vector3(chestPos.x - transform.position.x, 0, chestPos.z - transform.position.z).normalized;
        if (direction.magnitude == 0)
        {
            Destroy(gameObject);
        }
        transform.position += direction * speed * Time.deltaTime;
    }
}
