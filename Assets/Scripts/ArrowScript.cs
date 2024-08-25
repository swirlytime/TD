using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public Enemy Target;
    public float Damage;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
            Destroy(gameObject);
        transform.LookAt(Target.transform.position);
        var direction = (Target.transform.position - transform.position).normalized;
        transform.position += direction * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Dealing damage");
            Target.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
