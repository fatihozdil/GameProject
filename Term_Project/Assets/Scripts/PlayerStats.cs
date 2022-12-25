using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public float maxHealth = 100;
    [SerializeField] public float health;
    public float speed = 0.8f;
    public float jumpHeight;
    public static string name;
    [SerializeField] private Healthbar healthbar;

    void Start()
    {
        health = maxHealth;
        healthbar.UpdateHealthBar(maxHealth,health);
        name = CreateAndJoinRooms.name;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public float getSpeed()
    {
        return this.speed;
    }
}
