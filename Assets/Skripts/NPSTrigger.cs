using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class NPSTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textFirstNPS;
    [SerializeField] private PlayableDirector director;

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("NPSFirst"))
        {
            textFirstNPS.text = "ֽאזלטעו ֵ";

            if (Input.GetKey(KeyCode.E))
                director.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NPSFirst"))
        {
            textFirstNPS.text = "";
        }
    }
}
