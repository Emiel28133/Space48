using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 500;
    // Start is called before the first frame update

    private Movement movement;

    void Start()
    {
        movement = gameObject.AddComponent<Movement>();
        movement.moveSpeed = 20f; // Stel de snelheid van de laser in
        movement.useInput = false; // Laser gebruikt geen input
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
    }
}
