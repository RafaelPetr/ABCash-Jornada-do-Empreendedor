using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ProductUI : MonoBehaviour {
    protected static bool isSelectingGalaxy;
    protected static int rumorDay;
    protected static UnityEvent productChangeEvent;
    protected static Product product;
    protected static Galaxy galaxy;

    [SerializeField]private ProductInfoDisplay productInfoDisplay;
    [SerializeField]private TextMeshProUGUI galaxyName;

    protected void Awake() {
        productChangeEvent = new UnityEvent();
        productChangeEvent.AddListener(productInfoDisplay.DisplayProduct);

        if (!isSelectingGalaxy) {
            product = null;
            galaxy = null;
        }
    }

    protected virtual void Start() {
        transform.SetAsFirstSibling();

        if (galaxy != null) {
            galaxyName.text = galaxy.GetName();
            productChangeEvent.Invoke();
        }

        isSelectingGalaxy = false;
    }

    public void SelectGalaxy() {
        isSelectingGalaxy = true;
        CompanyNavUI.SetBlockActive(true);
        SceneController.instance.Load("sc_universe");
    }

    public void Research() {
        Tendency tendency = galaxy.GetMarket().GetTendencies(product.GetId());
        tendency.Research(rumorDay);
        productChangeEvent.Invoke();
    }

    public void Exit() {
        SceneController.instance.Load("sc_branch_creation");
    }

    #region Getters

        public static bool GetIsSelectingGalaxy() {
            return isSelectingGalaxy;
        }

        public static Product GetProduct() {
            return product;
        }

        public static Galaxy GetGalaxy() {
            return galaxy;
        }

    #endregion

    #region Setters

        public static void SetProduct(Product value) {
            product = value;
            productChangeEvent.Invoke();
        }

        public static void SetGalaxy(Galaxy value) {
            galaxy = value;
        }

    #endregion
}
