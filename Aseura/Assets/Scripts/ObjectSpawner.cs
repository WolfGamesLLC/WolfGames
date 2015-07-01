using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour {

    public GameObject playerTemplate;
    public GameObject brickTemplate;

    private List<GameObject> bricks;
    private GameObject player;

    void Start()
    {
        player = Instantiate(playerTemplate, new Vector3(0,1,0), Quaternion.identity) as GameObject;
        bricks = new List<GameObject>();
    }

    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.tag.ToString());
                if (hit.collider.tag == "ClickableTerrainObject" || hit.collider.tag == "ClickableBuildingObject")
                {
                    GameObject brick;

                    if (hit.collider.tag == "ClickableBuildingObject")
                    {
                        brick = (GameObject)Instantiate(brickTemplate, hit.collider.transform.position + new Vector3(0, hit.collider.transform.localScale.y, 0), Camera.main.transform.rotation);
                    }
                    else
                    {
                        brick = (GameObject)Instantiate(brickTemplate, hit.point + new Vector3(0, 0.1f, 0), Camera.main.transform.rotation);
                    }

                    brick.transform.LookAt(Camera.main.transform);
                    brick.transform.rotation = new Quaternion(0, brick.transform.rotation.y, 0, brick.transform.rotation.w);
                    bricks.Add(brick);
                }

                Collider[] hitColliders= Physics.OverlapSphere(hit.point, 1);
                foreach(Collider collider in hitColliders)
                    Debug.Log(collider.GetType().ToString());
            }
        }
    } 
}
