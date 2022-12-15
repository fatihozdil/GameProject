using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    public float power;
    // Use this for initialization
    void Start () {

    }
    // Update is called once per frame
    void Update () {

    }

    void OnCollisionEnter(Collision col)
    {
      // if(col.gameObject.tag == "Human")
       // {
        col.gameObject.GetComponent<AniCons>().health -= 10;
        Debug.Log("Health " + col.gameObject.GetComponent<AniCons>().health);
        //}
    }
}
