using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public float speed;
    public float jumpHeight;
    public static string name; 



    void Start()
    {
        Debug.Log(name);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
