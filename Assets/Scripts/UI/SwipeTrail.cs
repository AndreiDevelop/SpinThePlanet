using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTrail : MonoBehaviour
{
    [SerializeField] private GameObject _trailRendererPrefab;

    private Transform _transformTrail;
    private bool touched;
    
    void Start()
    {
        touched = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            touched = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            touched = false;

        }
        else
        {
            if (touched == true)
            {
                if(_transformTrail == null)
                {
                    _transformTrail = Instantiate(_trailRendererPrefab).transform;
                }
                
                _transformTrail.position = ray.GetPoint(2);
            }  
        }
    }
}
