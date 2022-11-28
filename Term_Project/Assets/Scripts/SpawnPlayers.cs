using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    

    
    // Start is called before the first frame update
    void Start()
    {
        //float randomX = Random.Range(minX, maxX);
        //float randomZ = Random.Range(minZ, maxZ);
        PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(0, 40, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
