using IndividualGames.CaseLib.DI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IndividualGames.CaseLib.UI
{
    /// <summary> Changeable data containing label and color. </summary> 
    public struct LabelAndMaterialChangeableData : IChangeableData
    {
        public string text;
        public Material material;
    }

    /// <summary> Label specific unity hook for UIChangeable with color. </summary>
    public class LabelAndMaterialChangeable : UIChangeable<LabelAndMaterialChangeableData>
    {
        [SerializeField] private TextMeshProUGUI tmpUGUI;
        [SerializeField] private Image backgroundImage;

        private void Awake()
        {
            Init();
        }

        public override void OnChange(LabelAndMaterialChangeableData changedValue)
        {
            if (backgroundImage.material != changedValue.material)
            {
                backgroundImage.material = changedValue.material;
                backgroundImage.color = changedValue.material.color;
            }
            tmpUGUI.text = changedValue.text.ToString();
        }
    }
}