using System.Collections;
using System.Collections.Generic;
using Game;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Menus
{
    public class Tutorial : MonoBehaviour
    {
        [TextArea]
        public List<string> menuTexts;

        public List<AudioClip> menuClips;

        public List<Button> menuButtons;

        [TextArea]
        public List<string> gameTexts;

        public List<AudioClip> gameClips;

        public List<Button> gameButtons;

        private Hand[] hands;

        private ReferenceManager reference;

        public Text tutorialText;

        public AudioSource audioSource;

        private int stageIndex = 0;

        public enum TutorialStage
        {
            Menus,
            Gameplay
        }

        public enum Button
        {
            Trigger = EVRButtonId.k_EButton_SteamVR_Trigger,
            Touchpad = EVRButtonId.k_EButton_SteamVR_Touchpad,
            Menu = EVRButtonId.k_EButton_ApplicationMenu,
            None
        }

        private TutorialStage tutorialStage;

        private List<string> currTexts;

        private List<AudioClip> currClips;

        private List<Button> currButtons;

        // Use this for initialization
        void Awake()
        {
            reference = FindObjectOfType<ReferenceManager>();
            hands = reference.hands;
            SwitchStages(TutorialStage.Menus);
            ShowInStage();
        }

        // Update is called once per frame
        void Update()
        {
            foreach (Hand hand in hands)
            {
                if (hand.controller != null && hand.controller
                    .GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    stageIndex++;
                    if (stageIndex < currTexts.Count)
                    {
                        ShowInStage();
                    }
                    else if (tutorialStage == TutorialStage.Gameplay)
                    {
                        audioSource.Stop();
                        reference.spawner.gameObject.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }
            }
        }

        public void SwitchStages(TutorialStage newStage)
        {
            tutorialStage = newStage;
            stageIndex = 0;

            switch (tutorialStage)
            {
                case TutorialStage.Menus:
                    currTexts = menuTexts;
                    currClips = menuClips;
                    currButtons = menuButtons;
                    break;
                case TutorialStage.Gameplay:
                    currTexts = gameTexts;
                    currClips = gameClips;
                    currButtons = gameButtons;
                    break;
            }
        }

        public void ShowInStage()
        {
            tutorialText.text = currTexts[stageIndex];
            audioSource.Stop();
            audioSource.PlayOneShot(currClips[stageIndex]);

            foreach (Hand hand in hands)
            {
                ControllerButtonHints.HideAllButtonHints(hand);

                if (currButtons[stageIndex] != Button.None)
                {
                    ControllerButtonHints.ShowButtonHint(hand, (EVRButtonId)currButtons[stageIndex]);        
                }
            }
        }
    }
}
