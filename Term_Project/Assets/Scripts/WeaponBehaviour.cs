using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class WeaponBehaviour : MonoBehaviour
{
    public float power;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Healthbar healthbar;

    PhotonView photonView;
    // Use this for initialization
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        Debug.Log(playerStats);
    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        // if(col.gameObject.tag == "Human")
        // {
        col.gameObject.GetComponent<PlayerStats>().health -= 10;
        healthbar.UpdateHealthBar(playerStats.maxHealth,playerStats.health);
        Debug.Log("Health " + col.gameObject.name + col.gameObject.GetComponent<PlayerStats>().health);
        //}
    }
}
