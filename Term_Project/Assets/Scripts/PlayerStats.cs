using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health;
    private float speed=0.8f;
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
    public void setSpeed(float speed){
        this.speed=speed;
    }
    public float getSpeed(){
        return this.speed;
    }
}
