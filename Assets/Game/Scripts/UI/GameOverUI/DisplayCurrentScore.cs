using TMPro;
using UnityEngine;

public class DisplayCurrentScore : MonoBehaviour
{
    [SerializeField] private DisplayTime displayTime; 
    private TextMeshProUGUI _currentScore;
    
    private void Start()
    {
        _currentScore = GetComponent<TextMeshProUGUI>();
        _currentScore.text = displayTime.timeText.text + "s";
    }
}
