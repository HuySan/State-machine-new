using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObjectBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject _objectList;
    [SerializeField]
    private Button _addObjectButton;
    [SerializeField]
    private Button _doneButton;


    [SerializeField]
    private GameObject _similarPrefab;
    [SerializeField]
    private GameObject _discretePrefab;
    [SerializeField]
    private GameObject _universalPrefab;

    [SerializeField]
    private Button _similarButton;
    [SerializeField]
    private Button _discreteButton;
    [SerializeField]
    private Button _universalButton;

    private SpawnSystem _spawnSystems;
    private ButtonSystem _buttonSystem;

    [SerializeField]
    private Vector3 _spawnPosition =  new Vector3(2, 0.5f, 0);

    void Start()
    {
        _spawnSystems = new SpawnSystem(_similarPrefab, _discretePrefab, _universalPrefab, _spawnPosition);
        _buttonSystem = new ButtonSystem();
    }

    private void OnEnable()
    {
        _similarButton?.onClick.AddListener(SimilarListener);
        _discreteButton?.onClick.AddListener(DiscreteListener);
        _universalButton?.onClick.AddListener(UniversalListener);

        _addObjectButton?.onClick.AddListener(EnableObjectListener);
        _doneButton?.onClick.AddListener(DisableObjectListener);
    }

    private void OnDisable()
    {
        _similarButton?.onClick.RemoveListener(SimilarListener);
        _discreteButton?.onClick.RemoveListener(DiscreteListener);
        _universalButton?.onClick.RemoveListener(UniversalListener);

        _addObjectButton?.onClick.RemoveListener(EnableObjectListener);
        _doneButton?.onClick.RemoveListener(DisableObjectListener);
    }

    private void SimilarListener()
    {
        _spawnSystems.Similar();
    }

    private void DiscreteListener()
    {
        _spawnSystems.Discrete();
    }

    private void UniversalListener()
    {
        _spawnSystems.Universal();
    }

    private void EnableObjectListener()
    {
        _buttonSystem.EnableObjectsList(_objectList, _doneButton.gameObject);
    }

    private void DisableObjectListener()
    {
        _buttonSystem.DisableObjectsList(_objectList, _doneButton.gameObject, true);
    }
}
