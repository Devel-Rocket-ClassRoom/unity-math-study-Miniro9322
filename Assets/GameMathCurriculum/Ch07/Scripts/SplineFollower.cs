using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;

public class SplineFollower : MonoBehaviour
{
    public Transform mover;
    public float duration = 5f;
    private SplineContainer splineContainer;
    private float t;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        splineContainer = GetComponent<SplineContainer>();
        t = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        t += Time.deltaTime / duration;
        t = Mathf.Repeat(t, 1f);

        if(!splineContainer.Evaluate(splineContainer.Spline, t, out float3 position, out float3 tanget, out float3 up))
        {
            return;
        }

        mover.position = position;
        if(math.length(tanget) > 0.001f)
        {
            mover.rotation = Quaternion.LookRotation(tanget, up);
        }
    }
}
