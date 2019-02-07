using UnityEngine;

public class ChargeObject : MonoBehaviour
{
    [SerializeField] private SpecialAbilities _specialAbilitiesScript;

    private void OnCollisionStay2D()
    {
        if (_specialAbilitiesScript.RhinoActive)
            Destroy(gameObject);
    }
}