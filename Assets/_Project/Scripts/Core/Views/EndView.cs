using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndView : MonoBehaviour
{
    [field: SerializeField] public TMP_Text TextScore { get; private set;  }
    [field: SerializeField] public Button ButtonMenu { get; private set;  }
    [field: SerializeField] public Button ButtonReplay { get; private set;  }
}
