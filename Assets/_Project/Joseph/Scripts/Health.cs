using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float _maxHealth;
    public float _currentHealth;

    public Slider healthBar;

    public bool IsABoss = false;

    public NextLevel next;

    public GameObject explosion;
    

	// Use this for initialization
	void Awake ()
    {
        _currentHealth = _maxHealth;
        next = GetComponent<NextLevel>();
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
            if (IsABoss && next != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);


                Invoke("Proceed", 5);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }


        if (healthBar != null)
        {
            healthBar.value = _currentHealth / _maxHealth;
        }
        

    }

    void Proceed()
    {
        next.Proceed();
    }



}
