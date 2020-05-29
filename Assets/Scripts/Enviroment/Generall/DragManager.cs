using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager: MonoBehaviour
{
    private Camera _cam;
    private float _yObjectPosition;
    private Vector3 _startPosition = Vector3.zero;
    private string _layerDraging = "Draging";
    private string _layerFloor = "Floor";
    private float _maxDistance = 100f;

    void Awake()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            UpdateMove();
        }
        else
            _startPosition = Vector3.zero;
    }

    private void UpdateMove()
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _maxDistance, LayerMask.GetMask(_layerDraging)))
        {
            if (_startPosition == Vector3.zero)
                _startPosition = GetHitPoint(hit.transform) - hit.transform.position;
            else
            {
                Vector3 bufVector = GetHitPoint(hit.transform) - _startPosition;

                hit.transform.position = bufVector;
            }
        }
    }

    private Vector3 GetHitPoint(Transform bufTransform)
    {
        Vector3 hitPoint = bufTransform.position;
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _maxDistance, LayerMask.GetMask(_layerDraging)))
        {
            if (Physics.Raycast(ray, out hit, _maxDistance, LayerMask.GetMask(_layerFloor)))
            {
                _yObjectPosition = hit.point.y + 0.1f;
                hitPoint = new Vector3(hit.point.x, _yObjectPosition, hit.point.z);
            }
        }

        return hitPoint;
    }
}
