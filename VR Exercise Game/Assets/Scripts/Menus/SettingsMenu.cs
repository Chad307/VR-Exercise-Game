//=============================================================================
//
// Chad Johnson
// 1763718
// johns428@mail.chapman.edu
// CPSC-340-01 & CPSC-344-01
// Group Project
//
// SettingsMenu controls interactions with the Settings Menu.
//
//=============================================================================

using System;
using UnityEngine;
using UnityEngine.UI;
using Game;

namespace Menus
{
    /// <summary>
    /// Controls interactions with Display Menu.
    /// </summary>
    public class SettingsMenu : MonoBehaviour
    {
        /// <summary>
        /// Reference to Menu Transition Manager.
        /// </summary>
        private MenuTransitionManager menuTransitionManager;

        /// <summary>
        /// Reference to menu to go to when back is pressed.
        /// </summary>
        public GameObject backMenuGO;

        /// <summary>
        /// Reference to Menu Audio source.
        /// </summary>
		private AudioSource source;

        /// <summary>
        /// Reference to volume slider.
        /// </summary>
        public Slider volumeSlider;

        /// <summary>
        /// Reference to Color Blind Mode Toggle.
        /// </summary>
        public Toggle colorBlindModeToggle;

        /// <summary>
        /// Reference to Tutorial Toggle.
        /// </summary>
        public Toggle tutorialToggle;

        /// <summary>
        /// Represents a color blind mode button GO and its associated ColorBlindMode.Mode.
        /// </summary>
        [Serializable]
        public struct ColorBlindModeButton
        {
            public ColorBlindMode.Mode mode;
            public GameObject buttonGO;
        }

        /// <summary>
        /// References to color blind mode buttons.
        /// </summary>
        public ColorBlindModeButton[] colorBlindModeButtons;

        /// <summary>
        /// Reference to ReferenceManager.
        /// </summary>
        private ReferenceManager reference;

        /// <summary>
        /// Reference to SettingsValues.
        /// </summary>
        private SettingsValues settingsValues;

        /// <summary>
        /// Find references. Get initial values for settings.
        /// </summary>
        private void Awake()
        {
            reference = FindObjectOfType<ReferenceManager>();
            menuTransitionManager = reference.menuTransitionManager;
            source = reference.mainCanvasAudioSource;
            settingsValues = reference.settingsValues;

            if (settingsValues.colorBlindMode == ColorBlindMode.Mode.Standard)
            {
                colorBlindModeToggle.isOn = false;
                foreach (ColorBlindModeButton button in colorBlindModeButtons)
                {
                    button.buttonGO.SetActive(false);
                }
            }
            else
            {
                colorBlindModeToggle.isOn = true;
                foreach (ColorBlindModeButton button in colorBlindModeButtons)
                {
                    button.buttonGO.SetActive(true);
                    if (button.mode == settingsValues.colorBlindMode)
                    {
                        button.buttonGO.GetComponent<UIHover>().Select();
                    }
                }
            }

            volumeSlider.value = settingsValues.masterVolume;
            tutorialToggle.isOn = settingsValues.tutorialOn;
        }

        /// <summary>
        /// Back button pressed. Navigate to Main Menu.
        /// </summary>
        public void PressBack()
        {
            source.PlayOneShot(reference.menuBack);
            settingsValues.SetPlayerPrefs();
            menuTransitionManager.Transition(backMenuGO);
        }

        /// <summary>
        /// Change AudioListener volume based on masterVolumeSlider value.
        /// </summary>
        public void AdjustMasterVolume(float value)
        {
            reference.settingsValues.SetMasterVolume(value);
        }

        /// <summary>
        /// Toggle whether color blind mode is active (using a non-standard mode).
        /// </summary>
        /// <param name="isOn">State of whether colorblind mode is standard.</param>
        public void ToggleColorBlindMode(bool isOn)
        {
            if (isOn)
            {
                foreach (ColorBlindModeButton button in colorBlindModeButtons)
                {
                    button.buttonGO.SetActive(true); 
                }

                colorBlindModeButtons[0].buttonGO.GetComponent<UIHover>().Select();
                SetColorBlindMode(colorBlindModeButtons[0].buttonGO);
            }
            else
            {
                foreach (ColorBlindModeButton button in colorBlindModeButtons)
                {
                    button.buttonGO.SetActive(false);
                    button.buttonGO.GetComponent<UIHover>().EndSelect();
                }

                settingsValues.SetColorBlindMode(ColorBlindMode.Mode.Standard);
            }
        }

        /// <summary>
        /// Set color blind mode from button.
        /// </summary>
        /// <param name="buttonGO">Game Object of button that was pressed.</param>
        public void SetColorBlindMode(GameObject buttonGO)
        {
            source.PlayOneShot(reference.menuSelect);

            foreach (ColorBlindModeButton button in colorBlindModeButtons)
            {
                if (button.buttonGO == buttonGO)
                {
                    button.buttonGO.GetComponent<UIHover>().Select();
                    settingsValues.SetColorBlindMode(button.mode);
                }
                else
                {
                    button.buttonGO.GetComponent<UIHover>().EndSelect();
                }
            }
        }

        /// <summary>
        /// Toggle whether tutorial mode will be played in future game sessions.
        /// </summary>
        /// <param name="isOn">State of whether tutorial is on.</param>
        public void ToggleTutorial(bool isOn)
        {
            settingsValues.SetTutorialOn(isOn);
        }
    }
}
