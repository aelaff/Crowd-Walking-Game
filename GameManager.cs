using System.Collections;
using System.Collections.Generic;
using EnimiesFactory;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public Transform followerOBJ;
    [SerializeField]
    public List<GameObject> allEnemies;
    public List<GameObject> fallenBompList, roadObstacleList,humansList;
    public bool isPlayerRunning = false;
    public List<Transform> humanPositions;
    public int humanCount = 10;

    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        fallenBompList = new List<GameObject>();
        roadObstacleList = new List<GameObject>();
        
        /*
        for (int i = 0; i < humanCount; i++)
        {
            Enemy fb = EnemyFactory.IntiateEnemy("Human");
            fb.Intiate();
        }*/
        
    }
    

    private void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.A))
            {
            Enemy fb = EnemyFactory.IntiateEnemy("FallenBomp");
            fb.Intiate();

        }
    }
}
