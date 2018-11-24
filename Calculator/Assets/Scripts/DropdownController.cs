using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownController : MonoBehaviour {

    private Dropdown thisDropdown;
    private void Start()
    {
        thisDropdown = GetComponent<Dropdown>();
        thisDropdown.onValueChanged.AddListener(delegate { ChangeLocation(); });
    }

    private void ChangeLocation(){
        GetComponentInParent<SportButtonController>().UpdateLocation(thisDropdown.value);
    }
}
