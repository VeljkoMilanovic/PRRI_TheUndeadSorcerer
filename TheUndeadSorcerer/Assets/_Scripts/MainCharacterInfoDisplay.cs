using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainCharacterInfoDisplay : MonoBehaviour
{
    public GameCharacter mainCharacter;
    public Image characterImage;
    public TextMeshProUGUI characterName;

    // Start is called before the first frame update
    void Start()
    {
        characterImage.sprite = mainCharacter.image;
        characterName.text = mainCharacter.name;
    }
}
