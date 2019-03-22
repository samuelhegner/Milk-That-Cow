using UnityEngine;

public class MilkBucket : MonoBehaviour
{
    private int bucketCapacity = 24;
    private int count;

    public void AddMilk(int amount)
    {
        count += amount;
        //Debug.Log(count);
        //Debug.Log(CheckIfFull());
    }

    public bool CheckIfFull()
    {
        return count >= bucketCapacity;
    }

    public void EnableOrDisableColliders(bool value)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child.GetComponent<Collider2D>())
            {
                child.GetComponent<Collider2D>().enabled = value;
            }
        }
    }
}