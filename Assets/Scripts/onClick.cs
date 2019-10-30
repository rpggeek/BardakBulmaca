using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.UIElements;

public class onClick : MonoBehaviour {

	public void tikladigimda(){
		Application.LoadLevel ("bardakoyunu");
	}
	public void oyunubaslat(){
		Application.LoadLevel ("bardakoyunu");
	}
	public void anamenuyedon(){
		Application.LoadLevel ("MainMenu");
	}
	public void Startt(){
		Application.LoadLevel ("Start");
	}

	public void Settingss(){
		Application.LoadLevel ("Settings");
	}
}