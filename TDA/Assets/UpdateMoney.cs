using UnityEngine.UI;
using UnityEngine;

public class UpdateMoney : MonoBehaviour
{
    public Text Money;
    // Update is called once per frame
    void Update()
    {
        Money.text = "$" + PlayerStats.Money.ToString();
    }
}
