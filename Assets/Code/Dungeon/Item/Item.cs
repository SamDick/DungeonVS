using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Item 
{
	[XmlAttribute("name")]
	public string name;
	[XmlElement("type")]
	public float type;
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
	[XmlElement("Sprite")]
	public float Sprite;
}
