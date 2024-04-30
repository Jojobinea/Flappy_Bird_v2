using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    [SerializeField] private float _velocity;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private AudioSource _wingAudioSource;
    [SerializeField] private AudioSource _dieAudiosource;
    
    private Rigidbody2D _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            _rb.velocity = Vector2.up * _velocity;
            if(Time.timeScale > 0)
                _wingAudioSource.Play();
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _dieAudiosource.Play();
        GameController.instance.GameOver();
    }
}
