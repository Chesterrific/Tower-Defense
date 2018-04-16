using UnityEngine.UI;
using UnityEngine;

public class NodeUI : MonoBehaviour {

    private Node target;

    public GameObject ui;

	public void SetTarget(Node t)
    {
        target = t;
        transform.position = target.GetBuildPosition();
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
