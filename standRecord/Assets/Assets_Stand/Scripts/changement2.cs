using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changement2 : MonoBehaviour
{
    //character declaration
    public GameObject character;

    //tableaux des cagettes C1 a C4
    public GameObject[] Cagette1, Cagette2, Cagette3, Cagette4;

    //Declaration des fruits de 1 a 8 en fonction des cagettes C1 � C4
    public GameObject C1_F1, C1_F2, C1_F3, C1_F4, C1_F5, C1_F6, C1_F7, C1_F8;
    public GameObject C2_F1, C2_F2, C2_F3, C2_F4, C2_F5, C2_F6, C2_F7, C2_F8;
    public GameObject C3_F1, C3_F2, C3_F3, C3_F4, C3_F5, C3_F6, C3_F7, C3_F8;
    public GameObject C4_F1, C4_F2, C4_F3, C4_F4, C4_F5, C4_F6, C4_F7, C4_F8;

    //Declaration des listes de courses
    public GameObject[] listes;
    public GameObject L1, L2, L3, L4, L5, L6, L7, L8, L9;
    public int nbMouseClick;
    public int indice;

    //variables de calibrage
    public GameObject[] calibs;
    public GameObject calibC1, calibC2, calibC3, calibC4, calibG;
    //public GameObject calibL ; //non utilise

    // Valeur precedente pour la fonction update
    float previousValue = 0f;

    // Start is called before the first frame update
    void Start()
    {
        nbMouseClick = 0;
        indice = 0;
        Cagette1 = new GameObject[] { C1_F1, C1_F2, C1_F3, C1_F4, C1_F5, C1_F6, C1_F7, C1_F8 };
        Cagette2 = new GameObject[] { C2_F1, C2_F2, C2_F3, C2_F4, C2_F5, C2_F6, C2_F7, C2_F8 };
        Cagette3 = new GameObject[] { C3_F1, C3_F2, C3_F3, C3_F4, C3_F5, C3_F6, C3_F7, C3_F8 };
        Cagette4 = new GameObject[] { C4_F1, C4_F2, C4_F3, C4_F4, C4_F5, C4_F6, C4_F7, C4_F8 };
        listes = new GameObject[] { L1, L2, L3, L4, L5, L6, L7, L8, L9 };
        calibs = new GameObject[] { calibC1, calibC2, calibC3, calibC4, calibG };

    }
    
    void update()
    {

    }

    public void updateStand(float on)
    {
        Debug.Log(on);
        if (on == 1 && previousValue != on)
        {
            if (nbMouseClick < 5)
            {
                calibs[nbMouseClick].SetActive(true);
                if (nbMouseClick != 0)
                {
                    calibs[nbMouseClick - 1].SetActive(false);
                }
            }
            else
            {
                //desaffichage calibsG
                calibs[4].SetActive(false);

                //cycle sur 0 � 7 => si 0 : verification activeSelf des F8
                indice = (nbMouseClick - 5) % 9;
                if (indice == 0)
                {
                    Cagette1[0].SetActive(true);
                    Cagette2[0].SetActive(true);
                    Cagette3[0].SetActive(true);
                    Cagette4[0].SetActive(true);
                    listes[0].SetActive(true);
                    character.SetActive(true);

                    //deactivation des cagettes 7
                    if (Cagette1[7].activeSelf)
                    {
                        Cagette1[7].SetActive(false);
                        Cagette2[7].SetActive(false);
                        Cagette3[7].SetActive(false);
                        Cagette4[7].SetActive(false);
                        listes[7].SetActive(false);
                    }
                }
                else if (indice < 8)
                {
                    // enlever affichage elements en cours
                    Cagette1[indice - 1].SetActive(false);
                    Cagette2[indice - 1].SetActive(false);
                    Cagette3[indice - 1].SetActive(false);
                    Cagette4[indice - 1].SetActive(false);
                    listes[indice - 1].SetActive(false);

                    // affichage elements suivant
                    Cagette1[indice].SetActive(true);
                    Cagette2[indice].SetActive(true);
                    Cagette3[indice].SetActive(true);
                    Cagette4[indice].SetActive(true);
                    listes[indice].SetActive(true);
                } else
                {
                    // enlever affichage elements en cours
                    Cagette1[indice - 1].SetActive(false);
                    Cagette2[indice - 1].SetActive(false);
                    Cagette3[indice - 1].SetActive(false);
                    Cagette4[indice - 1].SetActive(false);
                    listes[indice - 1].SetActive(false);

                    // affichage elements suivant
                    Cagette1[1].SetActive(true);
                    Cagette2[2].SetActive(true);
                    Cagette3[3].SetActive(true);
                    Cagette4[4].SetActive(true);
                    listes[indice].SetActive(true);
                }
            }
            //actualisation du nb de clicks
            nbMouseClick += 1;
        }
        previousValue = on; 
    }
}
