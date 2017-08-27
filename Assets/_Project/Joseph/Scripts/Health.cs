using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float _maxHealth;
    public float _currentHealth;

    public Slider healthBar;
    

	// Use this for initialization
	void Awake ()
    {
        _currentHealth = _maxHealth;
	}
	
	public void DamageHealth(float n)
    {
        _currentHealth -= n;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        else if (_currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }

        healthBar.value = _currentHealth / _maxHealth;

    }



}
