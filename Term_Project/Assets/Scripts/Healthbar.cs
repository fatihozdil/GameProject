using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Healthbar : MonoBehaviour
{   
    private Camera cam;
    [SerializeField] private Image healthbar;
    [SerializeField] private TMP_Text playerName;

    void Start(){
        cam = Camera.main;
        playerName.text = PlayerStats.name;
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth){
        healthbar.fillAmount = currentHealth / maxHealth;
    }

    void Update(){
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);    
    }
}