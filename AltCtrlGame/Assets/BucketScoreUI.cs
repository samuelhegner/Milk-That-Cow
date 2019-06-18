using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BucketScoreUI : MonoBehaviour
{
    public Image milkImage;
    public TextMeshProUGUI fullText;
    public float fillAmount = 0;
    public void ClearImage()
    {
        milkImage.fillAmount = 0;
        fullText.gameObject.SetActive(false);
    }

    private void Update()
    {
        milkImage.fillAmount += fillAmount * Time.deltaTime;
        if (milkImage.fillAmount == 1)
        {
            milkImage.fillAmount = 1;
            fullText.gameObject.SetActive(true);
        }
    }

    public void FillBucket(float amount, int number)
    {
        fillAmount = amount;
        fullText.text = number.ToString();
    }

    public bool IsFull()
    {
        if (milkImage.fillAmount == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
