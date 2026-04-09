using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class TargetInfo : MonoBehaviour
{
    [SerializeField] private Transform[] targets;
    private Vector3[] targetScreenPoses;
    [SerializeField] private Image[] images;

    private Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        targetScreenPoses = new Vector3[targets.Length];
    }

    // Update is called once per frame
    void LateUpdate()
    {
        for(int i = 0; i < targets.Length; i++)
        {
            targetScreenPoses[i] = cam.WorldToScreenPoint(targets[i].position);
        }

        for (int i = 0; i < targetScreenPoses.Length; i++)
        {
            if (targetScreenPoses[i].x < 0f || targetScreenPoses[i].y < 0f || targetScreenPoses[i].x > Screen.width || targetScreenPoses[i].y > Screen.height)
            {
                if (targetScreenPoses[i].z < 0)
                {
                    targetScreenPoses[i].x = Screen.width - targetScreenPoses[i].x;
                    targetScreenPoses[i].y = Screen.height - targetScreenPoses[i].y;

                }
                targetScreenPoses[i].x = Mathf.Clamp(targetScreenPoses[i].x, 0f + images[i].GetComponent<RectTransform>().rect.width / 2f, Screen.width - images[i].GetComponent<RectTransform>().rect.width / 2f);
                targetScreenPoses[i].y = Mathf.Clamp(targetScreenPoses[i].y, 0f + images[i].GetComponent<RectTransform>().rect.height / 2f, Screen.height - images[i].GetComponent<RectTransform>().rect.height / 2f);
                

                images[i].GetComponent<RectTransform>().position = targetScreenPoses[i];
                images[i].enabled = true;
            }
            else
            {
                images[i].enabled = false;
            }
        }

    }
}
