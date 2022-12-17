using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{   
    private Camera cam;
    [SerializeField] private Image healthbar;

    void Start(){
        cam = Camera.main;
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth){
        healthbar.fillAmount = currentHealth / maxHealth;
    }

    void Update(){
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);    
    }
}
