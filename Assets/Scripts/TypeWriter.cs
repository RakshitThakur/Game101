using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour
{
    public static TypeWriter Instance;
    
    [SerializeField] string [] _dialogue;
    [SerializeField] float _speed;
    [SerializeField] GameObject _dialogueBG;
    [SerializeField] float _stayTime;
    [SerializeField] GameObject _instructionWindow;
    private int _showingText;
    private string _currentText;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        _showingText = -1;
        _dialogueBG.SetActive(false);
        _instructionWindow.SetActive(false);
        DisplayNextText();
    }
    public void DisplayNextText()
    {
        _showingText++;
        if(_showingText == 5)
        {
            _instructionWindow.SetActive(true);
        }
        StopAllCoroutines();
        StartCoroutine(DisplayText(_speed));
    }

    IEnumerator DisplayText(float _speed)
    {
        if(_showingText < _dialogue.Length)
        {
            _dialogueBG.SetActive(true);
            for (int j = 0; j <= _dialogue[_showingText].Length; j++)
            {    
                _currentText = _dialogue[_showingText].Substring(0, j);
                this.GetComponent<Text>().text = _currentText;
                yield return new WaitForSeconds(_speed);
            }
            yield return new WaitForSeconds(_stayTime);
            this.GetComponent<Text>().text = null;
            _dialogueBG.SetActive(false);
        }
        else
        {
            _showingText--;
        }
    }
}
