using Lean;
using Lean.Touch;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(LeanSelectable), 
    typeof(NavMeshAgent))]
public class RobotController : MonoBehaviour
{
    [SerializeField] private GameObject _robotBehaviouManagerGameObject;
    private IRobotBehaviourManager _robotBehaviouManager;
    public IRobotBehaviourManager RobotBehaviourManager => _robotBehaviouManager;

    [SerializeField] private GameObject _interractAreaGameObject;
    private IIterractArea _iterractArea;

    private LeanSelectable _leanSelectable;
    private NavMeshAgent _navMeshAgent;
    private IRobotBehaviourManager _enteredOtherRobotBehaviourManager;

    private void Awake()
    {
        _leanSelectable = GetComponent<LeanSelectable>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _iterractArea = _interractAreaGameObject.GetComponent<IIterractArea>();
        _robotBehaviouManager = _robotBehaviouManagerGameObject.GetComponent<IRobotBehaviourManager>();
    }

    void OnEnable()
    {
        _leanSelectable.OnSelect.AddListener((leanFinger) => OnSelect());
        _leanSelectable.OnSelectUp.AddListener((leanFinger) => OnDeselect());

        _iterractArea.OnEnterArea += OnEnterOtherRobotArea;
        _iterractArea.OnExitArea += OnExitOtherRobotArea;
    }

    void OnDisable()
    {
        _leanSelectable.OnSelect.RemoveAllListeners();
        _leanSelectable.OnSelectUp.RemoveAllListeners();

        _iterractArea.OnEnterArea -= OnEnterOtherRobotArea;
        _iterractArea.OnExitArea -= OnExitOtherRobotArea;
    }

    private void OnSelect()
    {
        _navMeshAgent.enabled = false;
        _iterractArea.SetActivate(true);

        _robotBehaviouManager.SelectBehaviour(typeof(RobotGlovBehaviour)).
           Activate(null);
    }

    private void OnDeselect()
    {
        _navMeshAgent.enabled = true;
        _iterractArea.SetActivate(false);

        _robotBehaviouManager.SelectBehaviour(typeof(RobotGlovBehaviour)).
            DeActivate(null);

        if (_enteredOtherRobotBehaviourManager != null)
        {
            ResetEnteredOtherRobotBehaviourManager();
        }            
    }

    private void OnEnterOtherRobotArea(params object[] param)
    {
        if(_enteredOtherRobotBehaviourManager == null)
        {
            _enteredOtherRobotBehaviourManager = (param[0] as GameObject).GetComponent<RobotController>().RobotBehaviourManager;

            _enteredOtherRobotBehaviourManager.SelectBehaviour(typeof(RobotGlovBehaviour)).
                Activate(null);
        }  
    }

    private void OnExitOtherRobotArea(params object[] param)
    {
        if (_enteredOtherRobotBehaviourManager != null)
        {
            IRobotBehaviourManager robBehaviourManager = (param[0] as GameObject).GetComponent<RobotController>().RobotBehaviourManager;

            if(_enteredOtherRobotBehaviourManager == robBehaviourManager)
            {
                ResetEnteredOtherRobotBehaviourManager();

                _enteredOtherRobotBehaviourManager = null;
            }            
        }   
    }

    private void ResetEnteredOtherRobotBehaviourManager()
    {
        _enteredOtherRobotBehaviourManager.SelectBehaviour(typeof(RobotGlovBehaviour)).
                DeActivate(null);
    }
}
