using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public int health;  // This will track the health

    // Method to set max health and initialize the health bar
    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth; // Set max value of slider
        slider.value = maxHealth;    // Set current value of slider to maxHealth
        health = maxHealth;          // Update internal health value to maxHealth
    }

    // Method to update the current health
    public void setHealth(int currentHealth)
    {
        slider.value = currentHealth;  // Update the slider's value
        health = currentHealth;        // Update the internal health value
        Debug.Log("HealthBar updated: " + health);  // Log the updated health
    }

    // Method to get the current health
    public int getHealth()
    {
        return health;  // Return the current health
    }
}
