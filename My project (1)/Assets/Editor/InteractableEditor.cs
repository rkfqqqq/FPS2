using UnityEditor;

[CustomEditor(typeof(InteractableEditor), true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable interactable = (interactable)target;
        base.OnInspectorGUI();
        if(interactable.useEvents)
        {
            interactable.gameObject.Addcomponent<InteractionEvent>();
        }
    }
}
