using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject CMFreeLookPrefab;
    public GameObject MainCameraPrefab;


    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    Vector3 targetPosition = new Vector3(0, 37.6f, 0);

    private Quaternion _lookRotation;
    private Vector3 _direction;


    // Start is called before the first frame update
    void Start()
    {
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        Vector3 randomPosition = new Vector3(randomX, 40f, randomZ);
        // find the vector pointing from our position to the target
        _direction = (targetPosition - randomPosition).normalized;
        Debug.Log(_direction);
        //create the rotation we need to be in to look at the target
        _lookRotation = Quaternion.LookRotation(_direction);
        _lookRotation.eulerAngles = new Vector3(0, _lookRotation.eulerAngles.y, 0);

        //playerPrefab.transform.LookAt(targetPosition);
        Vector3 newPosition = new Vector3(0, 40f, 0);
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, _lookRotation, 0);
        //PhotonNetwork.Instantiate(CMFreeLookPrefab.name, newPosition, _lookRotation, 0);
        //PhotonNetwork.Instantiate(MainCameraPrefab.name, newPosition, _lookRotation, 0);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
