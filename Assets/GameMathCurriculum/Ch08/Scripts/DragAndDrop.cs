using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private static readonly string canSelect = "Selectable";
    private static readonly string ground = "Ground";
    private static readonly string zone = "DropZone";


    Camera cam;

    private GameObject catched;

    private Vector3 originalPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit) == false)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider.CompareTag(canSelect))
            {
                catched = hit.collider.gameObject;
                originalPos = catched.transform.position;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (hit.collider.CompareTag(ground) == false)
            {
                return;
            }
            catched.transform.position = new Vector3(hit.point.x, Terrain.activeTerrain.SampleHeight(hit.point), hit.point.z);
        }
    }
}
