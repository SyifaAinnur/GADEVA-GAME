using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    public float minimum = 0.0f;
    public float maximum;
    public float current = 0.0f;
    public float x;
    public float y;
    public float ypos;
    public Image mask;
    public Image icon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
        //IconPosition();
    }

    void GetCurrentFill()
    {
        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;
    }

    public void TambahProg(float topScore)
    {
        current = (float)topScore;
    }

    public void MaxProgress(float maxScore)
    {
        maximum = (float)maxScore;
    }

    //public void IconPosition()
    //{
    //    RectTransform icon = GetComponent<RectTransform>();
    //    icon.anchoredPosition = new Vector2(icon.anchoredPosition.x, icon.anchoredPosition.y + current);
    //}
}
