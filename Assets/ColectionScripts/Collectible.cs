using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    Material _mat;
    //bool _scheduleDelay = false;
    //float _delay = 0;
    public void setMaterial(Material material)
    {
        var renderer = GetComponent<Renderer>();
        renderer.material = material;
        _mat = material;
    }

    public Material GetCurrentMaterial()
    {
        //var renderer = GetComponent<Renderer>();
        //return renderer.material;
        return _mat;
    }

    Vector2 _rangeX, _rangeY, _rangeZ;

    public void setRange(Vector2 rangeX, Vector2 rangeY, Vector2 rangeZ)
    {
        _rangeX = rangeX;
        //_rangeY = rangeY;
        var renderer = GetComponent<Renderer>();
        _rangeY = new Vector2(renderer.bounds.size.y*1.5f, renderer.bounds.size.y*1.5f);
        _rangeZ = rangeZ;
    }
    void Start()
    {
        Respawn();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Despawn();
            //Invoke(nameof(Respawn), 1.0f);
            //RespawnAction(1.0f);
            Respawn(1.0f);
        }
        // If the collision layer is wall
        else if( collision.gameObject.layer == 7)
        {
            Respawn();
        }
        //else if(collision.gameObject.CompareTag(this.gameObject.tag))
        //{
        //    Respawn();
        //    print("LMAO");
        //}
    }

    void Despawn()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }


    void Respawn()
    {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        float xRange = Random.Range(_rangeX.x, _rangeX.y);
        float y = Random.Range(_rangeY.x, _rangeY.y); 
        float zRange = Random.Range(_rangeZ.x, _rangeZ.y); 
        transform.position = new Vector3(xRange, y, zRange);
    }

    void Respawn(float delay)
    {
        Despawn();
        Invoke(nameof(Respawn), delay);
    }

    void RespawnAction(float delay)
    {
        Despawn();
        //_scheduleDelay = true;
        //_delay = delay;
    }
    //private void Update()
    //{
    //    if(_scheduleDelay)
    //    {
    //        float timer = 0;
    //        timer += Time.deltaTime;
    //        if(timer > _delay)
    //        {
    //            Respawn();
    //            _scheduleDelay = false;
    //        }
    //    }
    //}

}
