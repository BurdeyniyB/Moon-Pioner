using UnityEngine;
using TMPro;

public class ChildCount : MonoBehaviour
{
    public Transform parentObject;
    public int maxChildCount;
    public TextMeshProUGUI textMeshPro;

    void Update()
    {
        int childCount = parentObject.childCount;

        if (childCount >= maxChildCount)
        {
            textMeshPro.text = "Child count: " + childCount + "\nFull";
        }
        else
        {
            textMeshPro.text = "Child count: " + childCount;
        }
    }
}
