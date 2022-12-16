using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[field: SerializeField,ReadOnlyField]
    [SerializeField] private GameObject playerPrefab = default;
    [SerializeField] private GameObject enemyPrefab = default;
    [SerializeField] private GameObject bossPrefab = default;

    private GameObject player;
    private BaseWave wave;

    //Properties
    public GameObject PlayerPrefab {get => playerPrefab;}
    public GameObject EnemyPrefab {get=>enemyPrefab;}
    public GameObject BossPrefab {get=>bossPrefab;}

    private void Awake() 
    {
        wave = new StartWave(Wave.START_WAVE);
    }
    private void Update() 
    {
        LoopGame(); 
    }
    private void LoopGame()
    {
        wave = wave.RunGameWave();//RUN Wave Use State

        //State :

        //Start Wave
        //Spawn
        //If player kill all enemy in wave
        //spawn Boss
        //Player kill boss
        //next wave

        //State :
    }
   
}
 /*
    private void StartWave()
    {
        //Spawn Enemy
    }
    private void CheckPlayerKilled()
    {

    }
    private void BossWave()
    {
         //Spawn Boss
    }
    private void NextWave()
    {
        //Back To menu Scene
    }
    private void GameEnd()
    {
        //Back to Manu
    }
*/