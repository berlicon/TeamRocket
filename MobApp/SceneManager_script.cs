using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager_script : MonoBehaviour
{

	public GameObject showCrosshair_Toggle;
	public GameObject clearPhotos_Button;
	public GameObject TakePhoto_Panel;
	public GameObject askSiri_Panel;

	public GameObject Admin_Button;
	public GameObject Back_Button;


	void Start()
    {
		showCrosshair_Toggle = GameObject.Find("showCrosshair_Toggle");
		clearPhotos_Button = GameObject.Find("clearPhotos_Button");
		TakePhoto_Panel = GameObject.Find("TakePhoto_Panel");
		askSiri_Panel = GameObject.Find("askSiri_Panel");
		Admin_Button = GameObject.Find("Admin_Button");
		Back_Button = GameObject.Find("Back_Button");

		showUserUI();
	}


	public void showUserUI()
	{
		showCrosshair_Toggle.SetActive(false);
		clearPhotos_Button.SetActive(false);
		TakePhoto_Panel.SetActive(false);
		askSiri_Panel.SetActive(true);

		Admin_Button.SetActive(true);
		Back_Button.SetActive(false);
	}

	public void showAdminUI()
	{
		showCrosshair_Toggle.SetActive(true);
		clearPhotos_Button.SetActive(true);
		TakePhoto_Panel.SetActive(true);
		askSiri_Panel.SetActive(false);

		Admin_Button.SetActive(false);
		Back_Button.SetActive(true);
	}
}
