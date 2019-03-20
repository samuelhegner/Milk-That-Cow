using UnityEngine;

public class MetaballParticleClass : MonoBehaviour
{
    private bool active;
    private bool trailRendererActive;
    private float delta;
    public bool IsInfinite = false;
    public float LifeTime;

    public GameObject masterObject;
    private Rigidbody2D rigidBod;
    private TrailRenderer trailRenderer;
    public bool witinTarget; 

    public bool Active
    {
        get => active;
        set
        {
            active = value;
            if (masterObject)
            {
                masterObject.SetActive(value);

                if (trailRenderer)
                    trailRenderer.Clear();
            }
        }
    }

    public bool SetTrailRenderer
    {
        get => trailRendererActive;
        set
        {
            trailRendererActive = value;
            if (trailRenderer)
            {
                trailRenderer.Clear();
                trailRenderer.enabled = value;
            }
        }
    }

    private void Start()
    {
        //masterObject = gameObject;
        rigidBod = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        if (Active)
        {
            VelocityLimiter();

            if (LifeTime < 0)
                return;

            if (IsInfinite) return;

            if (delta > LifeTime)
            {
                delta *= 0;
                MilkSpawner.particleList.Remove(this.gameObject);
                Destroy(gameObject, 0.5f);
                Active = false;
            }
            else
            {
                delta += Time.deltaTime;
            }
        }
    }

    private void VelocityLimiter()
    {
        var _vel = rigidBod.velocity;
        if (_vel.y < -8f) _vel.y = -8f;
        rigidBod.velocity = _vel;
    }
}