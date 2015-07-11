using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour {

    public GameObject playerTemplate;
    public BuildableObject brickTemplate;

    private List<BuildableObject> bricks;
    private GameObject player;

    void Start()
    {
        player = Instantiate(playerTemplate, new Vector3(0,1,0), Quaternion.identity) as GameObject;
        bricks = new List<BuildableObject>();
    }

    void Update()
    {
        if (Input.GetButtonUp("Fire2"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.tag.ToString());
                if (hit.collider.tag == "ClickableTerrainObject") 
                {
                    InstantiateNewObject(hit.point + new Vector3(0, 0.1f, 0));
                }

                if(hit.collider.tag == "ClickableBuildingObject")
                {
                    InstantiateNewObject(hit.collider.transform.position + new Vector3(0, hit.collider.transform.localScale.y, 0));
                }

//                Collider[] hitColliders= Physics.OverlapSphere(hit.point, 1);
//                foreach(Collider collider in hitColliders)
//                    Debug.Log(collider.GetType().ToString());
            }
        }
    }

    private void InstantiateNewObject(Vector3 position)
    {
        BuildableObject brick;

        brick = (BuildableObject)Instantiate(brickTemplate, position, Camera.main.transform.rotation);

        brick.Setup();
        bricks.Add(brick);
    } 
}
