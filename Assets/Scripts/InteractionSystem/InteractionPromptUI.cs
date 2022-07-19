using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionPromptUI : MonoBehaviour
{

    private Camera _mainCamera;

    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private TextMeshProUGUI _promptText;
    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;

        _uiPanel.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var rotation = _mainCamera.transform.rotation;

        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up );
    }

    public bool isDisplayed = false;

    public void SetUp(string promptText){
        _promptText.text = promptText;
        _uiPanel.SetActive(true);
        isDisplayed = true;
    }

    public void Close(){
        _promptText.text = "";
        _uiPanel.SetActive(false);
        isDisplayed = false;
    }
}
