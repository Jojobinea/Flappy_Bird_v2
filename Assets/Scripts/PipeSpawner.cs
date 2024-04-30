using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime;
    [SerializeField] private float _heightRange;
    [SerializeField] private GameObject _pipes;

    private float _timer = 0;

    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        if(_timer > _maxTime)
        {
            _timer = 0;
            SpawnPipe();
        }
        
        _timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));

        GameObject pipe = Instantiate(_pipes, spawnPos, Quaternion.identity);


        Destroy(pipe, 10f);
    }
}
