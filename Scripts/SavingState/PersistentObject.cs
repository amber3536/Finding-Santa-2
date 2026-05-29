using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    [SerializeField]
    private string uniqueId;

    public string UniqueId => uniqueId;
}