using UnityEngine;
using System.Collections;

public class DataLoader : MonoBehaviour {

	public string[] items;

	IEnumerator Start(){
		WWW itemsData = new WWW("http://localhost/unity_game/Items.php");
		yield return itemsData;  //yeild till value is loaded to itemsData
		string itemsDataString = itemsData.text;
		print (itemsDataString);
		items = itemsDataString.Split(';');
		print(GetDataValue(items[0], "Score:"));
		print(GetDataValue(items[1], "Score:"));
		print(GetDataValue(items[2], "Score:"));
	}

	string GetDataValue(string data, string index){
		string value = data.Substring(data.IndexOf(index)+index.Length);
		if(value.Contains("|"))value = value.Remove(value.IndexOf("|"));
		return value;
	}


}


























//void Start(){
//	string data = "ID:1|Name:Health Potion|Type:consumables|Cost:50";
//	print(GetDataValue(data, "Cost:"));
//}
//
//void Update(){
//	
//}
//
//string GetDataValue(string data ,string index){
//	string value = data.Substring(data.IndexOf(index)+index.Length);
//	if(value.Contains("|"))value = value.Remove(value.IndexOf("|"));
//	return value;
//}
