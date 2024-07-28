using Assets.Scripts;
using Assets.Scripts.Enums;
using Assets.Scripts.Models;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject tower;
    public int startX;
    public int startZ;

    private Cord _currentPos;
    private LayoutScript _layoutScript;

    public PlayerScript()
    {
        _currentPos = new(startX, startZ);
    }

    // Start is called before the first frame update
    void Start()
    {
        _layoutScript = GameObject.Find("Plane").GetComponent<LayoutScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            MoveUp();
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            MoveDown();
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            MoveLeft();
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            MoveRight();
        else if (Input.GetKeyDown(KeyCode.Space))
            CreateTower();
    }

    public Cord GetCurrentPos() => _currentPos;

    private void MoveUp()
    {
        transform.Translate(Vector3.forward);
        _currentPos.Z++;
    }

    private void MoveDown()
    {
        transform.Translate(Vector3.back);
        _currentPos.Z--;
    }

    private void MoveRight()
    {
        transform.Translate(Vector3.right);
        _currentPos.X++;
    }

    private void MoveLeft()
    {
        transform.Translate(Vector3.left);
        _currentPos.X--;
    }

    private void CreateTower()
    {
        var newPos = new Vector3(transform.position.x, tower.transform.position.y, transform.position.z);
        Instantiate(tower, newPos, tower.transform.rotation);
        _layoutScript.Add(Tile.Tower, _currentPos);
        Debug.Log($"Spawned tower at {newPos}");
        Debug.Log($"Current pos: ({_currentPos.X},{_currentPos.Z})");
    }
}
