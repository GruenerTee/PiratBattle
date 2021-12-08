using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBarScript : MonoBehaviour
{
    public Slider _healthBar;

    public void SetHealtBar(int health)
    {
        _healthBar.value = health;
    }
    public void SetMaxHealth(int maxHealth)
    {
        _healthBar.maxValue = maxHealth;
        _healthBar.value = maxHealth;
    }
}
