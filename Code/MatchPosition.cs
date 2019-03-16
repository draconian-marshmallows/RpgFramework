using UnityEngine;

public class MatchPosition : MonoBehaviour
{
    [SerializeField] private Transform parenTransform;

    private void Update()
    {
        transform.position = parenTransform.position;
    }
}
