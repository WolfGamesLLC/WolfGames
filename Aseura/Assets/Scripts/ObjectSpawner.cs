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
                if (hit.collider.tag == "ClickableObject")
                {
                    Quaternion newBrickRotation = Camera.main.transform.rotation;
                    newBrickRotation.x = 0;
                    newBrickRotation.z = 0;
                    GameObject brick = (GameObject)Instantiate(brickTemplate, hit.point + new Vector3(0, brickTemplate.transform.localScale.y, 0), newBrickRotation);
                    brick.transform.LookAt(Camera.main.transform);
                    brick.transform.rotation = new Quaternion(0, brick.transform.rotation.y, 0, brick.transform.rotation.w);
                    Debug.Log("Brick created at " + brick.transform);
                    bricks.Add(brick);
                    //hit.collider.gameObject now refers to the 
                    //cube under the mouse cursor if present
                }
            }
        }
    } 
}
