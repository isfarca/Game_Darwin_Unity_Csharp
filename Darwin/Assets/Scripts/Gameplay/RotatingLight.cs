using UnityEngine;

public class RotatingLight : MonoBehaviour {

	void Update () {
        transform.Rotate(0, 0, 120 * Time.deltaTime);
    }
}
