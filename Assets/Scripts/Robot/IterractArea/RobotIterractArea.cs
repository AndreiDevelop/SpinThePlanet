using UnityEngine;

public class RobotIterractArea : MonoBehaviour, IIterractArea
{
    private const string ROBOT_INTERRACT_AREA_TAG = "RobotInterractArea";

    public event CustomEventHandler.EventHandler OnEnterArea;
    public event CustomEventHandler.EventHandler OnExitArea;

    private bool IsActive { get; set; }

    public void OnTriggerEnter(Collider other)
    {
        if (IsActive && other.tag == ROBOT_INTERRACT_AREA_TAG)
        {
            EnterArea(other.transform.parent.gameObject);
            Debug.Log("1");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (IsActive && other.tag == ROBOT_INTERRACT_AREA_TAG)
        {
            ExitArea(other.transform.parent.gameObject);
            Debug.Log("2");
        }
    }

    public void SetActivate(bool isActive)
    {
        IsActive = isActive;   
    }

    private void EnterArea(params object[] param)
    {
        OnEnterArea?.Invoke(param[0]);
    }

    private void ExitArea(params object[] param)
    {
        OnExitArea?.Invoke(param[0]);
    }
}
