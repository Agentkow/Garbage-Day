using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject selectedObject;
    private Button selectedButton;

    private bool buttonSelected;

	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Vertical") !=0 && buttonSelected == false)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
            selectedButton = selectedObject.GetComponent<Button>();
        }
        if (buttonSelected && Input.GetButton("Submit"))
        {
            selectedButton.onClick.Invoke();
        }

	}

    private void OnDisable()
    {
        buttonSelected = false;
    }
}
