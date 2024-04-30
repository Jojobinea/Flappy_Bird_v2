using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private AudioSource _point;

    void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            ScoreCounter.instance.UpdateScore();
            _point.Play();
        }
    }
}
