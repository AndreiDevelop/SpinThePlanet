using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SwipeRotator : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private Quaternion defaultAvatarRotation;

    [SerializeField]
    private float slowSpeedRotation = 0.03f;
    [SerializeField]
    private float speedRotation = 0.03f;

    [SerializeField]
    private float _maxDistance = 100f;

    [SerializeField]
    private ProgressManager _progressManager;

    private const string ROTATING_LAYER = "Rotating";

    private bool isRotating = false;

    private RaycastHit hit;
    private Rigidbody _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxAngularVelocity = 100f;
        defaultAvatarRotation.y = 180.0f;
    }

    // Update is called once per frame
    void Update()
    {
        _progressManager.UpdateProgress(_rigidbody.angularVelocity.y);
        MouseButtonDown();
        MouseButtonUp();
        if (Input.GetMouseButton(0) && isRotating)
        {
            RaycastHit dragingHit;

#if UNITY_EDITOR
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
#elif UNITY_ANDROID
 
            Ray ray = cam.ScreenPointToRay(Input.touches[0].position);
#endif
            if (Physics.Raycast(ray, out dragingHit, _maxDistance, LayerMask.GetMask(ROTATING_LAYER)))
            {

#if UNITY_EDITOR
                    float x = -Input.GetAxis("Mouse X");
#elif UNITY_ANDROID
 
                    float x = -Input.touches[0].deltaPosition.x;
#endif               
                //transform.rotation *= Quaternion.AngleAxis(x * speedRotation, Vector3.up);
                //if((_progressManager.ProgressValue < 1 && x > 0) || (_progressManager.ProgressValue > 0 && x < 0))
                //{
                    _rigidbody.AddTorque(new Vector3(0f, x * speedRotation, 0f), ForceMode.Force);
                //}
                
            }
        }
        else
        {
            if (transform.rotation.y != defaultAvatarRotation.y)
            {
               // SlowRotation();
            }
        }
    }

    private void MouseButtonDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Press rotating button");
#if UNITY_EDITOR
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
#elif UNITY_ANDROID
        Ray ray = cam.ScreenPointToRay(Input.touches[0].position);
#endif
            if (Physics.Raycast(ray, out hit, _maxDistance, LayerMask.GetMask(ROTATING_LAYER)))
            {
                Debug.Log("Is rotating");
                isRotating = true;
            }
        }
    }

    private void MouseButtonUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
            hit = new RaycastHit();
        }
    }

    private void SlowRotation()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
                                              defaultAvatarRotation,
                                              slowSpeedRotation * Time.deltaTime);
    }
}
