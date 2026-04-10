using UnityEngine;

public class BoxControll : MonoBehaviour
{
    private Vector3 originPos;
    private bool returning;

    private Terrain terrain;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originPos = transform.position;
        returning = false;
        terrain = Terrain.activeTerrain;
    }

    private void Update()
    {
        if(returning == true)
        {
            var temp = new Vector3(transform.position.x, terrain.SampleHeight(transform.position), transform.position.z);

            transform.position = Vector3.Lerp(temp, originPos, 4f * Time.deltaTime);

            if (Mathf.Abs(transform.position.x - originPos.x) < 0.01f && Mathf.Abs(transform.position.z - originPos.z) < 0.01f)
            {
                transform.position = originPos;
                returning = false;
            }
        }
        
    }

    public void ReturntoOrigin()
    {
        returning = true;
    }

    public void UpdateOrigin(Vector3 pos)
    {
        originPos = pos;
    }
}
