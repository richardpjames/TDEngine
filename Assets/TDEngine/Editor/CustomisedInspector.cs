using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomisedInspector : Editor
{
    public override VisualElement CreateInspectorGUI()
    {
        return AttachCustomUXML(Resources.Load<VisualTreeAsset>(this.GetType().Name));
    }

    protected VisualElement AttachCustomUXML(VisualTreeAsset uxmlResource)
    {
        // Create a new VisualElement to be the root of our Inspector UI.
        VisualElement myInspector = new VisualElement();

        // Load from default reference.
        uxmlResource.CloneTree(myInspector);

        // Return the finished Inspector UI.
        return myInspector;
    }
}
