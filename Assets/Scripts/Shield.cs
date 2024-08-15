using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private float _maxShieldPoints = 100f;
    [SerializeField] private float _spendSpeed = 10f;
    [SerializeField] private float _restoreSpeed = 5f;
    [SerializeField] private ProgressBar _progressBar;

    private float _shieldPoints;
    private bool _isActive;

    public bool isActive {  get => _isActive;}

    private void Awake()
    {
        _shieldPoints = _maxShieldPoints;
        _isActive = false;
    }

    private void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            SpendPoints(_spendSpeed);

            if (_shieldPoints > 0) 
                _isActive = true;
            else 
                _isActive = false;
        }
        else
        {
            _isActive = false;
            RestorePoints(_restoreSpeed);
        }
    }

    private void SpendPoints(float points)
    {
        _shieldPoints -= points * Time.deltaTime;
        if (_shieldPoints < 0)
            _shieldPoints = 0;

        UpdateProgressBar();
    }

    private void RestorePoints(float points)
    {
        _shieldPoints += points * Time.deltaTime;
        if (_shieldPoints > _maxShieldPoints)
            _shieldPoints = _maxShieldPoints;

        UpdateProgressBar();
    }

    private void UpdateProgressBar()
        => _progressBar.SetValue(_shieldPoints / _maxShieldPoints);
}