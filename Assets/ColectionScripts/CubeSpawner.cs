using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] int num;
    [SerializeField] Material[] mats;
    GameObject level;
    List<GameObject> cubes;
    public Material[] GetMaterial()
    {
        return mats;
    }

    void Start()
    {
        //cube = GameObject.Find("Sphere");     
        level = GameObject.Find("Level");
        var floor = level.transform.Find("Floor");
        var fr = floor.gameObject.GetComponent<Renderer>();
        var size = fr.bounds.size;
        Vector2 xRange = new Vector2(floor.transform.position.x - size.x/2, floor.transform.position.x + size.x/2);
        Vector2 yRange = new Vector2(1, 1);
        Vector2 zRange = new Vector2(floor.transform.position.z - size.z/2, floor.transform.position.z + size.z/2);
        cube.AddComponent<Collectible>();
        cubes = new List<GameObject>(); 
        for(int i = 0; i < num; i ++)
        {
            cubes.Add(Instantiate(cube));
            var collect = cubes[i].GetComponent<Collectible>();
            collect.setMaterial(mats[i]);
            collect.setRange(xRange, yRange, zRange);
        }
    }
}
