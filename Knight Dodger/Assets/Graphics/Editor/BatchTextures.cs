using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BatchTextures : ScriptableWizard
{
    public string batchName;
    public GameObject obj;
    List<Transform> children;

    [MenuItem("Tools/Batching")]

    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<BatchTextures>("Create Batch", "Create new", "Apply");
        BatchTextures batching = (BatchTextures)EditorWindow.GetWindow(typeof(BatchTextures));
        batching.Show();
    }

    void OnWizardCreate()
    {
        Texture2D texture = new Texture2D(10, 10);
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            children.Add(obj.transform.GetChild(i));
        }


    }

    void OnWizardUpdate()
    {

    }

}
