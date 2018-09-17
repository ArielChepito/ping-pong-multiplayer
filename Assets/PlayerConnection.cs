using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class PlayerConnection : NetworkBehaviour
{
    private NetworkStartPosition[] spawnPoints;

    // Use this for initialization
    void Start() {

        
           
        
        if (!isLocalPlayer) {
            return;
        }

        spawnPoints = FindObjectsOfType<NetworkStartPosition>();

        //spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        // Instantiate(PlayerUnitPrefab);
        CmdSpawnMyUnit();


    }
    void OnPlayerNameChanged(string newName)
    {
        Debug.Log("Old name: " + PlayerName + " new name: " + newName);
        PlayerName = newName;
       
        gameObject.name = "PlayerConnectionObject[" + newName + "]";
    }

    public GameObject PlayerUnitPrefab;

    [SyncVar(hook = "OnPlayerNameChanged")]
    public string PlayerName = "Anonymous";

    

    // Update is called once per frame
    void Update() {

        if (!isLocalPlayer)
            return;




        if (Input.GetKeyDown(KeyCode.R))
        {
            CmdSpawnMyUnit();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            string n = "Fox" + Random.Range(1, 100);
            CmdChangePlayerName(n);

        }
    }


   

    /// Commands unciones que solo se ejecutanen el servidor
    [Command]
    void CmdSpawnMyUnit()
    {
        

        
        Vector3 spawnPoint = new Vector3(9,1,0);
       
        // If there is a spawn point array and the array is not empty, pick one at random
        if (spawnPoints != null && spawnPoints.Length > 0)
        {
            Debug.Log("x");
            spawnPoint = new Vector3(-9, 1, 0);
        }
        GameObject go = Instantiate(PlayerUnitPrefab);

        // Set the player’s position to the chosen spawn point


        go.transform.position = spawnPoint;
        
       

        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
    }

    [Command]
    void CmdChangePlayerName(string name)
    {
        PlayerName = name;
        ///RpcChangePlayerName(PlayerName);
    }

    ////Comandos que se ejecutan solo en los clientes
    //[ClientRpc]

    //void RpcChangePlayerName(string n )
    //{
    //    PlayerName = n;

    //}
}
