using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Training : MonoBehaviour
{
    int mistakeCount = 0;
    float seconds = 0;
    bool missionIsEnd;

    public List<TrainingObject> targets;
    public GameObject infoText;
    public GameObject warningPanel;
    

    void PauseTraining()
    {
        warningPanel.SetActive(true);
        infoText.GetComponent<Text>().text = ((missionIsEnd) ? "YOU WIN!" : "PAUSE") + "\n"
            + "Mistakes = " + mistakeCount + "\n" + "Seconds = " + (int)seconds;
    }    

    public void AddMistake()
    {
        ++mistakeCount;
        PauseTraining();
    }

    public void ContinueTraining()
    {
        if (!missionIsEnd)
        {
            warningPanel.SetActive(false);
        }
    }    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!warningPanel.activeSelf)
        {            
            missionIsEnd = true;
            foreach (var i in targets)
            {
                if (!i.blockState)
                {
                    missionIsEnd = false;
                    break;
                }
            }

            if (!missionIsEnd && !warningPanel.activeSelf)
            {
                seconds += 0.02f;
            }
            else
            {
                PauseTraining();
            }
        }
    }
}
