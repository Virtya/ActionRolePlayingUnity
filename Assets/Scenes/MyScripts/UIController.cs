using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text healthLabel;
    [SerializeField] private InventoryPopup popup;
    [SerializeField] private Text levelEnding;
    [SerializeField] private SettingsPopup settingsPopup;

    [System.Obsolete]
    private void Awake()
    {
        Messenger.AddListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
        Messenger.AddListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
        Messenger.AddListener(GameEvent.LEVEL_FAILED, OnLevelFailed);
        Messenger.AddListener(GameEvent.GAME_COMPLETE, OnGameComplete);
    }

    [System.Obsolete]
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
        Messenger.RemoveListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
        Messenger.RemoveListener(GameEvent.LEVEL_FAILED, OnLevelFailed);
        Messenger.RemoveListener(GameEvent.GAME_COMPLETE, OnGameComplete);
    }

    void Start()
    {
        OnHealthUpdated();
        settingsPopup.gameObject.SetActive(false);

        levelEnding.gameObject.SetActive(false);
        settingsPopup.Close();
        popup.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            bool isShowing = popup.gameObject.activeSelf;
            popup.gameObject.SetActive(!isShowing);
            popup.Refresh();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            bool isShowing = settingsPopup.gameObject.activeSelf;
            settingsPopup.gameObject.SetActive(!isShowing);
        }
    }

    private void OnHealthUpdated()
    {
        string message = "Health: " + Managers.Player.health + "/" + Managers.Player.maxHealth;
        healthLabel.text = message;
    }

    [System.Obsolete]
    private void OnLevelComplete()
    {
        StartCoroutine(CompleteLevel());
    }

    [System.Obsolete]
    private IEnumerator CompleteLevel()
    {
        levelEnding.gameObject.SetActive(true);
        levelEnding.text = "Level Complete!";

        yield return new WaitForSeconds(2);

        Managers.Mission.GoToNext();
    }

    [System.Obsolete]
    private void OnLevelFailed()
    {
        StartCoroutine(FailLevel());
    }

    [System.Obsolete]
    private IEnumerator FailLevel()
    {
        levelEnding.gameObject.SetActive(true);
        levelEnding.text = "Level Failed!";

        yield return new WaitForSeconds(2);

        Managers.Player.Respawn();
        Managers.Mission.RestartCurrent();
    }

    public void SaveGame()
    {
        Managers.Data.SaveGameState();
    }

    [System.Obsolete]
    public void LoadGame()
    {
        Managers.Data.LoadGameState();
    }

    private void OnGameComplete()
    {
        levelEnding.gameObject.SetActive(true);
        levelEnding.text = "You Finished the Game!";
    }
}
