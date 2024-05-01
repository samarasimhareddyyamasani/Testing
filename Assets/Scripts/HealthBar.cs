using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public float maxHealth = 100;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value != health)
        {
            slider.value = Mathf.Lerp(slider.value, health, Time.deltaTime * 3f);
        }
    }

    void takeDamage(float damage)
    {
        health -= damage;
    }
}
