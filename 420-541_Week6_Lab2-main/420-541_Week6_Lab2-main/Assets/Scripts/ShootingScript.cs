using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject particleSystemPrefab;
    public Transform target;

    private void Start()
    {
        // Find the Turret game object in the scene and get its Transform component
        target = GameObject.Find("Turret").transform;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
            Instantiate(particleSystemPrefab, transform.position, transform.rotation);
            if (Physics.Raycast(ray, out hit))
            {

                
                TurretComponent turretComponent = target.GetComponent<TurretComponent>();
                turretComponent.TakeDamage(10);
            }
        }
    }
}


