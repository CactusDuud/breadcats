using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool GameOver { get; private set; } = false;
    public int Lives { get; private set; } = 100;

    public Transform towerParent;
    public GameObject towerPrefab;
    public Light2D globalLight;

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameOver)
        {
            globalLight.intensity = 0.5f;
            Application.Quit();
        }
    }

    public void ReduceLives(int amount)
    {
        Lives -= amount;
        Debug.Log($"{name}: Lost {amount} lives (now at {Lives})");
        if (Lives <= 0) GameOver = true;
    }

    public GameObject SpawnTower(Transform location)
    {
        return Instantiate(towerPrefab, location.position, location.rotation, towerParent);
    }
}
