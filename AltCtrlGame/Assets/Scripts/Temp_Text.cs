using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Temp_Text : MonoBehaviour
{
    bool fullSize;

    public float lerpSpeed;
    public float targetScale;

    TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!fullSize)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(targetScale, targetScale, targetScale), Time.deltaTime * lerpSpeed);
            if (Vector3.Distance(transform.localScale, new Vector3(targetScale, targetScale, targetScale)) < 0.05f)
            {
                fullSize = true;
            }
        }
        else {
            tmp.color = Color.Lerp(tmp.color, new Color(tmp.color.r, tmp.color.g, tmp.color.b, 0), Time.deltaTime * lerpSpeed * 2f);

            if (tmp.color.a < 0.01f) {
                Text_Manager.inProg = false;
                Destroy(gameObject);
            }
        }
    }
}
