using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    Material[] _mats;
    Material _mat;
    Renderer _renderer;
    int _point;
    [SerializeField] AudioSource _pickUp;
    [SerializeField] Text _pointText;
    [SerializeField] int _winPointTarget = 10;
    void Recolor()
    {
        var renderer = GetComponent<Renderer>();
        var length = _mats.Length;
        //renderer.material = _mats[random.range(0, length - 1)];
        var mat = _mats[Random.Range(0, length - 1)];
        _mat = mat;
        renderer.material = mat;
    }

    void UpdateText()
    {
        _pointText.text = "Point: " + _point;
    }

    void Start()
    {
        _point = 0;
        UpdateText();
        var spawner = GameObject.Find("Spawner");
        _mats = spawner.GetComponent<CubeSpawner>().GetMaterial();
        Recolor();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Cube"))
        {
            if(collision.gameObject.GetComponent<Collectible>().GetCurrentMaterial() != _mat)
            {
                GetComponent<PlayerLife>().Die();
            }
            else
            {
                AddPoint();
            
            }
        }
    }


    void AddPoint()
    {
        Recolor();
        _point++;
        GetComponent<PlayerMovement>().BoostSpeed(_point/3);
        UpdateText();
        _pickUp.Play();
        WinCheck();
    }

    void WinCheck()
    {
        if(_point >= _winPointTarget)
        {
             GetComponent<PlayerLife>().Win();
        }
    }
}
