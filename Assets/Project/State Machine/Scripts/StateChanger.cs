using UnityEngine;

public class StateChanger : MonoBehaviour
{
    private StateMachine _stateMachine;

    private void Start()
    {
        _stateMachine = new StateMachine();
        _stateMachine.Initialize(new IdleState());

    }

    public void OnEnable()
    {
        EventBus.onDiscreteClick += OnDiscreteButtonClick;
        EventBus.onSimilarClick += OnSimilarButtonClick;

        EventBus.onNextState += NextState;
    }

    public void OnDisable()
    {
        EventBus.onDiscreteClick -= OnDiscreteButtonClick;
        EventBus.onSimilarClick -= OnSimilarButtonClick;

        EventBus.onNextState -= NextState;
    }

    private void OnDiscreteButtonClick(GameObject changeObject)
    {
        _stateMachine.ChangeState(new DiscreteState(changeObject));
    }

    private void OnSimilarButtonClick(GameObject changeObject)
    {
        _stateMachine.ChangeState(new SimilarState(changeObject));
    }

    private void NextState()
    {
        Debug.Log("___CHANGE STATE___");
        _stateMachine.ChangeState(new IdleState());
    }
}
