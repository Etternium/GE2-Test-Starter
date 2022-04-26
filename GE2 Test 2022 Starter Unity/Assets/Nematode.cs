using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nematode : MonoBehaviour
{
    public int length = 5;

    public Material material;

    void Awake()
    {
        length = Random.Range(5, 21);

        for (int i = 0; i < length; i++)
        {
            float h = 1f / length * i;
            float a = (i * i) - (length * i);

            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            MeshRenderer renderer = sphere.GetComponent<MeshRenderer>();

            if(i <= 0)
            {
                sphere.AddComponent<Boid>();
                sphere.AddComponent<ObstacleAvoidance>();
                sphere.AddComponent<Constrain>();
                sphere.AddComponent<NoiseWander>();
            }

            sphere.transform.SetParent(transform);
            sphere.transform.localPosition = new Vector3(0f, 0f, i);
            sphere.transform.localScale += new Vector3(a * 0.1f, a * 0.1f, 0f);

            renderer.material.color = Color.HSVToRGB(h, 1f, 1f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
