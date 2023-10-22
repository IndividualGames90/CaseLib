using TMPro;
using UnityEngine;

namespace IndividualGames.CaseLib.UI
{
    /// <summary>
    /// Label specific unity hook for UIChangeable
    /// </summary>
    public class LabelChangeable : UIChangeable<string>
    {
        [SerializeField] private TextMeshProUGUI tmpUGUI;

        private void Awake()
        {
            Init();
        }

        public override void OnChange(string changedValue)
        {
            tmpUGUI.text = changedValue.ToString();
        }
    }
}