
using UnityEngine;
using System.Collections;

public class Minimap : MonoBehaviour {

    public Transform target;
    public float zoomLevel = 20f;
    public float radius = 40f;
    public Blip blip;

    Vector2 XRotation;
    Vector2 YRotation;

    void LateUpdate() {
        XRotation = new Vector2(target.right.x, -target.right.z);
        YRotation = new Vector2(-target.forward.x, target.forward.z);
    }

    public Vector2 TransformPosition(Vector3 position) {
        Vector3 offset = position - target.position;
        Vector2 newPosition = offset.x * XRotation;
        newPosition += offset.z * YRotation;

        newPosition *= zoomLevel;

        return newPosition;
    }

    public Vector2 MoveInside(Vector2 point) {

        float m = point.magnitude;
        Vector2 tmpPoint = point * radius;
        tmpPoint /= m;

        return tmpPoint;
    }

    public void GenerateBlip(GameObject obj)
    {
        Blip b = Instantiate<Blip>(blip);
        b.target = obj.transform;
        b.transform.parent = transform;
    }
}
