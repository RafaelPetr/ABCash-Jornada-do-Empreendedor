using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GalaxyDisplay : MonoBehaviour {
    private Galaxy galaxy;

    [SerializeField]private GameObject infoElements;

    [SerializeField]private TextMeshProUGUI galaxyName;

    [SerializeField]private Button galaxyButton;
    [SerializeField]private Button createButton;
    [SerializeField]private Button enterButton;

    private void Start() {
        galaxyButton.interactable = false;
        galaxyButton.interactable = true;
        
        galaxyName.text = $"Galáxia {galaxy.GetX()},{galaxy.GetY()}";

        if (galaxy.GetHasBranch()) {
            ChangeColors();
            enterButton.gameObject.SetActive(true);
        }
        else {
            createButton.gameObject.SetActive(true);
        }
    }

    private void ChangeColors() {
        ColorBlock colors = galaxyButton.colors;
        colors.normalColor = new Color(0,1,0,1);
        colors.highlightedColor = new Color(0,0.78f,0,1);
        colors.pressedColor = new Color(0,0.45f,0,1);
        colors.selectedColor = new Color(0,0.78f,0,1);
        colors.disabledColor = new Color(0,0.2f,0,0.5f);

        galaxyButton.colors = colors;
    }

    public void Select() {
        BranchCreationMenu.LoadDisplay(this);
        infoElements.SetActive(true);
    }

    public void Deselect() {
        infoElements.SetActive(false);
    }

    public void Create() {
        SceneController.instance.Load("sc_branch_create");
    }

    public void Enter() {
        Company.SetCurrentBranchId(galaxy.GetId());
        SceneController.instance.Load("sc_branch_sectors");
    }

    #region Getters

        public Galaxy GetGalaxy() {
            return galaxy;
        }

    #endregion

    #region Setters

        public void SetGalaxy(Galaxy galaxy) {
            this.galaxy = galaxy;
            
            if (galaxy.GetHasBranch()) {
                ChangeColors();
            }
        }

    #endregion
}
