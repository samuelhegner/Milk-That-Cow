using UnityEngine;

public class MetaballParticleClass : MonoBehaviour
{


    public GameObject masterObject;
    public float LifeTime;
    public bool Active
    {
        get => _active;
        set
        {
            _active = value;
            if (masterObject)
            {
                masterObject.SetActive(value);

                if (trailRenderer)
                    trailRenderer.Clear();

            }
        }
    }
    public bool witinTarget; // si esta dentro de la zona de vaso de vidrio en la meta



    private bool _active;
    private float delta;
    private Rigidbody2D rigidBod;
    private TrailRenderer trailRenderer;

    private void Start()
    {
        //masterObject = gameObject;
        rigidBod = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Update()
    {

        if (Active == true)
        {

            VelocityLimiter();

            if (LifeTime < 0)
                return;

            if (delta > LifeTime)
            {
                delta *= 0;
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


        Vector2 _vel = rigidBod.velocity;
        if (_vel.y < -8f)
        {
            _vel.y = -8f;
        }
        rigidBod.velocity = _vel;
    }

}
