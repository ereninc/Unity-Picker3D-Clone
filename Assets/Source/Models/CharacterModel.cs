using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel : ObjectModel
{
    [SerializeField] private FinishModel finishline;
    [SerializeField] private LevelBarController levelBarController;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "PassArea":
                PassAreaModel passArea = other.GetComponent<PassAreaModel>();
                onEnterPassArea();
                this.Invoke(() => checkArea(passArea), 2f);
                break;
            case "Finish":
                onLevelCompleted();
                break;
            default:
                break;
        }
    }

    private void onLevelCompleted()
    {
        LevelController.Instance.NextLevel();
        PlayerController.Instance.OnLevelCompleted();
        GameController.ChangeState(GameStates.Win);
    }

    private void onEnterPassArea()
    {
        Debug.Log("OnEnterPassArea -> Stop");
        PlayerController.Instance.OnEnterPassArea();
    }

    private void onExitPassArea() 
    {
        Debug.Log("OnExitPassArea -> Continue");
        PlayerController.Instance.OnExitPassArea();
    }

    private void checkArea(PassAreaModel passArea)
    {
        if (passArea.CheckArea())
        {
            onExitPassArea();
            passArea.OnPassedArea();
            levelBarController.OnAreaPassed();
        }
        else
        {
            Debug.Log("LEVEL FAILED -> SetGameState = Lose");
            GameController.ChangeState(GameStates.Lose);
            passArea.OnFailArea();
            levelBarController.OnAreaFailed();
        }
    }
}