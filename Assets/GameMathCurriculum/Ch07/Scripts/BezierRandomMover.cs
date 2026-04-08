using System.Collections.Generic;
using UnityEngine;

public class BezierRandomMover : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Transform endPos;

    private int randomAmount;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            randomAmount = Random.Range(5, 11);

            for (int i = 0; i < randomAmount; i++)
            {
                
                Instantiate(prefab, transform.position, Quaternion.identity).GetComponent<Sphere>().Setdata(new Vector3(Random.Range(0, 11), Random.Range(0, 11), Random.Range(-10, 11)),
                    new Vector3(Random.Range(0, 11), Random.Range(0, 11), Random.Range(-10, 11)), endPos.position, Random.Range(0.5f, 1f),
                    new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
            }
        }
    }
}
