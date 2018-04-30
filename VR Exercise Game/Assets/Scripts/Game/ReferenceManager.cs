﻿
using UnityEngine;
using Menus;
using Player;
using Valve.VR.InteractionSystem;

namespace Game
{
    public class ReferenceManager : MonoBehaviour
    {
        [Header("Game")]
        public GameValues gameValues;
        public Spawner spawner;
        public Score score;

        [Header("Environment")]
        public GameObject environmentGO;
        public Material defaultSkybox;
        public Material spaceSkybox;

        [Header("Settings")]
        public SettingsValues settingsValues;
        public ColorBlindMode colorBlindMode;

        [Header("Audio")]
        public AudioSource mainCanvasAudioSource;
        public AudioClip menuSelect;
        public AudioClip menuBack;
        public AudioClip uiHover;

        [Header("Player")]
        public GameObject playerGO;
        public GameObject cameraGO;
        public Hand[] hands;

        [Header("Menus and UI")]
        public MenuTransitionManager menuTransitionManager;
        public GameObject mainCanvasGO;
        public GameObject mainMenuGO;
        public GameObject settingsMenuGO;
        public GameObject startMenuGO;

        [Header("Tutorial")]
        public Tutorial tutorial;
    }
}
