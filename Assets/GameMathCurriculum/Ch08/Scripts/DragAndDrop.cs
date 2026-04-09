using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private static readonly string canSelect = "Selectable";
    private static readonly string ground = "Ground";
    private static readonly string zone = "DropZone";
    private static readonly string box = "Box";

    Camera cam;

    private GameObject catched;

    private Vector3 originalPos;
    private bool returntoOrigin;
    private LayerMask usingLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        usingLayer = LayerMask.GetMask(box);
        returntoOrigin = false;
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

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, usingLayer) == false)
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

        if (Input.GetMouseButton(0) && catched != null)
        {
            if (hit.collider.CompareTag(ground) == false)
            {
                return;
            }

            catched.transform.position = new Vector3(hit.point.x, Terrain.activeTerrain.SampleHeight(hit.point) + 0.5f, hit.point.z);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (hit.collider.CompareTag(zone) == false)
            {
                returntoOrigin = true;
            }
            else
            {
                catched.transform.position = new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z);
                catched = null;
            }
            usingLayer = LayerMask.GetMask(box);
        }

        if(returntoOrigin == true && catched != null)
        {
            var temp = new Vector3(catched.transform.position.x, Terrain.activeTerrain.SampleHeight(catched.transform.position) + 0.5f, catched.transform.position.z);
            catched.transform.position = Vector3.Lerp(temp, originalPos, 4f * Time.deltaTime);

            if (catched.transform.position.x - originalPos.x < 0.01f && catched.transform.position.z - originalPos.z < 0.01f)
            {
                catched.transform.position = originalPos;
                catched = null;
                returntoOrigin = false;
                Debug.Log(catched == null);
            }
        }
    }
}
