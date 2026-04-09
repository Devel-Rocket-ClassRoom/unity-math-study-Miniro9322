using UnityEngine;

public class Sphere : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 p1;
    private Vector3 p2;
    private Vector3 endPos;
    private float speed;
    [SerializeField]
    private Material material;
    private Renderer render;
    private float elapsedTime;
    private TrailRenderer trailRenderer;
    private void Awake()
    {
        elapsedTime = 0f;
        render = GetComponent<Renderer>();
        render.material = material;
        startPos = transform.position;
        trailRenderer = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime * speed;
        transform.position = CubicBezier(startPos, p1, p2, endPos, elapsedTime);

        if(elapsedTime >= 1f)
        {
            Destroy(gameObject);
        }
    }

    public void Setdata(Vector3 pos1, Vector3 pos2, Vector3 end, float ranSpeed, Color ranColor)
    {
        p1 = pos1;
        p2 = pos2;
        endPos = end;
        speed = ranSpeed;
        render.material.color = ranColor;
        trailRenderer.material.color = ranColor;
    }

    private Vector3 CubicBezier(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        // TODO
        Vector3 a = Vector3.Lerp(p0, p1, t);
        Vector3 b = Vector3.Lerp(p1, p2, t);
        Vector3 c = Vector3.Lerp(p2, p3, t);

        Vector3 d = Vector3.Lerp(a, b, t);
        Vector3 e = Vector3.Lerp(b, c, t);

        return Vector3.Lerp(d, e, t);
    }
}
