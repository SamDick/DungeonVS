using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class BossScript{
	[XmlAttribute("name")]
	public string name;
	[XmlElement("HP")]
	public float HP;
	[XmlElement("Melee")]
	public float Melee;
	[XmlElement("Ranged")]
	public float Ranged;
	[XmlElement("Magic")]
	public float Magic;
	[XmlElement("Armor")]
	public float Armor;
	[XmlElement("Speed")]
	public float Speed;
	[XmlElement("Resist")]
	public float Resist;
	[XmlElement("Model")]
	public string Model;
	[XmlElement("meTimer")]
	public float meTimer;
	[XmlElement("raTimer")]
	public float raTimer;
	[XmlElement("maTimer")]
	public float maTimer;



	void Start () {
	}

	void Update()
	{
		
	}
}
