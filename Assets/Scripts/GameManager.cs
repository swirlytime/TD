using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float health;

    [SerializeField]
    public bool isDead = false;

    public static GameManager Instance { get; private set; }


    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameOver();
        }

    }

    private void GameOver()
    {
        isDead = true;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
