using System.Collections.Generic;
using UnityEngine;

public class TrainingObject : MonoBehaviour
{
    public bool blockState = true;
    public List<TrainingObject> parentsObject;
    public List<TrainingObject> childsObject;
    public GameObject actionObject;
    public Vector3 position;
    public Vector3 rotation;
    public Training training;


    private void OnMouseDown()
    {
        if (!training.warningPanel.activeSelf)
        {
            bool parentsUnlocked = true;
            bool childsBlocked = true;
            foreach (var i in parentsObject)
            {
                if (i.blockState)
                {
                    parentsUnlocked = false;
                    break;
                }
            }

            foreach (var i in childsObject)
            {
                if (!i.blockState)
                {
                    childsBlocked = false;
                    break;
                }
            }

            if (parentsUnlocked && childsBlocked)
            {
                GameObject tmp_object = !actionObject ? this.gameObject : actionObject;
                tmp_object.transform.Translate(blockState ? position : -position);
                tmp_object.transform.Rotate(blockState ? rotation : -rotation);
                blockState = !blockState;
            }
            else
            {
                training.AddMistake();
            }
        }
    }
}
