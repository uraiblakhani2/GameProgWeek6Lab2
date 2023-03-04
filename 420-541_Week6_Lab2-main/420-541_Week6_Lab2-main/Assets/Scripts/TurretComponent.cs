using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretComponent : MonoBehaviour
{
    public float maxAngle = 45;
    public Transform target;
    public float rotationSpeed = 5f;
    private Quaternion originalRotation;
    public Image healthbar;


    public int maxHealth = 100;
    private int curHealth;


    // Start is called before the first frame update


    
    


    void Start()
    {
        originalRotation = transform.rotation;
        curHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToTarget = target.position - transform.position;
        float angleToTarget = Mathf.Acos(Vector3.Dot(transform.forward, directionToTarget.normalized)) * Mathf.Rad2Deg;

        if (angleToTarget <= maxAngle)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, rotationSpeed * Time.deltaTime);
        }
    }

    // Method to decrease the turret's health
    
     public void TakeDamage(int damage)
    {   
        
         if (curHealth <= 0)
        {
           Destroy(gameObject);
        }
        
        curHealth -= damage;
        healthbar.fillAmount = ((float)curHealth / (float)maxHealth);
        
       

    }

   
}
