using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidSpawner : MonoBehaviour
{
    public GameObject particlePrefab;
    private List<GameObject> particleList;
    

    public Material particleMaterial;
    public Color fillColor = new Color(220f, 217f, 205f);
    public Color strokeColor = new Color(4 / 255f, 156 / 255f, 1f);


    [Range(0f, 1f)] public float delayBetweenParticles = 0.05f;
    [Range(0f, 100f)] public float particleLifeTime = 5f;
    [Range(0f, 2f)] public float size = 0.45f;
    public Vector2 initSpeed = new Vector2(1f, -1.8f);
    void Awake()
    {
        particleList = new List<GameObject>();
    }


    public int maxParticleCount;


    void Start()
    {
        //particlePrefab.transform.SetParent(this.transform);
        //particlePrefab.transform.localScale = new Vector3(size, size, 1f);
        //particlePrefab.GetComponent<MetaballParticleClass>().Active = false;



        for (int i = 1; i < maxParticleCount; i++)
        {
            var particle = Instantiate(particlePrefab, gameObject.transform.position, Quaternion.identity);
            var metaBall = particle.GetComponent<MetaballParticleClass>();
            metaBall.Active = false;


            particle.transform.SetParent(this.transform);
            particle.transform.localScale = new Vector3(size, size, 1f);

            particleList.Add(particle);
        }


    }

    //IEnumerator loop(Vector3 _pos, Vector2 _initSpeed, int count = -1, float delay = 0f, bool waitBetweenDropSpawn = true)
    //{
    //    yield return new WaitForSeconds(delay);

    //    _breakLoop = false;

    //    IsWaterInScene = true;

    //    int auxCount = 0;
    //    while (true)
    //    {
    //        for (int i = 0; i < particleList.Count; i++)
    //        {

    //            if (_breakLoop)
    //                yield break;

    //            MetaballParticleClass MetaBall = WaterDropsObjects[i].GetComponent<MetaballParticleClass>();

    //            if (MetaBall.Active == true)
    //                continue;

    //            MetaBall.LifeTime = LifeTime;
    //            WaterDropsObjects[i].transform.position = transform.position;
    //            MetaBall.Active = true;
    //            MetaBall.witinTarget = false;

    //            if (_initSpeed == Vector2.zero)
    //                _initSpeed = initSpeed;

    //            if (DynamicChanges)
    //            {
    //                _initSpeed = initSpeed;
    //                MetaBall.transform.localScale = new Vector3(size, size, 1f);
    //                SetWaterColor(FillColor, StrokeColor);
    //            }

    //            WaterDropsObjects[i].GetComponent<Rigidbody2D>().velocity = _initSpeed;


    //            // Count limiter
    //            if (count > -1)
    //            {
    //                auxCount++;
    //                if (auxCount >= count && !Dynamic)
    //                {
    //                    yield break;
    //                }
    //            }

    //            if (waitBetweenDropSpawn)
    //                yield return new WaitForSeconds(DelayBetweenParticles);

    //        }
    //        yield return new WaitForEndOfFrame();
    //        alreadySpawned = true;

    //        if (!Dynamic)
    //            yield break;

    //    }
    //}

    public void SetWaterColor(Color fill, Color stroke)
    {
        particleMaterial.SetColor("_Color", fill);
        particleMaterial.SetColor("_StrokeColor", stroke);

    }

}
