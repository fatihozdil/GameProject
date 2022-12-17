using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] public float health;
    public float speed;
    public float jumpHeight;
    public static string name; 
    [SerializeField] private Healthbar healthbar;

    void Start()
    {
        Debug.Log(name);
        healthbar.UpdateHealthBar(maxHealth,health);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
