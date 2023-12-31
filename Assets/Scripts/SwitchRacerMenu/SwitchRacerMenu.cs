using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRacerMenu : MonoSingleton<SwitchRacerMenu> {

    private bool menuOn = false;

    [SerializeField] private GameObject menuText;
    [SerializeField] private GameObject menuBox;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Tab) && !menuOn && !ScoreAndTimer.Instance.isGameOver) {
            OpenMenu();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && menuOn) {
            CloseMenu();
        }
    }

    private void OpenMenu() {
        Time.timeScale = 0;
        menuText.SetActive(false);
        menuBox.SetActive(true);
        menuOn = true;
    }

    private void CloseMenu() {
        menuText.SetActive(true);
        menuBox.SetActive(false);
        menuOn = false;
        Time.timeScale = 1;
    }

    public void OnSwitchRacer(int id) {
        RacerService.Instance.SwitchRacer(id);
        CloseMenu();
    }

}
