//=============================================================================
//
// Chad Johnson
// 1763718
// johns428@mail.chapman.edu
// CPSC-440-1
// Group Project
//
// MenuTransitionManager controls transitions between menus and tracks the
// currently active menu.
//
//=============================================================================

using UnityEngine;
using Game;

namespace Menus
{
    /// <summary>
    /// Transition between menus.
    /// </summary>
    public class MenuTransitionManager : MonoBehaviour
    {
        /// <summary>
        /// Reference to currently active menu.
        /// </summary>
        public GameObject currMenu;

        /// <summary>
        /// Reference to ReferenceManager;
        /// </summary>
        private ReferenceManager reference;

        /// <summary>
        /// Reference to main menu gameobject.
        /// </summary>
        private GameObject mainMenuGO;

        /// <summary>
        /// Find references.
        /// </summary>
        private void Awake()
        {
            reference = FindObjectOfType<ReferenceManager>();
            mainMenuGO = reference.mainMenuGO;
        }

        /// <summary>
        /// Deactivate current menu and activate next menu. Save next menu as current menu.
        /// </summary>
        /// <param name="nextMenu"></param>
        public void Transition(GameObject nextMenu)
        {
            currMenu.SetActive(false);
            nextMenu.SetActive(true);
            currMenu = nextMenu;
        }

        /// <summary>
        /// Transition to Main Menu. Meant to be called when gameplay ends.
        /// </summary>
        public void GoToMain()
        {
            mainMenuGO.SetActive(true);
            currMenu = mainMenuGO;
        }
    }
}
