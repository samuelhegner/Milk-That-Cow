using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkSpawner : MonoBehaviour
{
    public GameObject particlePrefab;
    public static List<GameObject> particleList;


    public Material particleMaterial;
    public Color fillColor = new Color(220f, 217f, 205f);
    public Color outlineColor = new Color(220f, 217f, 205f);


    [Range(0f, 1f)] public float delayBetweenParticles = 0.05f;
    [Range(0f, 100f)] public float particleLifeTime = 5.0f;
    [Range(0f, 2f)] public float size = 0.45f;
    public Vector2 initalVelocity = new Vector2(0.0f, -4.0f);

    public int maxParticleCount;
    public int burstCount;
    //public string teamTag;
    //public KeyCode DebugKeyCode;
    //public Transform pos;
    void Awake()
    {
        particleList = new List<GameObject>();
        SetMaterialColor(fillColor, outlineColor);
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(DebugKeyCode))
    //    {
    //        SetMaterialColor(fillColor, outlineColor);
    //        SpawnBurst(pos, teamTag);
    //    }
    //}

    public void SpawnBurst(Transform spawnPos, string playerTag)
    {
        StartCoroutine(SpawnRoutine(spawnPos, playerTag));
    }
    public void SetMaterialColor(Color fill, Color stroke)
    {
        particleMaterial.SetColor("_Color", fill);
        particleMaterial.SetColor("_StrokeColor", stroke);
    }

    private IEnumerator SpawnRoutine(Transform spawnPos, string playerTag)
    {
        int count = burstCount;

        for (int i = 0; i < burstCount; i++)
        {
            var particle = Instantiate(particlePrefab, spawnPos.position, Quaternion.identity);
            particle.transform.SetParent(this.transform);
            particle.transform.localScale = new Vector3(size, size, 1f);
            particle.tag = playerTag;
            particleList.Add(particle);


            var metaBall = particle.GetComponent<MetaballParticleClass>();
            metaBall.LifeTime = particleLifeTime;
            metaBall.Active = true;
            metaBall.witinTarget = false;


            var rigidbody = particle.GetComponent<Rigidbody2D>();
            rigidbody.velocity = initalVelocity;



            yield return new WaitForSeconds(delayBetweenParticles);
        }
    }
}
