using UnityEngine;
using UnityEngine.UI;

public class QuitApplication : MonoBehaviour {

	void Start () {
        GetComponent<Button>().onClick.AddListener(QuitCalculator);
	}
	
    void QuitCalculator(){
        Application.Quit();
    }
}
