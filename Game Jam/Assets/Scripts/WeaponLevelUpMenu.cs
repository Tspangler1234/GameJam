using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class WeaponLevelUp : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject weaponHolder;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        weaponHolder = player.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpgradeWeapon()
    {
        if (player.GetComponent<PlayerStats>().Weapon != 5)
        {
            int rand = Random.Range(1, 8);
            player.GetComponent<PlayerStats>().Upgrade = rand;
            player.GetComponent<PlayerStats>().upgradeWeapon = true;
        }
        Time.timeScale = 1;
    }

    public void ChangeWeapon()
    {
        player.GetComponent<PlayerStats>().prevWeapon = player.GetComponent<PlayerStats>().Weapon;
        int rand = Random.Range(1, weaponHolder.transform.childCount + 1);
        player.GetComponent<PlayerStats>().Weapon = rand;
        player.GetComponent<PlayerStats>().Upgrade = 0;
        player.GetComponent<PlayerStats>().changeWeapon = true;
        player.GetComponent<PlayerStats>().upgradeWeapon = true;
        Time.timeScale = 1;
    }

    public void RevertWeapon()
    {
        if (player.GetComponent<PlayerStats>().prevWeapon != 0)
        {
            int temp = player.GetComponent<PlayerStats>().prevWeapon; //store previous weapon into temp
            player.GetComponent<PlayerStats>().prevWeapon = player.GetComponent<PlayerStats>().Weapon; //store current weapon as new prev weapon
            player.GetComponent<PlayerStats>().Weapon = temp; //new weapon is previous weapon
            player.GetComponent<PlayerStats>().changeWeapon = true;
            player.GetComponent<PlayerStats>().Upgrade = 0;
            player.GetComponent<PlayerStats>().upgradeWeapon = true;
        }
        Time.timeScale = 1;
    }

}
