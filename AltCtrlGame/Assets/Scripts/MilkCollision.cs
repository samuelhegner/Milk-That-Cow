using UnityEngine;

public class MilkCollision : MonoBehaviour
{
    public MilkSystem milkSystem;

    private void Start()
    {
        milkSystem = GameObject.FindGameObjectWithTag("MilkManager").GetComponent<MilkSystem>();
        if (gameObject.CompareTag("Untagged")) Debug.LogWarning(gameObject.name + " is not tagged with a team tag");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(gameObject.tag) && !col.GetComponent<MetaballParticleClass>().witinTarget)
        {
            Debug.Log("Milk detected add score " + col.tag);
            milkSystem.AddOrRemoveMilk(gameObject.tag, true);

            col.GetComponent<MetaballParticleClass>().IsInfinite = true;
            col.GetComponent<MetaballParticleClass>().witinTarget = true;
            //col.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }
        else
        {
            //Destroy(col.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag(gameObject.tag) && col.GetComponent<MetaballParticleClass>().witinTarget)
        {
            Debug.Log("Milk leaving remove score");
            milkSystem.AddOrRemoveMilk(gameObject.tag, false);

            col.GetComponent<MetaballParticleClass>().IsInfinite = false;
            col.GetComponent<MetaballParticleClass>().witinTarget = false;
            //col.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Discrete;
        }
    }
}