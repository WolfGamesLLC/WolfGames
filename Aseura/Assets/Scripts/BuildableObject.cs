using UnityEngine;
using System.Collections;

public class BuildableObject : MonoBehaviour 
{
    private float yOffset;

	// Use this for initialization
    public void Setup()
    {
        transform.LookAt(Camera.main.transform);
        transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
        yOffset = transform.collider.bounds.size.y / 2;
        MoveToGround();
    }

    void MoveToGround()
    {
        RaycastHit rayHit;
        if (Physics.Raycast(transform.position, transform.up * (-1), out rayHit))
        {
            transform.position = new Vector3(rayHit.point.x, rayHit.point.y + yOffset, rayHit.point.z);
        }
    }

    void OnMouseUp()
    {
        MoveToGround();
    }
}
