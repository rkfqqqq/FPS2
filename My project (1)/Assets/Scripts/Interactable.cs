using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool useEvents;
    [SerializeField]
    public string promptMessage;
    public void BaseInteract()
    {
        if(useEvents)
            GetComponent<InteractionEvents>().OnInteract.Invoke();
        Interact();
    }
    protected virtual void Interact()
    {
        //only template
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
