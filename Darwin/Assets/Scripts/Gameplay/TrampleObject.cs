using UnityEngine;

public class TrampleObject : MonoBehaviour 
{
    [SerializeField] private SpecialAbilities _specialAbilitiesScript;

    private void OnCollisionStay2D()
    {
        if (_specialAbilitiesScript.ElephantActive)
            Destroy(gameObject);
    }
}
