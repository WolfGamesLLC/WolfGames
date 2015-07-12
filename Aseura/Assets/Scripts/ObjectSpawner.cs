using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour {

    public GameObject playerTemplate;
    public BuildableObject brickTemplate;

    private List<BuildableObject> bricks;
    private GameObject player;

    private bool lockOn = false;
    private GameObject obj = null;
    private float distance = 0f;
 
    void Start()
    {
        player = Instantiate(playerTemplate, new Vector3(0,1,0), Quaternion.identity) as GameObject;
        bricks = new List<BuildableObject>();
    }

    void Update()
    {
        if (Input.GetButtonUp("Fire2"))
        {
            InstantiateNewObject();
        }

        if (Input.GetMouseButton(0))
        {
            MoveObject();
        }
        else
            lockOn = false;
    }

    private void InstantiateNewObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "ClickableTerrainObject")
            {
                InstantiateNewObjectAtPosition(hit.point + new Vector3(0, 0.1f, 0));
            }

            if (hit.collider.tag == "ClickableBuildingObject")
            {
                InstantiateNewObjectAtPosition(hit.collider.transform.position + new Vector3(0, hit.collider.transform.localScale.y, 0));
            }
        }
    }

    private void InstantiateNewObjectAtPosition(Vector3 position)
    {
        BuildableObject brick;

        brick = (BuildableObject)Instantiate(brickTemplate, position, Camera.main.transform.rotation);

        brick.Setup();
        bricks.Add(brick);
    }

    void MoveObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 objPos;
        int layerMask = ~(1 << 10);

        if (Physics.Raycast(ray, out hit, 10000f, layerMask) && !lockOn)
        {
            obj = hit.collider.gameObject;
            distance = hit.distance;
        }

        lockOn = true;
        objPos = ray.origin + (distance * ray.direction);
//        obj.transform.position = new Vector3(objPos.x, objPos.y, obj.transform.position.z);
        obj.transform.position = objPos;
        obj.transform.LookAt(Camera.main.transform);
        obj.transform.rotation = new Quaternion(0, obj.transform.rotation.y, 0, obj.transform.rotation.w);
    }
}
