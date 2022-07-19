using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{

    private Animator _animator;
    [SerializeField] private bool isDoorOpen = false;
    [SerializeField] private string _promt = "Press E to {state} the door";

    private string _tempPrompt;

    public string InteractionPrompt {get;set;}


    private void Awake(){
        _tempPrompt = _promt;
        UpdateText(isDoorOpen);
        _animator = gameObject.GetComponent<Animator>();
        //if by default is open
        if(isDoorOpen){
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }
    }

    public bool Interact(Interactor interactor){

        if (AnimatorIsPlaying("Close") || AnimatorIsPlaying("Open")) return false;
        Debug.Log(isDoorOpen ? "Closing Door": "Opening Door");

        if(isDoorOpen){
            _animator.Play("Close", 0, 0.0f);
        } else {
            _animator.Play("Open", 0, 0.0f);
        }

        //toogle door on interaction
        isDoorOpen = !isDoorOpen;

        UpdateText(isDoorOpen);

        return true;
    }

    bool AnimatorIsPlaying(string stateName){
     return AnimatorIsPlaying() && _animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

    bool AnimatorIsPlaying(){
        return _animator.GetCurrentAnimatorStateInfo(0).length >
            _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    } 

    private void UpdateText(bool _isDoorOpen){
        
        InteractionPrompt = _tempPrompt.Replace("{state}", _isDoorOpen ? "close": "open");
        Debug.Log(InteractionPrompt);
    }
}
