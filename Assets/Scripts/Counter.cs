using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _counter;

    private int _currentValue = 0;
    private float _secondsToAdd = 0.5f;
    private bool _isPlaying = false;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);       
    }
    void Start()
    {
        _counter.text = _currentValue.ToString("");
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void OnButtonClick()
    {
        StartCoroutine(IncrementValueCoroutine());
    }

    private IEnumerator IncrementValueCoroutine()
    {
        if (_isPlaying) _isPlaying = false;
        else _isPlaying = true;
            
        while (_isPlaying)
        {
            _currentValue++;

            _counter.text = _currentValue.ToString();

            yield return new WaitForSeconds(_secondsToAdd);
        }      
    }
}
