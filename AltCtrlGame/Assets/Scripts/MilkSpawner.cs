using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkSpawner : MonoBehaviour
{
    public static List<GameObject> particleList;

    [Range(0f, 1f)] public float delayBetweenParticles = 0.05f;
    public Vector2 initalVelocity = new Vector2(0.0f, -4.0f);

    public int maxParticleCount = 1000;
    [Range(0f, 100f)] public float particleLifeTime = 5.0f;
    public GameObject particlePrefab;
    [Range(0f, 2f)] public float size = 0.45f;

    private void Awake()
    {
        particleList = new List<GameObject>();
    }

    /// <summary>
    ///     Spawns a burst of milk particles
    /// </summary>
    /// <param name="spawnPos">Spawn position of the particles</param>
    /// <param name="teamTag">Tag of team</param>
    /// <param name="burstCount">Number of milk particles to spawn</param>
    public void SpawnBurst(Transform spawnPos, string teamTag, int burstCount = 0)
    {
        StartCoroutine(SpawnRoutine(spawnPos, teamTag, burstCount));
    }

    private IEnumerator SpawnRoutine(Transform spawnPos, string teamTag, int burstCount)
    {
        for (var i = 0; i < burstCount; i++)
        {
            if (particleList.Count > maxParticleCount)
            {
                Debug.LogWarning("MAX PARTICLE COUNT REACHED! INCREASE PARTICLE LIMIT ON THE FOLLOWING OBJECT: " +
                                 gameObject.name);
                break;
            }

            var particle = Instantiate(particlePrefab, spawnPos.position, Quaternion.identity);
            particle.transform.SetParent(transform);
            particle.transform.localScale = new Vector3(size, size, 1f);
            particle.tag = teamTag;
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