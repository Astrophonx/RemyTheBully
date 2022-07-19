using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{


    [SerializeField] private int maxPlayers = 10;
    [SerializeField] private GameObject[] models;
    [SerializeField] private Transform respawnPoints;
    [SerializeField] private float RespawnTreshold = 12.0f;

    [SerializeField] private int aliveNPC = 0;
    [SerializeField] private GameObject NPCContainer;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckIfNeedToRespawnNPC", 0.0f, RespawnTreshold);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfNeedToRespawnNPC();
    }

    void CheckIfNeedToRespawnNPC(){

        if(aliveNPC < maxPlayers ){
            int needToRespawn = maxPlayers - aliveNPC;
            Debug.Log("NPC need to spawn"+ needToRespawn);

            for(int i = 1; i < needToRespawn; i++){
                RandomSpawnPlayer();
            }
            aliveNPC += needToRespawn;
        }
    }
    
    void RandomSpawnPlayer(){
        
        var randomRespawnPointIndex = Random.Range(0, respawnPoints.childCount);
        var randomModelIndex = Random.Range(0, models.Length);
        GameObject NpcToSpawn = Instantiate(models[randomModelIndex], respawnPoints.GetChild(randomRespawnPointIndex));

        NpcToSpawn.transform.parent = NPCContainer.transform;
        Debug.Log("Respawn random player to random respawn point");
    }
}
