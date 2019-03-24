using UnityEngine;

public class ParticleOutOfBounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<MetaballParticleClass>())
        {
            col.GetComponent<MetaballParticleClass>().Destroy();

            ScoreManager.UpdateScoreData(col.tag, ScoreType.milkSplit, 1);
        }
    }
}