using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum BattleState { START , PLAYERTURN, ENEMYTURN, WON, LOST }


public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject kingSlimeGO;
    public GameObject SlimeGO;
    public GameObject BatGO;

    Unit playerUnit;
    Unit enemy1Unit;
    Unit enemy2Unit;
    Unit enemy3Unit;

    public BattleHUD playerHUD;
    public BattleHUD enemy1HUD;
    public BattleHUD enemy2HUD;
    public BattleHUD enemy3HUD;

    public GameObject playerHUDG;
    public GameObject enemy1HUDG;
    public GameObject enemy2HUDG;
    public GameObject enemy3HUDG;

    public GameObject hitEffect1_King;
    public GameObject hitEffect2_King;
    public GameObject hitEffect3_King;
    public GameObject hitEffect4_King;
    public GameObject hitEffect5_King;
    public GameObject hitEffect6_King;
    public GameObject hitEffect7_King;
    public GameObject hitEffect8_King;
    public GameObject hitEffect9_King;

    public GameObject hitEffect1_Slime;
    public GameObject hitEffect2_Slime;
    public GameObject hitEffect3_Slime;
    public GameObject hitEffect4_Slime;
    public GameObject hitEffect5_Slime;
    public GameObject hitEffect6_Slime;
    public GameObject hitEffect7_Slime;
    public GameObject hitEffect8_Slime;
    public GameObject hitEffect9_Slime;

    public GameObject hitEffect1_Bat;
    public GameObject hitEffect2_Bat;
    public GameObject hitEffect3_Bat;
    public GameObject hitEffect4_Bat;
    public GameObject hitEffect5_Bat;
    public GameObject hitEffect6_Bat;
    public GameObject hitEffect7_Bat;
    public GameObject hitEffect8_Bat;
    public GameObject hitEffect9_Bat;

    public GameObject fire1_King;
    public GameObject fire2_King;
    public GameObject fire3_King;
    public GameObject fire1_Slime;
    public GameObject fire2_Slime;
    public GameObject fire3_Slime;
    public GameObject fire1_Bat;
    public GameObject fire2_Bat;
    public GameObject fire3_Bat;

    public GameObject ice1_King;
    public GameObject ice2_King;
    public GameObject ice3_King;
    public GameObject ice4_King;
    public GameObject ice5_King;
    public GameObject ice6_King;
    public GameObject ice7_King;
    public GameObject ice8_King;
    public GameObject ice9_King;

    public GameObject ice1_Slime;
    public GameObject ice2_Slime;
    public GameObject ice3_Slime;
    public GameObject ice4_Slime;
    public GameObject ice5_Slime;
    public GameObject ice6_Slime;
    public GameObject ice7_Slime;
    public GameObject ice8_Slime;
    public GameObject ice9_Slime;

    public GameObject ice1_Bat;
    public GameObject ice2_Bat;
    public GameObject ice3_Bat;
    public GameObject ice4_Bat;
    public GameObject ice5_Bat;
    public GameObject ice6_Bat;
    public GameObject ice7_Bat;
    public GameObject ice8_Bat;
    public GameObject ice9_Bat;

    public GameObject monsterHit1;
    public GameObject monsterHit2;
    public GameObject monsterHit3;
    public GameObject monsterHit4;

    
    public Animator Grenade;
   



    public GameObject attackButton;
    public GameObject singleTargetButton;
    public GameObject singleTargetFire;
    public GameObject singleTargetIce;
    public GameObject goback1;
    public GameObject goback2;
    public GameObject goback3;
    public GameObject goback4;
    public GameObject goback5;
    public GameObject goback6;
    public GameObject goback7;
    public GameObject goback8;
    public GameObject player;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy1_double;
    public GameObject enemy2_double;
    public GameObject enemy3_double;
    public GameObject enemy1_fire;
    public GameObject enemy2_fire;
    public GameObject enemy3_fire;
    public GameObject enemy1_ice;
    public GameObject enemy2_ice;
    public GameObject enemy3_ice;
    public GameObject enemy1_iceAOE;
    public GameObject enemy2_iceAOE;
    public GameObject enemy3_iceAOE;
    public GameObject enemy1_Heal;
    public GameObject enemy2_Heal;
    public GameObject enemy3_Heal;
    public GameObject enemy1_Nade;
    public GameObject enemy2_Nade;
    public GameObject enemy3_Nade;


    public GameObject fireButton;
    public GameObject dialogue;
    public GameObject combatButtons;
    public GameObject combatButtons2;
    public GameObject combatButtons3;
    public GameObject combatButtonsDouble;
    public GameObject magicButtons;
    public GameObject magicButtons2;
    public GameObject magicButtons3;
    public GameObject magicButtons4;
    public GameObject magicButtonsIce;
    public GameObject magicButtonsFire;
    public GameObject useItemButton;
    public GameObject healButton;
    public GameObject useItemButtons;
    public GameObject healButtons;
    public GameObject nadeButtons;

    public GameObject playerGO;
    public GameObject _KingSlimeGO;
    public GameObject _SlimeGO;
    public GameObject _BatGO;

    public Text dialogueText;
    public Text potText;
    public Text nadeText;

    public Color wantedcolor;
    public Button king;
    public Button slime;
    public Button bat;

    public Button king2;
    public Button slime2;
    public Button bat2;

    public int enemiesDead = 0;
    public int selected1 = 0;
    public int selected2 = 0;
    public int selected3 = 0;
    public int selected4 = 0;
    public int selected5 = 0;
    public int potCounter = 0;
    public int nadeCounter = 0;

    public string potNumb;
    public string nadeNumb;
    

    public bool isDead;
    public bool isDead2;
    public bool isDead3;
    

    public BattleState state;
    
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;

        playerGO = Instantiate(playerPrefab);
        playerUnit = playerGO.GetComponent<Unit>();

        _KingSlimeGO = Instantiate(kingSlimeGO);
        enemy1Unit = _KingSlimeGO.GetComponent<Unit>();

        _SlimeGO = Instantiate(SlimeGO);
        enemy2Unit = _SlimeGO.GetComponent<Unit>();

        _BatGO = Instantiate(BatGO);
        enemy3Unit = _BatGO.GetComponent<Unit>();
        StartCoroutine(SetupBattle());
       
    }

    


    IEnumerator SetupBattle()
    {
       

        dialogueText.text = "Enemies have appeared!!!";

        playerHUD.SetHUD(playerUnit);
        enemy1HUD.SetHUD(enemy1Unit);
        enemy2HUD.SetHUD(enemy2Unit);
        enemy3HUD.SetHUD(enemy3Unit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttackKingSlime()
    {
        combatButtons3.SetActive(false);
        combatButtonsDouble.SetActive(false);

        if (selected1 == 1 && selected2 == 2)
        {
            if (enemy1Unit.currentHP > 0)
            {
                playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);
                yield return new WaitForSeconds(0.04f);
                playerGO.transform.Translate(new Vector3(0.4f, 0.4f), Space.World);
                yield return new WaitForSeconds(0.04f);
                playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);

                hitEffect1_King.SetActive(true);
                isDead = enemy1Unit.TakeDamage(playerUnit.damage);

                yield return new WaitForSeconds(0.02f);
                hitEffect2_King.SetActive(true);
                yield return new WaitForSeconds(0.02f);
                hitEffect3_King.SetActive(true);
                yield return new WaitForSeconds(0.02f);
                hitEffect4_King.SetActive(true);
                yield return new WaitForSeconds(0.04f);
                hitEffect5_King.SetActive(true);
                hitEffect1_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect6_King.SetActive(true);
                hitEffect2_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect7_King.SetActive(true);
                hitEffect3_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect8_King.SetActive(true);
                hitEffect4_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect9_King.SetActive(true);
                hitEffect5_King.SetActive(false);

                enemy1HUD.SetHP(enemy1Unit.currentHP);

                yield return new WaitForSeconds(0.04f);
                hitEffect6_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect7_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect8_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect9_King.SetActive(false);
            }
            if (enemy2Unit.currentHP > 0)
            {
                playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);
                yield return new WaitForSeconds(0.04f);
                playerGO.transform.Translate(new Vector3(0.4f, 0.4f), Space.World);
                yield return new WaitForSeconds(0.04f);
                playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);

                hitEffect1_Slime.SetActive(true);
                isDead2 = enemy2Unit.TakeDamage(playerUnit.damage);

                yield return new WaitForSeconds(0.02f);
                hitEffect2_Slime.SetActive(true);
                yield return new WaitForSeconds(0.02f);
                hitEffect3_Slime.SetActive(true);
                yield return new WaitForSeconds(0.02f);
                hitEffect4_Slime.SetActive(true);
                yield return new WaitForSeconds(0.04f);
                hitEffect5_Slime.SetActive(true);
                hitEffect1_Slime.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect6_Slime.SetActive(true);
                hitEffect2_Slime.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect7_Slime.SetActive(true);
                hitEffect3_Slime.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect8_Slime.SetActive(true);
                hitEffect4_Slime.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect9_Slime.SetActive(true);
                hitEffect5_Slime.SetActive(false);

                enemy2HUD.SetHP(enemy2Unit.currentHP);

                yield return new WaitForSeconds(0.04f);
                hitEffect6_Slime.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect7_Slime.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect8_Slime.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect9_Slime.SetActive(false);

            }
            

            dialogueText.text = "The attack is succesful!";

            

            yield return new WaitForSeconds(1f);

            if (isDead && isDead2)
            {
                dialogueText.text = enemy1Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;
                enemiesDead++;

                

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy1.SetActive(false);
                enemy1HUDG.SetActive(false);
                _KingSlimeGO.SetActive(false);
                enemy1_double.SetActive(false);
                enemy1_fire.SetActive(false);
                enemy1_ice.SetActive(false);
                enemy1_iceAOE.SetActive(false);
                enemy1_Heal.SetActive(false);
                enemy1_Nade.SetActive(false);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }
            else if (isDead)
            {

                dialogueText.text = enemy1Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy1.SetActive(false);
                enemy1HUDG.SetActive(false);
                _KingSlimeGO.SetActive(false);
                enemy1_double.SetActive(false);
                enemy1_fire.SetActive(false);
                enemy1_ice.SetActive(false);
                enemy1_iceAOE.SetActive(false);
                enemy1_Heal.SetActive(false);
                enemy1_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);


            }
            else if (isDead2)
            { 
                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }

                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            
        }
        else if (selected1 == 1 && selected3 == 3)
        {

            if (enemy1Unit.currentHP > 0)
            {
                playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);
                yield return new WaitForSeconds(0.04f);
                playerGO.transform.Translate(new Vector3(0.4f, 0.4f), Space.World);
                yield return new WaitForSeconds(0.04f);
                playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);

                hitEffect1_King.SetActive(true);
                isDead = enemy1Unit.TakeDamage(playerUnit.damage);

                yield return new WaitForSeconds(0.02f);
                hitEffect2_King.SetActive(true);
                yield return new WaitForSeconds(0.02f);
                hitEffect3_King.SetActive(true);
                yield return new WaitForSeconds(0.02f);
                hitEffect4_King.SetActive(true);
                yield return new WaitForSeconds(0.04f);
                hitEffect5_King.SetActive(true);
                hitEffect1_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect6_King.SetActive(true);
                hitEffect2_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect7_King.SetActive(true);
                hitEffect3_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect8_King.SetActive(true);
                hitEffect4_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect9_King.SetActive(true);
                hitEffect5_King.SetActive(false);

                enemy1HUD.SetHP(enemy1Unit.currentHP);

                yield return new WaitForSeconds(0.04f);
                hitEffect6_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect7_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect8_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect9_King.SetActive(false);
            }
            if (enemy3Unit.currentHP > 0)
            {
                playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);
                yield return new WaitForSeconds(0.04f);
                playerGO.transform.Translate(new Vector3(0.4f, 0.4f), Space.World);
                yield return new WaitForSeconds(0.04f);
                playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);

                hitEffect1_Bat.SetActive(true);

                isDead3 = enemy3Unit.TakeDamage(playerUnit.damage);

                yield return new WaitForSeconds(0.02f);
                hitEffect2_Bat.SetActive(true);
                yield return new WaitForSeconds(0.02f);
                hitEffect3_Bat.SetActive(true);
                yield return new WaitForSeconds(0.02f);
                hitEffect4_Bat.SetActive(true);
                yield return new WaitForSeconds(0.04f);
                hitEffect5_Bat.SetActive(true);
                hitEffect1_Bat.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect6_Bat.SetActive(true);
                hitEffect2_Bat.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect7_Bat.SetActive(true);
                hitEffect3_Bat.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect8_Bat.SetActive(true);
                hitEffect4_Bat.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect9_Bat.SetActive(true);
                hitEffect5_Bat.SetActive(false);

                enemy3HUD.SetHP(enemy3Unit.currentHP);

                yield return new WaitForSeconds(0.04f);
                hitEffect6_Bat.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect7_Bat.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect8_Bat.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect9_Bat.SetActive(false);
            }


            dialogueText.text = "The attack is succesful!";

            yield return new WaitForSeconds(1f);

            if (isDead && isDead3)
            {
                dialogueText.text = enemy1Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy3Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy1.SetActive(false);
                enemy1HUDG.SetActive(false);
                _KingSlimeGO.SetActive(false);
                enemy1_double.SetActive(false);
                enemy1_fire.SetActive(false);
                enemy1_ice.SetActive(false);
                enemy1_iceAOE.SetActive(false);
                enemy1_Heal.SetActive(false);
                enemy1_Nade.SetActive(false);
                enemy3.SetActive(false);
                enemy3HUDG.SetActive(false);
                _BatGO.SetActive(false);
                enemy3_double.SetActive(false);
                enemy3_fire.SetActive(false);
                enemy3_ice.SetActive(false);
                enemy3_iceAOE.SetActive(false);
                enemy3_Heal.SetActive(false);
                enemy3_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }
            else if (isDead)
            {

                dialogueText.text = enemy1Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy1.SetActive(false);
                enemy1HUDG.SetActive(false);
                _KingSlimeGO.SetActive(false);
                enemy1_double.SetActive(false);
                enemy1_fire.SetActive(false);
                enemy1_ice.SetActive(false);
                enemy1_iceAOE.SetActive(false);
                enemy1_Heal.SetActive(false);
                enemy1_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);


            }
            else if (isDead3)
            {
                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy3Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy3.SetActive(false);
                enemy3HUDG.SetActive(false);
                _BatGO.SetActive(false);
                enemy3_double.SetActive(false);
                enemy3_fire.SetActive(false);
                enemy3_ice.SetActive(false);
                enemy3_iceAOE.SetActive(false);
                enemy3_Heal.SetActive(false);
                enemy3_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }


                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            
        }
        else if (selected2 == 2 && selected3 == 3)
        {

            if (enemy2Unit.currentHP > 0)
            {
                playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);
                yield return new WaitForSeconds(0.04f);
                playerGO.transform.Translate(new Vector3(0.4f, 0.4f), Space.World);
                yield return new WaitForSeconds(0.04f);
                playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);

                hitEffect1_Slime.SetActive(true);
                isDead2 = enemy2Unit.TakeDamage(playerUnit.damage);

                yield return new WaitForSeconds(0.02f);
                hitEffect2_Slime.SetActive(true);
                yield return new WaitForSeconds(0.02f);
                hitEffect3_Slime.SetActive(true);
                yield return new WaitForSeconds(0.02f);
                hitEffect4_Slime.SetActive(true);
                yield return new WaitForSeconds(0.04f);
                hitEffect5_Slime.SetActive(true);
                hitEffect1_Slime.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect6_Slime.SetActive(true);
                hitEffect2_Slime.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect7_Slime.SetActive(true);
                hitEffect3_Slime.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect8_Slime.SetActive(true);
                hitEffect4_Slime.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect9_Slime.SetActive(true);
                hitEffect5_Slime.SetActive(false);

                enemy2HUD.SetHP(enemy2Unit.currentHP);

                yield return new WaitForSeconds(0.04f);
                hitEffect6_Slime.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect7_Slime.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect8_Slime.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect9_Slime.SetActive(false);
            }
            if (enemy3Unit.currentHP > 0)
            {
                playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);
                yield return new WaitForSeconds(0.04f);
                playerGO.transform.Translate(new Vector3(0.4f, 0.4f), Space.World);
                yield return new WaitForSeconds(0.04f);
                playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);

                hitEffect1_Bat.SetActive(true);

                isDead3 = enemy3Unit.TakeDamage(playerUnit.damage);

                yield return new WaitForSeconds(0.02f);
                hitEffect2_Bat.SetActive(true);
                yield return new WaitForSeconds(0.02f);
                hitEffect3_Bat.SetActive(true);
                yield return new WaitForSeconds(0.02f);
                hitEffect4_Bat.SetActive(true);
                yield return new WaitForSeconds(0.04f);
                hitEffect5_Bat.SetActive(true);
                hitEffect1_Bat.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect6_Bat.SetActive(true);
                hitEffect2_Bat.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect7_Bat.SetActive(true);
                hitEffect3_Bat.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect8_Bat.SetActive(true);
                hitEffect4_Bat.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect9_Bat.SetActive(true);
                hitEffect5_Bat.SetActive(false);

                enemy3HUD.SetHP(enemy3Unit.currentHP);

                yield return new WaitForSeconds(0.04f);
                hitEffect6_Bat.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect7_Bat.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect8_Bat.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect9_Bat.SetActive(false);
            }
            
            

            dialogueText.text = "The attack is succesful!";

            yield return new WaitForSeconds(1f);

            if (isDead2 && isDead3)
            {
                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy3Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                enemy3.SetActive(false);
                enemy3HUDG.SetActive(false);
                _BatGO.SetActive(false);
                enemy3_double.SetActive(false);
                enemy3_fire.SetActive(false);
                enemy3_ice.SetActive(false);
                enemy3_iceAOE.SetActive(false);
                enemy3_Heal.SetActive(false);
                enemy3_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }
            else if (isDead2)
            {

                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);


            }        
            else if (isDead3)
            {
                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy3Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy3.SetActive(false);
                enemy3HUDG.SetActive(false);
                _BatGO.SetActive(false);
                enemy3_double.SetActive(false);
                enemy3_fire.SetActive(false);
                enemy3_ice.SetActive(false);
                enemy3_iceAOE.SetActive(false);
                enemy3_Heal.SetActive(false);
                enemy3_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }
            
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            
        }
        else if (selected1==1 && selected4==4 && selected5==5)
        {
            if (enemy1Unit.currentHP > 0)
            {
                playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);
                yield return new WaitForSeconds(0.04f);
                playerGO.transform.Translate(new Vector3(0.4f, 0.4f), Space.World);
                yield return new WaitForSeconds(0.04f);
                playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);

                hitEffect1_King.SetActive(true);
                isDead = enemy1Unit.TakeDamage(playerUnit.damage);

                yield return new WaitForSeconds(0.02f);
                hitEffect2_King.SetActive(true);
                yield return new WaitForSeconds(0.02f);
                hitEffect3_King.SetActive(true);
                yield return new WaitForSeconds(0.02f);
                hitEffect4_King.SetActive(true);
                yield return new WaitForSeconds(0.04f);
                hitEffect5_King.SetActive(true);
                hitEffect1_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect6_King.SetActive(true);
                hitEffect2_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect7_King.SetActive(true);
                hitEffect3_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect8_King.SetActive(true);
                hitEffect4_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect9_King.SetActive(true);
                hitEffect5_King.SetActive(false);

                enemy1HUD.SetHP(enemy1Unit.currentHP);

                yield return new WaitForSeconds(0.04f);
                hitEffect6_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect7_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect8_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect9_King.SetActive(false);
            }
            

       
            dialogueText.text = "The attack is succesful!";

            yield return new WaitForSeconds(1f);
       
            if (isDead)
            {
                dialogueText.text = enemy1Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();
                
                combatButtons.SetActive(true);
                enemy1.SetActive(false);
                enemy1HUDG.SetActive(false);
                _KingSlimeGO.SetActive(false);
                enemy1_double.SetActive(false);
                enemy1_fire.SetActive(false);
                enemy1_ice.SetActive(false);
                enemy1_iceAOE.SetActive(false);
                enemy1_Heal.SetActive(false);
                enemy1_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);

            }


            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }
        else if (selected2 == 2 && selected4 == 4 && selected5 == 5)
        {
            if (enemy2Unit.currentHP > 0)
            {
                playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);
                yield return new WaitForSeconds(0.04f);
                playerGO.transform.Translate(new Vector3(0.4f, 0.4f), Space.World);
                yield return new WaitForSeconds(0.04f);
                playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);

                hitEffect1_Slime.SetActive(true);
                isDead2 = enemy2Unit.TakeDamage(playerUnit.damage);

                yield return new WaitForSeconds(0.02f);
                hitEffect2_Slime.SetActive(true);
                yield return new WaitForSeconds(0.02f);
                hitEffect3_Slime.SetActive(true);
                yield return new WaitForSeconds(0.02f);
                hitEffect4_Slime.SetActive(true);
                yield return new WaitForSeconds(0.04f);
                hitEffect5_Slime.SetActive(true);
                hitEffect1_Slime.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect6_Slime.SetActive(true);
                hitEffect2_Slime.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect7_Slime.SetActive(true);
                hitEffect3_Slime.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect8_Slime.SetActive(true);
                hitEffect4_Slime.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect9_Slime.SetActive(true);
                hitEffect5_Slime.SetActive(false);

                enemy2HUD.SetHP(enemy2Unit.currentHP);

                yield return new WaitForSeconds(0.04f);
                hitEffect6_Slime.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect7_Slime.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect8_Slime.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect9_Slime.SetActive(false);
            }
            


            dialogueText.text = "The attack is succesful!";

            yield return new WaitForSeconds(1f);
    
            if (isDead2)
            {
                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();
                
                combatButtons.SetActive(true);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);

            }


            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }
        else if (selected3 == 3 && selected4 == 4 && selected5 == 5)
        {
            if (enemy3Unit.currentHP > 0)
            {
                playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);
                yield return new WaitForSeconds(0.04f);
                playerGO.transform.Translate(new Vector3(0.4f, 0.4f), Space.World);
                yield return new WaitForSeconds(0.04f);
                playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);

                hitEffect1_Bat.SetActive(true);

                isDead3 = enemy3Unit.TakeDamage(playerUnit.damage);

                yield return new WaitForSeconds(0.02f);
                hitEffect2_Bat.SetActive(true);
                yield return new WaitForSeconds(0.02f);
                hitEffect3_Bat.SetActive(true);
                yield return new WaitForSeconds(0.02f);
                hitEffect4_Bat.SetActive(true);
                yield return new WaitForSeconds(0.04f);
                hitEffect5_Bat.SetActive(true);
                hitEffect1_Bat.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect6_Bat.SetActive(true);
                hitEffect2_Bat.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect7_Bat.SetActive(true);
                hitEffect3_Bat.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect8_Bat.SetActive(true);
                hitEffect4_Bat.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect9_Bat.SetActive(true);
                hitEffect5_Bat.SetActive(false);

                enemy3HUD.SetHP(enemy3Unit.currentHP);

                yield return new WaitForSeconds(0.04f);
                hitEffect6_Bat.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect7_Bat.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect8_Bat.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect9_Bat.SetActive(false);
            }

 
            dialogueText.text = "The attack is succesful!";

            yield return new WaitForSeconds(1f);

            if (isDead3)
            {
                dialogueText.text = enemy3Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();
                
                combatButtons.SetActive(true);
                enemy3.SetActive(false);
                enemy3HUDG.SetActive(false);
                _BatGO.SetActive(false);
                enemy3_double.SetActive(false);
                enemy3_fire.SetActive(false);
                enemy3_ice.SetActive(false);
                enemy3_iceAOE.SetActive(false);
                enemy3_Heal.SetActive(false);
                enemy3_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);

            }


            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }
        else
        {
            if (enemy1Unit.currentHP > 0)
            {
                playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);
                yield return new WaitForSeconds(0.04f);
                playerGO.transform.Translate(new Vector3(0.4f, 0.4f), Space.World);
                yield return new WaitForSeconds(0.04f);
                playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);

                hitEffect1_King.SetActive(true);
                
                isDead = enemy1Unit.TakeDamage(playerUnit.damage);

                yield return new WaitForSeconds(0.02f);
                hitEffect2_King.SetActive(true);
                yield return new WaitForSeconds(0.02f);
                hitEffect3_King.SetActive(true);
                yield return new WaitForSeconds(0.02f);
                hitEffect4_King.SetActive(true);
                yield return new WaitForSeconds(0.04f);
                hitEffect5_King.SetActive(true);
                hitEffect1_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect6_King.SetActive(true);
                hitEffect2_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect7_King.SetActive(true);
                hitEffect3_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect8_King.SetActive(true);
                hitEffect4_King.SetActive(false);
                yield return new WaitForSeconds(0.04f);
                hitEffect9_King.SetActive(true);
                hitEffect5_King.SetActive(false);
            }
            

            enemy1HUD.SetHP(enemy1Unit.currentHP);
            
            yield return new WaitForSeconds(0.04f);
            hitEffect6_King.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            hitEffect7_King.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            hitEffect8_King.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            hitEffect9_King.SetActive(false);
            dialogueText.text = "The attack is succesful!";

            yield return new WaitForSeconds(1f);
            
            if (isDead)
            {
                dialogueText.text = enemy1Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();
                combatButtonsDouble.SetActive(false);
                combatButtons.SetActive(true);
                enemy1.SetActive(false);
                enemy1HUDG.SetActive(false);
                _KingSlimeGO.SetActive(false);
                enemy1_double.SetActive(false);
                enemy1_fire.SetActive(false);
                enemy1_ice.SetActive(false);
                enemy1_iceAOE.SetActive(false);
                enemy1_Heal.SetActive(false);
                enemy1_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);

            }
           
            
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            
        } 
    }

    IEnumerator PlayerAttackSlime()
    {
        
        combatButtons3.SetActive(false);

        if (enemy2Unit.currentHP > 0)
        {

            playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);
            yield return new WaitForSeconds(0.04f);
            playerGO.transform.Translate(new Vector3(0.4f, 0.4f), Space.World);
            yield return new WaitForSeconds(0.04f);
            playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);

            hitEffect1_Slime.SetActive(true);

            isDead2 = enemy2Unit.TakeDamage(playerUnit.damage);

            yield return new WaitForSeconds(0.02f);
            hitEffect2_Slime.SetActive(true);
            yield return new WaitForSeconds(0.02f);
            hitEffect3_Slime.SetActive(true);
            yield return new WaitForSeconds(0.02f);
            hitEffect4_Slime.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            hitEffect5_Slime.SetActive(true);
            hitEffect1_Slime.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            hitEffect6_Slime.SetActive(true);
            hitEffect2_Slime.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            hitEffect7_Slime.SetActive(true);
            hitEffect3_Slime.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            hitEffect8_Slime.SetActive(true);
            hitEffect4_Slime.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            hitEffect9_Slime.SetActive(true);
            hitEffect5_Slime.SetActive(false);
        }
         

        enemy2HUD.SetHP(enemy2Unit.currentHP);

        yield return new WaitForSeconds(0.04f);
        hitEffect6_Slime.SetActive(false);
        yield return new WaitForSeconds(0.04f);
        hitEffect7_Slime.SetActive(false);
        yield return new WaitForSeconds(0.04f);
        hitEffect8_Slime.SetActive(false);
        yield return new WaitForSeconds(0.04f);
        hitEffect9_Slime.SetActive(false);

        dialogueText.text = "The attack is succesful!";

        
        yield return new WaitForSeconds(1f);

        if (isDead2)
        {
            dialogueText.text = enemy2Unit.unitName + " was defeated!";

            yield return new WaitForSeconds(2f);

            enemiesDead++;
            state = BattleState.PLAYERTURN;
            PlayerTurn();
            combatButtons.SetActive(true);
            enemy2.SetActive(false);
            enemy2HUDG.SetActive(false);
            _SlimeGO.SetActive(false);
            enemy2_double.SetActive(false);
            enemy2_fire.SetActive(false);
            enemy2_ice.SetActive(false);
            enemy2_iceAOE.SetActive(false);
            enemy2_Heal.SetActive(false);
            enemy2_Nade.SetActive(false);
            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected object
            EventSystem.current.SetSelectedGameObject(attackButton);

        }
        
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        
    }

    IEnumerator PlayerAttackBat()
    {

        combatButtons3.SetActive(false);

        if (enemy3Unit.currentHP > 0)
        {
            playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);
            yield return new WaitForSeconds(0.04f);
            playerGO.transform.Translate(new Vector3(0.4f, 0.4f), Space.World);
            yield return new WaitForSeconds(0.04f);
            playerGO.transform.Translate(new Vector3(-0.2f, -0.2f), Space.World);

            hitEffect1_Bat.SetActive(true);

            isDead3 = enemy3Unit.TakeDamage(playerUnit.damage);

            yield return new WaitForSeconds(0.02f);
            hitEffect2_Bat.SetActive(true);
            yield return new WaitForSeconds(0.02f);
            hitEffect3_Bat.SetActive(true);
            yield return new WaitForSeconds(0.02f);
            hitEffect4_Bat.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            hitEffect5_Bat.SetActive(true);
            hitEffect1_Bat.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            hitEffect6_Bat.SetActive(true);
            hitEffect2_Bat.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            hitEffect7_Bat.SetActive(true);
            hitEffect3_Bat.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            hitEffect8_Bat.SetActive(true);
            hitEffect4_Bat.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            hitEffect9_Bat.SetActive(true);
            hitEffect5_Bat.SetActive(false);
        }
        

        enemy3HUD.SetHP(enemy3Unit.currentHP);

        yield return new WaitForSeconds(0.04f);
        hitEffect6_Bat.SetActive(false);
        yield return new WaitForSeconds(0.04f);
        hitEffect7_Bat.SetActive(false);
        yield return new WaitForSeconds(0.04f);
        hitEffect8_Bat.SetActive(false);
        yield return new WaitForSeconds(0.04f);
        hitEffect9_Bat.SetActive(false);

        dialogueText.text = "The attack is succesful!";

        yield return new WaitForSeconds(1f);

        if (isDead3)
        {
            dialogueText.text = enemy3Unit.unitName + " was defeated!";

            yield return new WaitForSeconds(2f);

            enemiesDead++;
            state = BattleState.PLAYERTURN;
            PlayerTurn();
            combatButtons.SetActive(true);
            enemy3.SetActive(false);
            enemy3HUDG.SetActive(false);
            _BatGO.SetActive(false);
            enemy3_double.SetActive(false);
            enemy3_fire.SetActive(false);
            enemy3_ice.SetActive(false);
            enemy3_iceAOE.SetActive(false);
            enemy3_Heal.SetActive(false);
            enemy3_Nade.SetActive(false);
            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected object
            EventSystem.current.SetSelectedGameObject(attackButton);

        }
        
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        
    }

    IEnumerator PlayerFireKingSlime()
    {
        magicButtons2.SetActive(false);

        if (enemy1Unit.currentHP > 0)
        {
            fire1_King.SetActive(true);
            isDead = enemy1Unit.TakeDamage(25);

            yield return new WaitForSeconds(0.1f);
            fire2_King.SetActive(true);

            yield return new WaitForSeconds(0.1f);
            fire3_King.SetActive(true);
            
        }

        enemy1HUD.SetHP(enemy1Unit.currentHP);
        yield return new WaitForSeconds(0.1f);
        fire3_King.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        fire2_King.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        fire1_King.SetActive(false);

       
        dialogueText.text = "The attack is succesful!";


        
        if (isDead)
        {
            dialogueText.text = enemy1Unit.unitName + " was defeated!";

            yield return new WaitForSeconds(1f);

            enemiesDead++;
            state = BattleState.PLAYERTURN;
            PlayerTurn();
            combatButtons.SetActive(true);
            enemy1.SetActive(false);
            enemy1HUDG.SetActive(false);
            _KingSlimeGO.SetActive(false);
            enemy1_double.SetActive(false);
            enemy1_fire.SetActive(false);
            enemy1_ice.SetActive(false);
            enemy1_iceAOE.SetActive(false);
            enemy1_Heal.SetActive(false);
            enemy1_Nade.SetActive(false);
            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected object
            EventSystem.current.SetSelectedGameObject(attackButton);

        }

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerFireSlime()
    {
        magicButtons2.SetActive(false);

        if (enemy2Unit.currentHP>0)
        {
            fire1_Slime.SetActive(true);
            isDead2 = enemy2Unit.TakeDamage(25);

            yield return new WaitForSeconds(0.1f);
            fire2_Slime.SetActive(true);

            yield return new WaitForSeconds(0.1f);
            fire3_Slime.SetActive(true);
        }
        

        enemy2HUD.SetHP(enemy2Unit.currentHP);
        yield return new WaitForSeconds(0.1f);
        fire3_Slime.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        fire2_Slime.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        fire1_Slime.SetActive(false);
        dialogueText.text = "The attack is succesful!";

        yield return new WaitForSeconds(2f);

        if (isDead2)
        {
            dialogueText.text = enemy2Unit.unitName + " was defeated!";

            yield return new WaitForSeconds(1f);

            enemiesDead++;
            state = BattleState.PLAYERTURN;
            PlayerTurn();
            combatButtons.SetActive(true);
            enemy2.SetActive(false);
            enemy2HUDG.SetActive(false);
            _SlimeGO.SetActive(false);
            enemy2_double.SetActive(false);
            enemy2_fire.SetActive(false);
            enemy2_ice.SetActive(false);
            enemy2_iceAOE.SetActive(false);
            enemy2_Heal.SetActive(false);
            enemy2_Nade.SetActive(false);
            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected object
            EventSystem.current.SetSelectedGameObject(attackButton);

        }

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerFireBat()
    {
        magicButtons2.SetActive(false);

        if (enemy3Unit.currentHP>0)
        {
            fire1_Bat.SetActive(true);
            isDead3 = enemy3Unit.TakeDamage(25);

            yield return new WaitForSeconds(0.1f);
            fire2_Bat.SetActive(true);

            yield return new WaitForSeconds(0.1f);
            fire3_Bat.SetActive(true);
        }
        

        enemy3HUD.SetHP(enemy3Unit.currentHP);
        yield return new WaitForSeconds(0.1f);
        fire3_Bat.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        fire2_Bat.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        fire1_Bat.SetActive(false);
        dialogueText.text = "The attack is succesful!";

        yield return new WaitForSeconds(2f);

        if (isDead3)
        {
            dialogueText.text = enemy3Unit.unitName + " was defeated!";

            yield return new WaitForSeconds(1f);

            enemiesDead++;
            state = BattleState.PLAYERTURN;
            PlayerTurn();
            combatButtons.SetActive(true);
            enemy3.SetActive(false);
            enemy3HUDG.SetActive(false);
            _BatGO.SetActive(false);
            enemy3_double.SetActive(false);
            enemy3_fire.SetActive(false);
            enemy3_ice.SetActive(false);
            enemy3_iceAOE.SetActive(false);
            enemy3_Heal.SetActive(false);
            enemy3_Nade.SetActive(false);
            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected object
            EventSystem.current.SetSelectedGameObject(attackButton);

        }

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerIceKingSlime()
    {
        magicButtons3.SetActive(false);

        if (enemy1Unit.currentHP>0)
        {
            ice1_King.SetActive(true);

            isDead = enemy1Unit.TakeDamage(15);

            yield return new WaitForSeconds(0.01f);
            ice2_King.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            ice3_King.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            ice4_King.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            ice5_King.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            ice6_King.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            ice7_King.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            ice8_King.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            ice9_King.SetActive(true);
            
        }


        enemy1HUD.SetHP(enemy1Unit.currentHP);

        yield return new WaitForSeconds(0.6f);
        ice9_King.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice8_King.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice7_King.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice6_King.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice5_King.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice4_King.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice3_King.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice2_King.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice1_King.SetActive(false);
        

        dialogueText.text = "The attack is succesful!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            dialogueText.text = enemy1Unit.unitName + " was defeated!";

            yield return new WaitForSeconds(1f);

            enemiesDead++;
            state = BattleState.PLAYERTURN;
            PlayerTurn();
            combatButtons.SetActive(true);
            enemy1.SetActive(false);
            enemy1HUDG.SetActive(false);
            _KingSlimeGO.SetActive(false);
            enemy1_double.SetActive(false);
            enemy1_fire.SetActive(false);
            enemy1_ice.SetActive(false);
            enemy1_iceAOE.SetActive(false);
            enemy1_Heal.SetActive(false);
            enemy1_Nade.SetActive(false);
            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected object
            EventSystem.current.SetSelectedGameObject(attackButton);

        }

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerIceSlime()
    {
        magicButtons3.SetActive(false);

        if (enemy2Unit.currentHP>0)
        {
            ice1_Slime.SetActive(true);

            isDead2 = enemy2Unit.TakeDamage(15);

            yield return new WaitForSeconds(0.01f);
            ice2_Slime.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            ice3_Slime.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            ice4_Slime.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            ice5_Slime.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            ice6_Slime.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            ice7_Slime.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            ice8_Slime.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            ice9_Slime.SetActive(true);

        }


        enemy2HUD.SetHP(enemy2Unit.currentHP);

        yield return new WaitForSeconds(0.6f);
        ice9_Slime.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice8_Slime.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice7_Slime.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice6_Slime.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice5_Slime.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice4_Slime.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice3_Slime.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice2_Slime.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice1_Slime.SetActive(false);

        dialogueText.text = "The attack is succesful!";

        yield return new WaitForSeconds(2f);

        if (isDead2)
        {
            dialogueText.text = enemy2Unit.unitName + " was defeated!";

            yield return new WaitForSeconds(1f);

            enemiesDead++;
            state = BattleState.PLAYERTURN;
            PlayerTurn();
            combatButtons.SetActive(true);
            enemy2.SetActive(false);
            enemy2HUDG.SetActive(false);
            _SlimeGO.SetActive(false);
            enemy2_double.SetActive(false);
            enemy2_fire.SetActive(false);
            enemy2_ice.SetActive(false);
            enemy2_iceAOE.SetActive(false);
            enemy2_Heal.SetActive(false);
            enemy2_Nade.SetActive(false);
            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected object
            EventSystem.current.SetSelectedGameObject(attackButton);

        }

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerIceBat()
    {
        magicButtons3.SetActive(false);

        if (enemy3Unit.currentHP>0)
        {
            ice1_Bat.SetActive(true);

            isDead3 = enemy3Unit.TakeDamage(15);

            yield return new WaitForSeconds(0.01f);
            ice2_Bat.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            ice3_Bat.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            ice4_Bat.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            ice5_Bat.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            ice6_Bat.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            ice7_Bat.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            ice8_Bat.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            ice9_Bat.SetActive(true);

        }


        enemy3HUD.SetHP(enemy3Unit.currentHP);

        yield return new WaitForSeconds(0.6f);
        ice9_Bat.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice8_Bat.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice7_Bat.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice6_Bat.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice5_Bat.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice4_Bat.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice3_Bat.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice2_Bat.SetActive(false);
        yield return new WaitForSeconds(0.03f);
        ice1_Bat.SetActive(false);

        dialogueText.text = "The attack is succesful!";

        yield return new WaitForSeconds(2f);

        if (isDead3)
        {
            dialogueText.text = enemy3Unit.unitName + " was defeated!";

            yield return new WaitForSeconds(1f);

            enemiesDead++;

            state = BattleState.PLAYERTURN;
            PlayerTurn();
            combatButtons.SetActive(true);
            enemy3.SetActive(false);
            enemy3HUDG.SetActive(false);
            _BatGO.SetActive(false);
            enemy3_double.SetActive(false);
            enemy3_fire.SetActive(false);
            enemy3_ice.SetActive(false);
            enemy3_iceAOE.SetActive(false);
            enemy3_Heal.SetActive(false);
            enemy3_Nade.SetActive(false);
            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected object
            EventSystem.current.SetSelectedGameObject(attackButton);

        }

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerIceAOE()
    {
        magicButtons4.SetActive(false);

        if (selected1 == 1 && selected4 == 4 && selected5 == 5)
        {
            if (enemy1Unit.currentHP>0)
            {
                ice1_King.SetActive(true);

                isDead = enemy1Unit.TakeDamage(7);

                yield return new WaitForSeconds(0.01f);
                ice2_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice3_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice4_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice5_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice6_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice7_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice8_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice9_King.SetActive(true);

                enemy1HUD.SetHP(enemy1Unit.currentHP);

                yield return new WaitForSeconds(0.6f);
                ice9_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice8_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice7_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice6_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice5_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice4_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice3_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice2_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice1_King.SetActive(false);
            }
            

            
            dialogueText.text = "The attack is succesful!";

            yield return new WaitForSeconds(2f);

            if (isDead)
            {
                dialogueText.text = enemy1Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();
                combatButtonsDouble.SetActive(false);
                combatButtons.SetActive(true);
                enemy1.SetActive(false);
                enemy1HUDG.SetActive(false);
                _KingSlimeGO.SetActive(false);
                enemy1_double.SetActive(false);
                enemy1_fire.SetActive(false);
                enemy1_ice.SetActive(false);
                enemy1_iceAOE.SetActive(false);
                enemy1_Heal.SetActive(false);
                enemy1_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);

            }


            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }
        else if (selected2 == 2 && selected4 == 4 && selected5 == 5)
        {
            if (enemy2Unit.currentHP>0)
            {
                ice1_Slime.SetActive(true);

                isDead2 = enemy2Unit.TakeDamage(7);

                yield return new WaitForSeconds(0.01f);
                ice2_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice3_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice4_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice5_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice6_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice7_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice8_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice9_Slime.SetActive(true);

                enemy2HUD.SetHP(enemy2Unit.currentHP);

                yield return new WaitForSeconds(0.6f);
                ice9_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice8_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice7_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice6_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice5_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice4_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice3_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice2_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice1_Slime.SetActive(false);

            }

            dialogueText.text = "The attack is succesful!";

            yield return new WaitForSeconds(2f);


            if (isDead2)
            {
                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();
                combatButtonsDouble.SetActive(false);
                combatButtons.SetActive(true);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);

            }


            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }
        else if (selected3 == 3 && selected4 == 4 && selected5 == 5)
        {
            if (enemy3Unit.currentHP>0)
            {
                ice1_Bat.SetActive(true);

                isDead3 = enemy3Unit.TakeDamage(7);

                yield return new WaitForSeconds(0.01f);
                ice2_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice3_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice4_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice5_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice6_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice7_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice8_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice9_Bat.SetActive(true);

                enemy3HUD.SetHP(enemy3Unit.currentHP);

                yield return new WaitForSeconds(0.6f);
                ice9_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice8_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice7_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice6_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice5_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice4_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice3_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice2_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice1_Bat.SetActive(false);
            }
            

            dialogueText.text = "The attack is succesful!";

            yield return new WaitForSeconds(2f);

            if (isDead3)
            {
                dialogueText.text = enemy3Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();
                combatButtonsDouble.SetActive(false);
                combatButtons.SetActive(true);
                enemy3.SetActive(false);
                enemy3HUDG.SetActive(false);
                _BatGO.SetActive(false);
                enemy3_double.SetActive(false);
                enemy3_fire.SetActive(false);
                enemy3_ice.SetActive(false);
                enemy3_iceAOE.SetActive(false);
                enemy3_Heal.SetActive(false);
                enemy3_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);

            }


            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }
        else if (selected1 == 1 && selected2 == 2 && selected4 == 4)
        {
            if (enemy1Unit.currentHP > 0)
            {
                ice1_King.SetActive(true);

                isDead = enemy1Unit.TakeDamage(7);

                yield return new WaitForSeconds(0.01f);
                ice2_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice3_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice4_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice5_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice6_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice7_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice8_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice9_King.SetActive(true);

                enemy1HUD.SetHP(enemy1Unit.currentHP);

                yield return new WaitForSeconds(0.6f);
                ice9_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice8_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice7_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice6_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice5_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice4_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice3_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice2_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice1_King.SetActive(false);
            }
            if (enemy2Unit.currentHP > 0)
            {
                ice1_Slime.SetActive(true);

                isDead2 = enemy2Unit.TakeDamage(7);

                yield return new WaitForSeconds(0.01f);
                ice2_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice3_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice4_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice5_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice6_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice7_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice8_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice9_Slime.SetActive(true);

                enemy2HUD.SetHP(enemy2Unit.currentHP);

                yield return new WaitForSeconds(0.6f);
                ice9_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice8_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice7_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice6_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice5_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice4_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice3_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice2_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice1_Slime.SetActive(false);
            }
            
            
            dialogueText.text = "The attack is succesful!";

            yield return new WaitForSeconds(2f);

            if (isDead && isDead2)
            {
                dialogueText.text = enemy1Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy1.SetActive(false);
                enemy1HUDG.SetActive(false);
                _KingSlimeGO.SetActive(false);
                enemy1_double.SetActive(false);
                enemy1_fire.SetActive(false);
                enemy1_ice.SetActive(false);
                enemy1_iceAOE.SetActive(false);
                enemy1_Heal.SetActive(false);
                enemy1_Nade.SetActive(false);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);

            }
            else if (isDead)
            {
                dialogueText.text = enemy1Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();
                combatButtonsDouble.SetActive(false);
                combatButtons.SetActive(true);
                enemy1.SetActive(false);
                enemy1HUDG.SetActive(false);
                _KingSlimeGO.SetActive(false);
                enemy1_double.SetActive(false);
                enemy1_fire.SetActive(false);
                enemy1_ice.SetActive(false);
                enemy1_iceAOE.SetActive(false);
                enemy1_Heal.SetActive(false);
                enemy1_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);

            }
            else if (isDead2)
            {
                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();
                combatButtonsDouble.SetActive(false);
                combatButtons.SetActive(true);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);

            }


            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }
        else if (selected2 == 2 && selected3 == 3 && selected4 == 4)
        {

            if (enemy3Unit.currentHP > 0)
            {
                ice1_Bat.SetActive(true);

                isDead3 = enemy3Unit.TakeDamage(7);

                yield return new WaitForSeconds(0.01f);
                ice2_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice3_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice4_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice5_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice6_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice7_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice8_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice9_Bat.SetActive(true);

                enemy3HUD.SetHP(enemy3Unit.currentHP);

                yield return new WaitForSeconds(0.6f);
                ice9_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice8_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice7_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice6_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice5_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice4_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice3_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice2_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice1_Bat.SetActive(false);
            }
            if (enemy2Unit.currentHP > 0)
            {
                ice1_Slime.SetActive(true);

                isDead2 = enemy2Unit.TakeDamage(7);

                yield return new WaitForSeconds(0.01f);
                ice2_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice3_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice4_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice5_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice6_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice7_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice8_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice9_Slime.SetActive(true);

                enemy2HUD.SetHP(enemy2Unit.currentHP);

                yield return new WaitForSeconds(0.6f);
                ice9_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice8_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice7_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice6_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice5_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice4_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice3_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice2_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice1_Slime.SetActive(false);
            }


            dialogueText.text = "The attack is succesful!";

            yield return new WaitForSeconds(2f);

            if (isDead2 && isDead3)
            {
                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy3Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                enemy3.SetActive(false);
                enemy3HUDG.SetActive(false);
                _BatGO.SetActive(false);
                enemy3_double.SetActive(false);
                enemy3_fire.SetActive(false);
                enemy3_ice.SetActive(false);
                enemy3_iceAOE.SetActive(false);
                enemy3_Heal.SetActive(false);
                enemy3_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);

            }
            else if (isDead3)
            {
                dialogueText.text = enemy3Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();
                combatButtonsDouble.SetActive(false);
                combatButtons.SetActive(true);
                enemy3.SetActive(false);
                enemy3HUDG.SetActive(false);
                _BatGO.SetActive(false);
                enemy3_double.SetActive(false);
                enemy3_fire.SetActive(false);
                enemy3_ice.SetActive(false);
                enemy3_iceAOE.SetActive(false);
                enemy3_Heal.SetActive(false);
                enemy3_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);

            }
            else if (isDead2)
            {
                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();
                combatButtonsDouble.SetActive(false);
                combatButtons.SetActive(true);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);

            }


            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }
        else if (selected3 == 3 && selected1 == 1 && selected4 == 4)
        {
            if (enemy1Unit.currentHP > 0)
            {
                ice1_King.SetActive(true);

                isDead = enemy1Unit.TakeDamage(7);

                yield return new WaitForSeconds(0.01f);
                ice2_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice3_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice4_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice5_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice6_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice7_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice8_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice9_King.SetActive(true);

                enemy1HUD.SetHP(enemy1Unit.currentHP);

                yield return new WaitForSeconds(0.6f);
                ice9_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice8_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice7_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice6_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice5_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice4_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice3_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice2_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice1_King.SetActive(false);
            }
            if (enemy3Unit.currentHP > 0)
            {
                ice1_Bat.SetActive(true);

                isDead3 = enemy3Unit.TakeDamage(7);

                yield return new WaitForSeconds(0.01f);
                ice2_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice3_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice4_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice5_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice6_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice7_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice8_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice9_Bat.SetActive(true);

                enemy3HUD.SetHP(enemy3Unit.currentHP);

                yield return new WaitForSeconds(0.6f);
                ice9_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice8_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice7_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice6_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice5_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice4_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice3_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice2_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice1_Bat.SetActive(false);
            }

            dialogueText.text = "The attack is succesful!";

            yield return new WaitForSeconds(2f);

            if (isDead && isDead3)
            {
                dialogueText.text = enemy1Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy3Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy1.SetActive(false);
                enemy1HUDG.SetActive(false);
                _KingSlimeGO.SetActive(false);
                enemy1_double.SetActive(false);
                enemy1_fire.SetActive(false);
                enemy1_ice.SetActive(false);
                enemy1_iceAOE.SetActive(false);
                enemy1_Heal.SetActive(false);
                enemy1_Nade.SetActive(false);
                enemy3.SetActive(false);
                enemy3HUDG.SetActive(false);
                _BatGO.SetActive(false);
                enemy3_double.SetActive(false);
                enemy3_fire.SetActive(false);
                enemy3_ice.SetActive(false);
                enemy3_iceAOE.SetActive(false);
                enemy3_Heal.SetActive(false);
                enemy3_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);

            }
            else if (isDead3)
            {
                dialogueText.text = enemy3Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();
                combatButtonsDouble.SetActive(false);
                combatButtons.SetActive(true);
                enemy3.SetActive(false);
                enemy3HUDG.SetActive(false);
                _BatGO.SetActive(false);
                enemy3_double.SetActive(false);
                enemy3_fire.SetActive(false);
                enemy3_ice.SetActive(false);
                enemy3_iceAOE.SetActive(false);
                enemy3_Heal.SetActive(false);
                enemy3_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);

            }
            else if (isDead)
            {
                dialogueText.text = enemy1Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();
                combatButtonsDouble.SetActive(false);
                enemy1.SetActive(false);
                enemy1HUDG.SetActive(false);
                _KingSlimeGO.SetActive(false);
                enemy1_double.SetActive(false);
                enemy1_fire.SetActive(false);
                enemy1_ice.SetActive(false);
                enemy1_iceAOE.SetActive(false);
                enemy1_Heal.SetActive(false);
                enemy1_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);

            }


            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }
        else if (selected1 == 1 && selected2 == 2 && selected3 == 3)
        {
            if (enemy1Unit.currentHP > 0)
            {
                ice1_King.SetActive(true);

                isDead = enemy1Unit.TakeDamage(7);

                yield return new WaitForSeconds(0.01f);
                ice2_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice3_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice4_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice5_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice6_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice7_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice8_King.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice9_King.SetActive(true);

                enemy1HUD.SetHP(enemy1Unit.currentHP);

                yield return new WaitForSeconds(0.6f);
                ice9_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice8_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice7_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice6_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice5_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice4_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice3_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice2_King.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice1_King.SetActive(false);
            }
            if (enemy2Unit.currentHP > 0)
            {
                ice1_Slime.SetActive(true);

                isDead2 = enemy2Unit.TakeDamage(7);

                yield return new WaitForSeconds(0.01f);
                ice2_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice3_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice4_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice5_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice6_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice7_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice8_Slime.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice9_Slime.SetActive(true);

                enemy2HUD.SetHP(enemy2Unit.currentHP);

                yield return new WaitForSeconds(0.6f);
                ice9_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice8_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice7_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice6_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice5_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice4_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice3_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice2_Slime.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice1_Slime.SetActive(false);
            }
            if (enemy3Unit.currentHP > 0)
            {
                ice1_Bat.SetActive(true);

                isDead3 = enemy3Unit.TakeDamage(7);

                yield return new WaitForSeconds(0.01f);
                ice2_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice3_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice4_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice5_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice6_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice7_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice8_Bat.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                ice9_Bat.SetActive(true);

                enemy3HUD.SetHP(enemy3Unit.currentHP);

                yield return new WaitForSeconds(0.6f);
                ice9_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice8_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice7_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice6_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice5_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice4_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice3_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice2_Bat.SetActive(false);
                yield return new WaitForSeconds(0.03f);
                ice1_Bat.SetActive(false);
            }

            dialogueText.text = "The attack is succesful!";

            yield return new WaitForSeconds(2f);
            if (isDead && isDead2 && isDead3)
            {
                dialogueText.text = enemy1Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy3Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;
                enemiesDead++;
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy1.SetActive(false);
                enemy1HUDG.SetActive(false);
                _KingSlimeGO.SetActive(false);
                enemy1_double.SetActive(false);
                enemy1_fire.SetActive(false);
                enemy1_ice.SetActive(false);
                enemy1_iceAOE.SetActive(false);
                enemy1_Heal.SetActive(false);
                enemy1_Nade.SetActive(false);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                enemy3.SetActive(false);
                enemy3HUDG.SetActive(false);
                _BatGO.SetActive(false);
                enemy3_double.SetActive(false);
                enemy3_fire.SetActive(false);
                enemy3_ice.SetActive(false);
                enemy3_iceAOE.SetActive(false);
                enemy3_Heal.SetActive(false);
                enemy3_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }
            else if (isDead && isDead2)
            {
                dialogueText.text = enemy1Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy1.SetActive(false);
                enemy1HUDG.SetActive(false);
                _KingSlimeGO.SetActive(false);
                enemy1_double.SetActive(false);
                enemy1_fire.SetActive(false);
                enemy1_ice.SetActive(false);
                enemy1_iceAOE.SetActive(false);
                enemy1_Heal.SetActive(false);
                enemy1_Nade.SetActive(false);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }
            else if (isDead && isDead3)
            {
                dialogueText.text = enemy1Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy3Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy1.SetActive(false);
                enemy1HUDG.SetActive(false);
                _KingSlimeGO.SetActive(false);
                enemy1_double.SetActive(false);
                enemy1_fire.SetActive(false);
                enemy1_ice.SetActive(false);
                enemy1_iceAOE.SetActive(false);
                enemy1_Heal.SetActive(false);
                enemy1_Nade.SetActive(false);
                enemy3.SetActive(false);
                enemy3HUDG.SetActive(false);
                _BatGO.SetActive(false);
                enemy3_double.SetActive(false);
                enemy3_fire.SetActive(false);
                enemy3_ice.SetActive(false);
                enemy3_iceAOE.SetActive(false);
                enemy3_Heal.SetActive(false);
                enemy3_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }
            else if (isDead2 && isDead3)
            {
                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy3Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                enemy3.SetActive(false);
                enemy3HUDG.SetActive(false);
                _BatGO.SetActive(false);
                enemy3_double.SetActive(false);
                enemy3_fire.SetActive(false);
                enemy3_ice.SetActive(false);
                enemy3_iceAOE.SetActive(false);
                enemy3_Heal.SetActive(false);
                enemy3_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }
            else if (isDead)
            {

                dialogueText.text = enemy1Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy1.SetActive(false);
                enemy1HUDG.SetActive(false);
                _KingSlimeGO.SetActive(false);
                enemy1_double.SetActive(false);
                enemy1_fire.SetActive(false);
                enemy1_ice.SetActive(false);
                enemy1_iceAOE.SetActive(false);
                enemy1_Heal.SetActive(false);
                enemy1_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);


            }
            else if (isDead2)
            {
                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }
            else if (isDead3)
            {
                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy3Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy3.SetActive(false);
                enemy3HUDG.SetActive(false);
                _BatGO.SetActive(false);
                enemy3_double.SetActive(false);
                enemy3_fire.SetActive(false);
                enemy3_ice.SetActive(false);
                enemy3_iceAOE.SetActive(false);
                enemy3_Heal.SetActive(false);
                enemy3_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }
    }

    IEnumerator PlayerHeal()
    {
        
        
        dialogue.SetActive(true);

        potCounter--;
        potNumb = potCounter.ToString();
        potText.text = "" + potNumb;


        if (playerUnit.currentHP == playerUnit.maxHP)
        {
            healButtons.SetActive(false);
            dialogue.SetActive(true);
            dialogueText.text = "You canno't heal while full HP";

            yield return new WaitForSeconds(1f);

            StartCoroutine(HealActivation());
            potCounter++;
            potNumb = potCounter.ToString();
            potText.text = "" + potNumb;


        }
        else if (potCounter >= 0)
        {
            healButtons.SetActive(false);


            playerUnit.Heal(30);

            playerHUD.SetHP(playerUnit.currentHP);
            dialogueText.text = "You succesfully healed!";

            

            yield return new WaitForSeconds(2f);

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        
        
    }

    IEnumerator KingSlimeHeal()
    {


        dialogue.SetActive(true);

        potCounter--;
        potNumb = potCounter.ToString();
        potText.text = "" + potNumb;


        if (enemy1Unit.currentHP == enemy1Unit.maxHP)
        {
            healButtons.SetActive(false);
            dialogue.SetActive(true);
            dialogueText.text = "You canno't heal while full HP";

            yield return new WaitForSeconds(1f);

            StartCoroutine(HealActivation());
            potCounter++;
            potNumb = potCounter.ToString();
            potText.text = "" + potNumb;


        }
        else if (potCounter >= 0)
        {
            healButtons.SetActive(false);


            enemy1Unit.Heal(30);

            enemy1HUD.SetHP(enemy1Unit.currentHP);

            dialogueText.text = "You succesfully healed!";



            yield return new WaitForSeconds(2f);

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }


    }

    IEnumerator SlimeHeal()
    {


        dialogue.SetActive(true);

        potCounter--;
        potNumb = potCounter.ToString();
        potText.text = "" + potNumb;


        if (enemy2Unit.currentHP == enemy2Unit.maxHP)
        {
            healButtons.SetActive(false);
            dialogue.SetActive(true);
            dialogueText.text = "You canno't heal while full HP";

            yield return new WaitForSeconds(1f);

            StartCoroutine(HealActivation());
            potCounter++;
            potNumb = potCounter.ToString();
            potText.text = "" + potNumb;


        }
        else if (potCounter >= 0)
        {
            healButtons.SetActive(false);


            enemy2Unit.Heal(30);

            enemy2HUD.SetHP(enemy2Unit.currentHP);

            dialogueText.text = "You succesfully healed!";



            yield return new WaitForSeconds(2f);

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }


    }

    IEnumerator BatHeal()
    {


        dialogue.SetActive(true);

        potCounter--;
        potNumb = potCounter.ToString();
        potText.text = "" + potNumb;


        if (enemy3Unit.currentHP == enemy3Unit.maxHP)
        {
            healButtons.SetActive(false);
            dialogue.SetActive(true);
            dialogueText.text = "You canno't heal while full HP";

            yield return new WaitForSeconds(1f);

            StartCoroutine(HealActivation());
            potCounter++;
            potNumb = potCounter.ToString();
            potText.text = "" + potNumb;


        }
        else if (potCounter >= 0)
        {
            healButtons.SetActive(false);


            enemy3Unit.Heal(30);

            enemy3HUD.SetHP(enemy3Unit.currentHP);

            dialogueText.text = "You succesfully healed!";



            yield return new WaitForSeconds(2f);

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }


    }

    IEnumerator KingSlimeNade()
    {


        dialogue.SetActive(true);

        nadeCounter--;
        nadeNumb = nadeCounter.ToString();
        nadeText.text = "" + nadeNumb;

        if (nadeCounter >= 0)
        {
            nadeButtons.SetActive(false);


            if (enemy1Unit.currentHP > 0)
            {


                Grenade.SetInteger("Target", 0);
                Grenade.SetTrigger("TriggerAnim");


                yield return new WaitForSeconds(0.7f);
                isDead = enemy1Unit.TakeDamage(10);
            }
            if (enemy2Unit.currentHP > 0)
            {
                isDead2 = enemy2Unit.TakeDamage(5);
            }

            enemy1HUD.SetHP(enemy1Unit.currentHP);
            enemy2HUD.SetHP(enemy2Unit.currentHP);

            dialogueText.text = "You threw a grenade!";

            yield return new WaitForSeconds(2f);

            if (isDead && isDead2)
            {
                dialogueText.text = enemy1Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy1.SetActive(false);
                enemy1HUDG.SetActive(false);
                _KingSlimeGO.SetActive(false);
                enemy1_double.SetActive(false);
                enemy1_fire.SetActive(false);
                enemy1_ice.SetActive(false);
                enemy1_iceAOE.SetActive(false);
                enemy1_Heal.SetActive(false);
                enemy1_Nade.SetActive(false);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }
            else if (isDead)
            {

                dialogueText.text = enemy1Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy1.SetActive(false);
                enemy1HUDG.SetActive(false);
                _KingSlimeGO.SetActive(false);
                enemy1_double.SetActive(false);
                enemy1_fire.SetActive(false);
                enemy1_ice.SetActive(false);
                enemy1_iceAOE.SetActive(false);
                enemy1_Heal.SetActive(false);
                enemy1_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);


            }
            else if (isDead2)
            {
                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }

            

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }


    }

    IEnumerator SlimeNade()
    {


        dialogue.SetActive(true);

        nadeCounter--;
        nadeNumb = nadeCounter.ToString();
        nadeText.text = "" + nadeNumb;

        if (nadeCounter >= 0)
        {
            nadeButtons.SetActive(false);

            if (enemy1Unit.currentHP > 0)
            {
                isDead = enemy1Unit.TakeDamage(5);
            }
            if (enemy2Unit.currentHP > 0)
            {

                Grenade.SetInteger("Target", 1);
                Grenade.SetTrigger("TriggerAnim");

                yield return new WaitForSeconds(0.7f);
                isDead2 = enemy2Unit.TakeDamage(10);
            }
            if (enemy3Unit.currentHP > 0)
            {
                isDead3 = enemy3Unit.TakeDamage(5);
            }
            

            enemy1HUD.SetHP(enemy1Unit.currentHP);
            enemy2HUD.SetHP(enemy2Unit.currentHP);
            enemy3HUD.SetHP(enemy3Unit.currentHP);

            dialogueText.text = "You threw a grenade!";

            yield return new WaitForSeconds(2f);
            if (isDead && isDead2 && isDead3)
            {
                dialogueText.text = enemy1Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy3Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;
                enemiesDead++;
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy1.SetActive(false);
                enemy1HUDG.SetActive(false);
                _KingSlimeGO.SetActive(false);
                enemy1_double.SetActive(false);
                enemy1_fire.SetActive(false);
                enemy1_ice.SetActive(false);
                enemy1_iceAOE.SetActive(false);
                enemy1_Heal.SetActive(false);
                enemy1_Nade.SetActive(false);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                enemy3.SetActive(false);
                enemy3HUDG.SetActive(false);
                _BatGO.SetActive(false);
                enemy3_double.SetActive(false);
                enemy3_fire.SetActive(false);
                enemy3_ice.SetActive(false);
                enemy3_iceAOE.SetActive(false);
                enemy3_Heal.SetActive(false);
                enemy3_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }
            else if (isDead && isDead2)
            {
                dialogueText.text = enemy1Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy1.SetActive(false);
                enemy1HUDG.SetActive(false);
                _KingSlimeGO.SetActive(false);
                enemy1_double.SetActive(false);
                enemy1_fire.SetActive(false);
                enemy1_ice.SetActive(false);
                enemy1_iceAOE.SetActive(false);
                enemy1_Heal.SetActive(false);
                enemy1_Nade.SetActive(false);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }
            else if (isDead && isDead3)
            {
                dialogueText.text = enemy1Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy3Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy1.SetActive(false);
                enemy1HUDG.SetActive(false);
                _KingSlimeGO.SetActive(false);
                enemy1_double.SetActive(false);
                enemy1_fire.SetActive(false);
                enemy1_ice.SetActive(false);
                enemy1_iceAOE.SetActive(false);
                enemy1_Heal.SetActive(false);
                enemy1_Nade.SetActive(false);
                enemy3.SetActive(false);
                enemy3HUDG.SetActive(false);
                _BatGO.SetActive(false);
                enemy3_double.SetActive(false);
                enemy3_fire.SetActive(false);
                enemy3_ice.SetActive(false);
                enemy3_iceAOE.SetActive(false);
                enemy3_Heal.SetActive(false);
                enemy3_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }
            else if (isDead2 && isDead3)
            {
                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy3Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                enemy3.SetActive(false);
                enemy3HUDG.SetActive(false);
                _BatGO.SetActive(false);
                enemy3_double.SetActive(false);
                enemy3_fire.SetActive(false);
                enemy3_ice.SetActive(false);
                enemy3_iceAOE.SetActive(false);
                enemy3_Heal.SetActive(false);
                enemy3_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }
            else if (isDead)
            {

                dialogueText.text = enemy1Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy1.SetActive(false);
                enemy1HUDG.SetActive(false);
                _KingSlimeGO.SetActive(false);
                enemy1_double.SetActive(false);
                enemy1_fire.SetActive(false);
                enemy1_ice.SetActive(false);
                enemy1_iceAOE.SetActive(false);
                enemy1_Heal.SetActive(false);
                enemy1_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);


            }
            else if (isDead2)
            {
                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }
            else if (isDead3)
            {
                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy3Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy3.SetActive(false);
                enemy3HUDG.SetActive(false);
                _BatGO.SetActive(false);
                enemy3_double.SetActive(false);
                enemy3_fire.SetActive(false);
                enemy3_ice.SetActive(false);
                enemy3_iceAOE.SetActive(false);
                enemy3_Heal.SetActive(false);
                enemy3_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }



            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }


    }

    IEnumerator BatNade()
    {


        dialogue.SetActive(true);

        nadeCounter--;
        nadeNumb = nadeCounter.ToString();
        nadeText.text = "" + nadeNumb;

        if (nadeCounter >= 0)
        {
            nadeButtons.SetActive(false);

            if (enemy3Unit.currentHP > 0)
            {
                Grenade.SetInteger("Target", 2);
                Grenade.SetTrigger("TriggerAnim");


                yield return new WaitForSeconds(0.7f);
                isDead3 = enemy3Unit.TakeDamage(10);
            }
            if (enemy2Unit.currentHP > 0)
            {
                isDead2 = enemy2Unit.TakeDamage(5);
            }
            

            enemy3HUD.SetHP(enemy3Unit.currentHP);
            enemy2HUD.SetHP(enemy2Unit.currentHP);

            dialogueText.text = "You threw a grenade!";

            yield return new WaitForSeconds(2f);

            if (isDead2 && isDead3)
            {
                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy3Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(2f);
                enemiesDead++;
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                enemy3.SetActive(false);
                enemy3HUDG.SetActive(false);
                _BatGO.SetActive(false);
                enemy3_double.SetActive(false);
                enemy3_fire.SetActive(false);
                enemy3_ice.SetActive(false);
                enemy3_iceAOE.SetActive(false);
                enemy3_Heal.SetActive(false);
                enemy3_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }
            else if (isDead2)
            {
                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy2Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy2.SetActive(false);
                enemy2HUDG.SetActive(false);
                _SlimeGO.SetActive(false);
                enemy2_double.SetActive(false);
                enemy2_fire.SetActive(false);
                enemy2_ice.SetActive(false);
                enemy2_iceAOE.SetActive(false);
                enemy2_Heal.SetActive(false);
                enemy2_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }
            else if (isDead3)
            {
                yield return new WaitForSeconds(1f);

                dialogueText.text = enemy3Unit.unitName + " was defeated!";

                yield return new WaitForSeconds(1f);
                enemiesDead++;

                state = BattleState.PLAYERTURN;
                PlayerTurn();

                combatButtons.SetActive(true);
                enemy3.SetActive(false);
                enemy3HUDG.SetActive(false);
                _BatGO.SetActive(false);
                enemy3_double.SetActive(false);
                enemy3_fire.SetActive(false);
                enemy3_ice.SetActive(false);
                enemy3_iceAOE.SetActive(false);
                enemy3_Heal.SetActive(false);
                enemy3_Nade.SetActive(false);
                //clear selected object
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(attackButton);
            }

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }


    }

    public void ConfirmationAttackKingSlime()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            dialogue.SetActive(true);
            StartCoroutine(PlayerAttackKingSlime());
        }
            
    }

    public void ConfirmationAttackSlime()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            dialogue.SetActive(true);
            StartCoroutine(PlayerAttackSlime());
        }

    }

    public void ConfirmationAttackBat()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            dialogue.SetActive(true);
            StartCoroutine(PlayerAttackBat());
        }

    }

    public void ConfirmationAttackDoubleKingSlime()
    {
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (selected1==0)
            {
                ColorBlock cb = king.colors;
                cb.normalColor = wantedcolor;
                cb.highlightedColor = wantedcolor;
                cb.selectedColor = wantedcolor;
                king.colors = cb;

                selected1 = 1;

                if (selected1 == 1 && selected2 == 2 || selected1 == 1 && selected3 == 3 || selected1 == 1 && selected4 == 4 && selected5 == 5)
                {
                    dialogue.SetActive(true);
                    StartCoroutine(PlayerAttackKingSlime());
                }
            }
            else if (selected1==1)
            {
                ColorBlock cb = king.colors;
                cb.normalColor = Color.white;
                cb.highlightedColor = Color.white;
                cb.selectedColor = wantedcolor;
                king.colors = cb;
                selected1 = 0;
            }

        }

    }

    public void ConfirmationAttackDoubleBat()
    {
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (selected3==0)
            {
                ColorBlock cb = bat.colors;
                cb.normalColor = wantedcolor;
                cb.highlightedColor = wantedcolor;
                cb.selectedColor = wantedcolor;
                bat.colors = cb;

                selected3 = 3;

                if (selected3 == 3 && selected2 == 2 || selected1 == 1 && selected3 == 3 || selected3 == 3 && selected4 == 4 && selected5 == 5)
                {
                    dialogue.SetActive(true);
                    StartCoroutine(PlayerAttackKingSlime());
                }
            }
            else if (selected3 == 3)
            {
                ColorBlock cb = bat.colors;
                cb.normalColor = Color.white;
                cb.highlightedColor = Color.white;
                cb.selectedColor = wantedcolor;
                bat.colors = cb;
                selected3 = 0;
            }


        }

    }

    public void ConfirmationAttackDoubleSlime()
    {
       
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (selected2==0)
            {
                ColorBlock cb = slime.colors;
                cb.normalColor = wantedcolor;
                cb.highlightedColor = wantedcolor;
                cb.selectedColor = wantedcolor;
                slime.colors = cb;

                selected2 = 2;

                if (selected1 == 1 && selected2 == 2 || selected2 == 2 && selected3 == 3 || selected2 == 2 && selected4 == 4 && selected5 == 5)
                {
                    dialogue.SetActive(true);
                    StartCoroutine(PlayerAttackKingSlime());
                }
            }
            else if (selected2==2)
            {
                ColorBlock cb = slime.colors;
                cb.normalColor = Color.white;
                cb.highlightedColor = Color.white;
                cb.selectedColor = wantedcolor;
                slime.colors = cb;
                selected2 = 0;
            }
            

        }

    }

    public void ConfirmationFireKingSlime()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            dialogue.SetActive(true);
            StartCoroutine(PlayerFireKingSlime());
        }

    }

    public void ConfirmationFireSlime()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            dialogue.SetActive(true);
            StartCoroutine(PlayerFireSlime());
        }

    }
    public void ConfirmationFireBat()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            dialogue.SetActive(true);
            StartCoroutine(PlayerFireBat());
        }

    }

    public void ConfirmationIceKingSlime()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            dialogue.SetActive(true);
            StartCoroutine(PlayerIceKingSlime());
        }

    }

    public void ConfirmationIceSlime()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            dialogue.SetActive(true);
            StartCoroutine(PlayerIceSlime());
        }

    }

    public void ConfirmationIceBat()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            dialogue.SetActive(true);
            StartCoroutine(PlayerIceBat());
        }

    }

    public void ConfirmationIceAOEKingSLime()
    {
        

        if (Input.GetKeyDown(KeyCode.Return))
        {

            ColorBlock cb = king2.colors;
            cb.normalColor = wantedcolor;
            cb.highlightedColor = wantedcolor;
            cb.selectedColor = wantedcolor;
            king2.colors = cb;

            selected1 = 1;
            
            if (selected1 == 1 && selected2 == 2  && selected3 == 3 || selected1==1 && selected4==4 && selected5==5
                || selected1 == 1 && selected2 == 2 && selected4 == 4 || selected1 == 1 && selected3 == 3 && selected4==4)
            {
                dialogue.SetActive(true);
                StartCoroutine(PlayerIceAOE());
            }

        }

    }

    public void ConfirmationIceAOESLime()
    {
       

        if (Input.GetKeyDown(KeyCode.Return))
        {

            ColorBlock cb = slime2.colors;
            cb.normalColor = wantedcolor;
            cb.highlightedColor = wantedcolor;
            cb.selectedColor = wantedcolor;
            slime2.colors = cb;

            selected2 = 2;

            if (selected1 == 1 && selected2 == 2 && selected3 == 3 || selected2 == 2 && selected4 == 4 && selected5 == 5
                || selected1 == 1 && selected2 == 2 && selected4 == 4 || selected2 == 2 && selected3 == 3 && selected4 == 4)
            {
                dialogue.SetActive(true);
                StartCoroutine(PlayerIceAOE());
            }

        }

    }
    public void ConfirmationIceAOEBat()
    {
       

        if (Input.GetKeyDown(KeyCode.Return))
        {

            ColorBlock cb = bat2.colors;
            cb.normalColor = wantedcolor;
            cb.highlightedColor = wantedcolor;
            cb.selectedColor = wantedcolor;
            bat2.colors = cb;

            selected3 = 3;

            if (selected1 == 1 && selected2 == 2 && selected3 == 3 || selected3 == 3 && selected4 == 4 && selected5 == 5
                || selected3 == 3 && selected2 == 2 && selected4 == 4 || selected1 == 1 && selected3 == 3 && selected4 == 4)
            {
                dialogue.SetActive(true);
                StartCoroutine(PlayerIceAOE());
            }

        }

    }

    public void ConfirmationHealPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(PlayerHeal());
        }
    }
    public void ConfirmationHealKingSlime()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(KingSlimeHeal());
        }
    }
    public void ConfirmationHealSlime()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(SlimeHeal());
        }
    }
    public void ConfirmationHealBat()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(BatHeal());
        }
    }

    public void ConfirmationNadeKingSlime()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(KingSlimeNade());
        }
    }
    public void ConfirmationNadeSlime()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(SlimeNade());
        }
    }
    public void ConfirmationNadeBat()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(BatNade());
        }
    }
    void EndBattle()
    {
        if (state == BattleState.WON)
        {            
            dialogueText.text = "You won the battle!!!";            
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated.";            
        }

    }
    IEnumerator EnemyTurn()
    {
        if (enemy1Unit.currentHP<=0)
        {
            enemy1Unit.damage=0;
            isDead = playerUnit.TakeDamage(enemy1Unit.damage);

        }
        else
        {
            //King Slime attacks
            dialogueText.text = enemy1Unit.unitName + " attacks!";

            yield return new WaitForSeconds(1f);

            _KingSlimeGO.transform.Translate(new Vector3(0.2f, 0.2f), Space.World);
            yield return new WaitForSeconds(0.04f);
            _KingSlimeGO.transform.Translate(new Vector3(-0.4f, -0.4f), Space.World);
            yield return new WaitForSeconds(0.04f);
            _KingSlimeGO.transform.Translate(new Vector3(0.2f, 0.2f), Space.World);

            monsterHit1.SetActive(true); 

             isDead = playerUnit.TakeDamage(enemy1Unit.damage);

            yield return new WaitForSeconds(0.04f);
            monsterHit2.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            monsterHit3.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            monsterHit4.SetActive(true);
            



            playerHUD.SetHP(playerUnit.currentHP);

            //King slime annimation disappears
            yield return new WaitForSeconds(0.04f);
            monsterHit4.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            monsterHit3.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            monsterHit2.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            monsterHit1.SetActive(false);
        }
       

        

        if (enemy2Unit.currentHP <= 0)
        {
            enemy2Unit.damage = 0;
            isDead = playerUnit.TakeDamage(enemy2Unit.damage);
        }
        else
        {
            //Slime attacks
            dialogueText.text = enemy2Unit.unitName + " attacks!";

            yield return new WaitForSeconds(1f);

            _SlimeGO.transform.Translate(new Vector3(0.2f, 0.2f), Space.World);
            yield return new WaitForSeconds(0.04f);
            _SlimeGO.transform.Translate(new Vector3(-0.4f, -0.4f), Space.World);
            yield return new WaitForSeconds(0.04f);
            _SlimeGO.transform.Translate(new Vector3(0.2f, 0.2f), Space.World);

            monsterHit1.SetActive(true);

            isDead = playerUnit.TakeDamage(enemy2Unit.damage);

            yield return new WaitForSeconds(0.04f);
            monsterHit2.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            monsterHit3.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            monsterHit4.SetActive(true);




            playerHUD.SetHP(playerUnit.currentHP);

            //Slime annimation disappears
            yield return new WaitForSeconds(0.04f);
            monsterHit4.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            monsterHit3.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            monsterHit2.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            monsterHit1.SetActive(false);
        }
        

        

        if (enemy3Unit.currentHP <= 0)
        {
            enemy3Unit.damage = 0;
            isDead = playerUnit.TakeDamage(enemy3Unit.damage);
        }
        else
        {
            //Bat attacks
            dialogueText.text = enemy3Unit.unitName + " attacks!";

            yield return new WaitForSeconds(1f);

            _BatGO.transform.Translate(new Vector3(0.2f, 0.2f), Space.World);
            yield return new WaitForSeconds(0.04f);
            _BatGO.transform.Translate(new Vector3(-0.4f, -0.4f), Space.World);
            yield return new WaitForSeconds(0.04f);
            _BatGO.transform.Translate(new Vector3(0.2f, 0.2f), Space.World);

            monsterHit1.SetActive(true);

            isDead = playerUnit.TakeDamage(enemy3Unit.damage);

            yield return new WaitForSeconds(0.04f);
            monsterHit2.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            monsterHit3.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            monsterHit4.SetActive(true);


            

            playerHUD.SetHP(playerUnit.currentHP);

            //Bat annimation disappears
            yield return new WaitForSeconds(0.04f);
            monsterHit4.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            monsterHit3.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            monsterHit2.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            monsterHit1.SetActive(false);
        }
        

        

        if (isDead)
        {
            playerGO.SetActive(false);
            playerHUDG.SetActive(false);
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
            combatButtons.SetActive(true);
            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected object
            EventSystem.current.SetSelectedGameObject(attackButton);
        }

    }


    void PlayerTurn()
    {
        if (enemiesDead == 3)
        {
            
            dialogue.SetActive(true);
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            selected1 = 0;
            selected2 = 0;
            selected3 = 0;
            ColorBlock cb = king.colors;
            cb.normalColor = Color.white;
            king.colors = cb;
            slime.colors = cb;
            bat.colors = cb;
            king2.colors = cb;
            slime2.colors = cb;
            bat2.colors = cb;



            if (enemy1Unit.currentHP <= 0)
            {
                selected4 = 4;
                isDead = false;

                if (enemy2Unit.currentHP<=0)
                {
                    selected5 = 5;
                    isDead2 = false;
                }
                if (enemy3Unit.currentHP<=0)
                {
                    selected5 = 5;
                    isDead3 = false;
                }
            }
            if (enemy2Unit.currentHP <= 0)
            {
                selected4 = 4;
                isDead2 = false;

                if (enemy1Unit.currentHP <= 0)
                {
                    selected5 = 5;
                    isDead = false;
                }
                if (enemy3Unit.currentHP <= 0)
                {
                    selected5 = 5;
                    isDead3 = false;
                }
            }
            if (enemy3Unit.currentHP <= 0)
            {
                selected4 = 4;
                isDead3 = false;

                if (enemy1Unit.currentHP <= 0)
                {
                    selected5 = 5;
                    isDead = false;
                }
                if (enemy2Unit.currentHP <= 0)
                {
                    selected5 = 5;
                    isDead2 = false;
                }
            }

            dialogueText.text = "Choose an action.";
        }


    }



    public void AttackButton()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (state != BattleState.PLAYERTURN)
                return;

            StartCoroutine(ButtonActivation());

            
        } 
    }

    public void MagicButton()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (state != BattleState.PLAYERTURN)
                return;

            StartCoroutine(MagicButtonActivation());


        }
    }

    public void FireButton()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (state != BattleState.PLAYERTURN)
                return;

            StartCoroutine(MagicButtonActivationFire());


        }
    }

    public void IceButton()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (state != BattleState.PLAYERTURN)
                return;

            StartCoroutine(MagicButtonActivationIce());


        }
    }

    public void UseItemButton()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (state != BattleState.PLAYERTURN)
                return;

            StartCoroutine(UseItemActivation());


        }
    }

    
    public void HealButton()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            
            if (potCounter > 0  )
            {
                if (state != BattleState.PLAYERTURN)
                    return;

                StartCoroutine(HealActivation());
            }

        }
    }


    public void GrenadeButton()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {

            if (nadeCounter > 0)
            {
                if (state != BattleState.PLAYERTURN)
                    return;

                StartCoroutine(GrenadeActivation());
            }

        }
    }


    public void SingleTarget()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (state != BattleState.PLAYERTURN)
                return;

            StartCoroutine(ButtonActivation2());
        }
    }

    public void SingleTargetIce()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (state != BattleState.PLAYERTURN)
                return;

            StartCoroutine(MagicButtonActivation3());
        }
    }

    public void SingleTargetFire()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (state != BattleState.PLAYERTURN)
                return;

            StartCoroutine(MagicButtonActivation2());
        }
    }



    
    public void DoubleTarget()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (state != BattleState.PLAYERTURN)
                return;

            StartCoroutine(ButtonActivation3());

            
        }
    }

    public void AOETarget()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (state != BattleState.PLAYERTURN)
                return;

            StartCoroutine(MagicButtonActivation4());


        }
    }

    public void ReturnButton1()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(ButtonStart());
            magicButtons.SetActive(false);
            useItemButton.SetActive(false);
        }
    }

    public void ReturnButton2()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(ButtonActivation());

            combatButtons3.SetActive(false);
            combatButtonsDouble.SetActive(false);
            combatButtons2.SetActive(true);

            ColorBlock cb = king.colors;
            cb.normalColor = Color.white;
            bat.colors = cb;
            king.colors = cb;
            slime.colors = cb;
            selected1 = 0;
            selected2 = 0;
            selected3 = 0;



            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected object
            EventSystem.current.SetSelectedGameObject(singleTargetButton);

        }
    }

    public void ReturnButton3()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(MagicButtonActivation());

            
            magicButtonsFire.SetActive(false);
            magicButtonsIce.SetActive(false);


            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected object
            EventSystem.current.SetSelectedGameObject(fireButton);

        }
    }

    public void ReturnButton4()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(MagicButtonActivationFire());


            magicButtonsFire.SetActive(true);
            magicButtons2.SetActive(false);
            


            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected object
            EventSystem.current.SetSelectedGameObject(fireButton);

        }
    }

    public void ReturnButton5()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(MagicButtonActivationIce());

            magicButtons4.SetActive(false);
            magicButtonsIce.SetActive(true);
            magicButtons3.SetActive(false);

            ColorBlock cb = king.colors;
            cb.normalColor = Color.white;
            bat2.colors = cb;
            king2.colors = cb;
            slime2.colors = cb;
            selected1 = 0;
            selected2 = 0;
            selected3 = 0;



            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected object
            EventSystem.current.SetSelectedGameObject(fireButton);

        }
    }

    public void ReturnButton6()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(UseItemActivation());


            useItemButtons.SetActive(true);
            healButtons.SetActive(false);
            nadeButtons.SetActive(false);



            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected object
            EventSystem.current.SetSelectedGameObject(goback6);

        }
    }

    IEnumerator ButtonStart()
    {
        yield return new WaitForSeconds(0.1f);

        dialogueText.text = "Choose an action";
        combatButtons.SetActive(true);
        dialogue.SetActive(true);
        combatButtons2.SetActive(false);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(attackButton);


    }

    IEnumerator ButtonActivation()
    {
        yield return new WaitForSeconds(0.1f);

        ;
        combatButtons.SetActive(false);
        dialogue.SetActive(false);
        combatButtons2.SetActive(true);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(singleTargetButton);


    }
    IEnumerator ButtonActivation2()
    {
        yield return new WaitForSeconds(0.1f);



        combatButtons2.SetActive(false);
        combatButtons3.SetActive(true);
        magicButtonsFire.SetActive(false);
        magicButtonsIce.SetActive(false);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(goback1);
        
        

    }

    IEnumerator ButtonActivation3()
    {
        yield return new WaitForSeconds(0.1f);



        combatButtons2.SetActive(false);
        combatButtonsDouble.SetActive(true);
        magicButtonsFire.SetActive(false);
        magicButtonsIce.SetActive(false);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(goback2);



    }

    IEnumerator MagicButtonActivation()
    {
        yield return new WaitForSeconds(0.1f);


        combatButtons.SetActive(false);
        dialogue.SetActive(false);
        magicButtons.SetActive(true);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(fireButton);

    }

    IEnumerator MagicButtonActivationIce()
    {
        yield return new WaitForSeconds(0.1f);


        magicButtons.SetActive(false);
        magicButtonsIce.SetActive(true);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(singleTargetIce);

    }

    IEnumerator MagicButtonActivationFire()
    {
        yield return new WaitForSeconds(0.1f);


        magicButtons.SetActive(false);
        magicButtonsFire.SetActive(true);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(singleTargetFire);

    }

    IEnumerator MagicButtonActivation2()
    {
        yield return new WaitForSeconds(0.1f);


        magicButtons2.SetActive(true);
        magicButtonsFire.SetActive(false);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(goback3);

    }

    IEnumerator MagicButtonActivation3()
    {
        yield return new WaitForSeconds(0.1f);


        magicButtons3.SetActive(true);
        magicButtonsIce.SetActive(false);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(goback4);

    }

    IEnumerator MagicButtonActivation4()
    {
        yield return new WaitForSeconds(0.1f);


        magicButtons4.SetActive(true);
        magicButtonsIce.SetActive(false);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(goback5);

    }


    IEnumerator UseItemActivation()
    {
        yield return new WaitForSeconds(0.1f);

        combatButtons.SetActive(false);
        dialogue.SetActive(false);
        useItemButton.SetActive(true);

       

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(goback6);
    }

    IEnumerator HealActivation()
    {
        yield return new WaitForSeconds(0.1f);

        useItemButtons.SetActive(false);
        healButtons.SetActive(true);
        dialogue.SetActive(false);



        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(goback7);
    }

    IEnumerator GrenadeActivation()
    {
        yield return new WaitForSeconds(0.1f);

        useItemButtons.SetActive(false);
        nadeButtons.SetActive(true);
        dialogue.SetActive(false);



        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(goback8);
    }







}
