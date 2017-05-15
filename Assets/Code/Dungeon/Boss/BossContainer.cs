using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("BossCollection")]
public class BossContainer{


	[XmlArray("Bosses")]
	[XmlArrayItem("Boss")]
	public List<BossScript> bosses = new List<BossScript> ();

	public static BossContainer Load(string path)
	{
		TextAsset _xml = Resources.Load<TextAsset> (path);
		XmlSerializer serializer = new XmlSerializer (typeof(BossContainer));
		StringReader reader = new StringReader (_xml.text);

		BossContainer bosses = serializer.Deserialize (reader) as BossContainer;

		reader.Close();
		return bosses;

	}
}
