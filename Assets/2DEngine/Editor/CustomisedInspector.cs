using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomEditor(typeof(CharacterHealth))]
public class CustomisedInspector : Editor
{
    public VisualTreeAsset m_InspectorXML;

    public override VisualElement CreateInspectorGUI()
    {
        // Create a new VisualElement to be the root of our Inspector UI.
        VisualElement myInspector = new VisualElement();

        // Load from default reference.
        m_InspectorXML.CloneTree(myInspector);

        // Return the finished Inspector UI.
        return myInspector;
    }
}