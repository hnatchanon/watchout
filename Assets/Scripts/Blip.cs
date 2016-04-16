using UnityEngine;
using System.Collections;

public class Blip : MonoBehaviour {

    public Transform target;

    Minimap map;
    RectTransform myRectTransform;


    void Start() {
        map = GetComponentInParent<Minimap>();
        myRectTransform = GetComponent<RectTransform>();
    }

    void LateUpdate() {
        Vector2 newPosition = map.TransformPosition(target.position);

        newPosition = map.MoveInside(newPosition);

        myRectTransform.localPosition = newPosition;

        float angle = 360 - Mathf.Atan2(newPosition.x, newPosition.y)* 180 / Mathf.PI;
        myRectTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (!target.gameObject.activeSelf) {
            gameObject.SetActive(false);
        }
    }
}
