using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class Cards : MonoBehaviour
{

    public FPSFire gun;
    public RawImage currentCard;


    enum cards
    {
        normal = 0,
        fireball = 1,
        flamethrower = 2,
        shotgun = 3,
        machinegun = 4,
        autoshot = 5,
        bomb = 6,
        laser = 7,
        final = 8
    }

    public RawImage[] handImages;
    public int[] hand;
    public Texture[] CardImages;
    public int selectedCard;
    public RectTransform selectionPanel;



    // Use this for initialization
    void Start()
    {
        selectedCard = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");

        
        if (wheelInput != 0)
        {
            selectedCard += (int)Mathf.Sign(wheelInput);
            if (selectedCard > 2)
            {
                selectedCard = 0;
            }
            else if (selectedCard < 0)
            {
                selectedCard = 2;
            }

            RectTransform selectHand = handImages[selectedCard].GetComponent<RectTransform>();

            selectionPanel.position = selectHand.position;
        }

        if (Input.GetMouseButtonDown(1))
        {
            LoadCard((cards)hand[selectedCard]);
        }




    }

    void LoadCard(cards card) //load a card into the Gun
    {
        currentCard.texture = ChooseCard((int)card);
        DrawCard(selectedCard);
        gun.GunChange((int)card);
    }

    int DrawCard (int goneCard) //grab random card to replace loaded one
    {

        
        int newCard = Random.Range(0, 9);
        hand[goneCard] = newCard;
        handImages[goneCard].texture = ChooseCard(newCard);

        return newCard;
    }

    public Texture ChooseCard (int chosen) //return a specific card
    {
        return CardImages[chosen];
    }



}
