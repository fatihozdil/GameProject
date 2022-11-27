using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform player;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
    }
}
