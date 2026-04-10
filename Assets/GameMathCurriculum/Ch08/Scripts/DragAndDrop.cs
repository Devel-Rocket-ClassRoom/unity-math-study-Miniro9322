using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private static readonly string canSelect = "Selectable";
    private static readonly string ground = "Ground";
    private static readonly string zone = "DropZone";
    private static readonly string box = "Box";

    Camera cam;

    private GameObject catched;
    private LayerMask usingLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        usingLayer = LayerMask.GetMask(box);
        catched = null;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (catched != null)
        {
            usingLayer = LayerMask.GetMask(ground);
        }
        else
        {
            usingLayer = LayerMask.GetMask(box);
        }

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, usingLayer) == false)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider.CompareTag(canSelect))
            {
                catched = hit.collider.gameObject;
            }
        }

        if (Input.GetMouseButton(0) && catched != null)
        {
            if (hit.collider.CompareTag(ground) == false)
            {
                return;
            }

            catched.transform.position = new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z);
        }

        if (Input.GetMouseButtonUp(0) && catched != null)
        {
            if (hit.collider.CompareTag(zone) == false)
            {
                catched.GetComponent<BoxControll>().ReturntoOrigin();
            }
            else
            {
                catched.GetComponent<BoxControll>().UpdateOrigin(new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z));
            }
            catched = null;
        }
    }
}
