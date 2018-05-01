//=============================================================================
//
// Chad Johnson
// 1763718
// johns428@mail.chapman.edu
// CPSC-340-01 & CPSC-344-01
// Group Project
//
// StartMenu controls interactions with the Start Menu.
//
//=============================================================================

using System;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;
using Game;

namespace Menus
{
    /// <summary>
    /// Contains functions for game settings.
    /// </summary>
    public class StartMenu : MonoBehaviour
    {
        /// <summary>
        /// Reference to ReferenceManager.
        /// </summary>
        private ReferenceManager reference;

        /// <summary>
        /// Reference to Spawner.
        /// </summary>
        private Spawner spawner;

        /// <summary>
        /// Reference to GameValues;
        /// </summary>
        private GameValues gameValues;

        /// <summary>
        /// Reference to environment gameobject.
        /// </summary>
        private GameObject environmentGO;

        /// <summary>
        /// Reference to Menu Transition Manager.
        /// </summary>
        private MenuTransitionManager menuTransitionManager;

        /// <summary>
        /// Reference to menu to go to when back is pressed.
        /// </summary>
        public GameObject backMenuGO;

        /// <summary>
        /// Reference to beginner button.
        /// </summary>
        public Button beginnerButton;

        /// <summary>
        /// Reference to advanced button.
        /// </summary>
        public Button advancedButton;

        /// <summary>
        /// Reference to environment toggle.
        /// </summary>
        public Toggle environmentToggle;

        /// <summary>
        /// Reference to Menu Audio source.
        /// </summary>
        private AudioSource source;

        /// <summary>
        /// Find references. Set initial values.
        /// </summary>
        private void Awake()
        {
            reference = FindObjectOfType<ReferenceManager>();
            spawner = reference.spawner;
            gameValues = reference.gameValues;
            environmentGO = reference.environmentGO;
            menuTransitionManager = reference.menuTransitionManager;
            source = reference.mainCanvasAudioSource;

            environmentToggle.isOn = gameValues.environmentOn;
            environmentGO.SetActive(gameValues.environmentOn);

            switch (gameValues.difficulty)
            {
                case GameValues.Difficulty.Beginner:
                    beginnerButton.GetComponent<UIHover>().Select();
                    advancedButton.GetComponent<UIHover>().EndSelect();
                    break;
                case GameValues.Difficulty.Advanced:
                    beginnerButton.GetComponent<UIHover>().EndSelect();
                    advancedButton.GetComponent<UIHover>().Select();
                    break;
            }
        }

        /// <summary>
        /// Beginner button pressed. Select Beginner difficulty mode.
        /// </summary>
        public void PressBeginner()
        {
            source.PlayOneShot(reference.menuSelect);
            beginnerButton.GetComponent<UIHover>().Select();
            advancedButton.GetComponent<UIHover>().EndSelect();
            gameValues.SetDifficulty(GameValues.Difficulty.Beginner);
        }

        /// <summary>
        /// Advanced button pressed. Select Advanced difficulty mode.
        /// </summary>
        public void PressAdvanced()
        {
            source.PlayOneShot(reference.menuSelect);
            advancedButton.GetComponent<UIHover>().Select();
            beginnerButton.GetComponent<UIHover>().EndSelect();
            gameValues.SetDifficulty(GameValues.Difficulty.Advanced);
        }

        /// <summary>
        /// Change environment active status based on value.
        /// </summary>
        public void ToggleEnvironment(bool isOn)
        {
            source.PlayOneShot(reference.menuSelect);
            gameValues.SetEnvironmentOn(isOn);
        }

        /// <summary>
        /// Play button pressed. Begin play.
        /// </summary>
        public void PressedPlay()
        {
            source.PlayOneShot(reference.menuSelect);
            reference.tutorialCanvasAudioSource.Stop();
            PlayerPrefs.SetInt("environmentOn", Convert.ToInt32(environmentGO.activeSelf));

            if (reference.tutorial.gameObject.activeSelf)
            {
                reference.tutorial.SwitchStages(Tutorial.TutorialStage.Gameplay);
                reference.tutorial.ShowInStage();
            }
            else
            {
                spawner.gameObject.SetActive(true);
            }

            foreach (UIPointer uiPointer in reference.uiPointers)
            {
                uiPointer.gameObject.SetActive(false);
            }

            gameObject.SetActive(false);
        }

        /// <summary>
        /// Back button pressed. Navigate to Main Menu.
        /// </summary>
        public void PressBack()
        {
            source.PlayOneShot(reference.menuBack);
            menuTransitionManager.Transition(backMenuGO);
        }
    }
}
