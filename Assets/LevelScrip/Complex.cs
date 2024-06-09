using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Complex : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool _isHarder = false;
    [SerializeField] float _maxSpeed = 70;
    [SerializeField] float _boostTimer = 3.0f;
    float _timer;
    Stats stats;
    public bool IsComplex()
    {
        return _isHarder;
    }
    void Start()
    {
        _timer = 0;
        stats = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_isHarder)
        {
            _timer += Time.deltaTime;
            if(_timer >= _boostTimer)
            {
                _timer -= 1.0f;
                stats.AddSpeed(1.0f, _maxSpeed);
            }
        }
    }
}
