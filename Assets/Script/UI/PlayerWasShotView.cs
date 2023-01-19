using UnityEngine;
using TMPro;

public class PlayerWasShotView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerWasShotText;

    public void UpdatePlayerWasShotText(int wasShot)
    {
        string st = wasShot.ToString() + "回当たったよ";
        playerWasShotText.text = st;
    }
}
