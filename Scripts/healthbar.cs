using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//  we programmed this whole file!!!!!!!!

public class healthbar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public int maxHealth = 100;
    public int currentHealth; 
    private healthbar hb;

    void Start(){
        currentHealth = 100;
    }

    public void setMaxHealth(int health){
        slider.maxValue = health;
        slider.value = health;
    }
    public void setHealth(int health){
        slider.value = health;
    }
    public void TakeDamage(int damage){
        currentHealth = currentHealth - damage;
        setHealth(currentHealth);
    }
    public void AddHealth(int bonus){
        currentHealth = currentHealth + bonus;
        setHealth(currentHealth);
    }
}
