using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkflowManager : MonoBehaviour {

	private Dictionary<long,string> patientNames;
	private Dictionary<long,Dictionary<string,bool>> specimenDetails;
	public GameObject[] workFlowEntries;
	private int i=0;

	// Use this for initialization
	void Start () {
		patientNames = new Dictionary<long,string> ();
		specimenDetails = new Dictionary<long, Dictionary<string, bool>> ();
		patientNames [1001] = "Aaron";
		patientNames [1002] = "Brad";
		patientNames [1003] = "Charlie";
		specimenDetails [1001] = new Dictionary<string,bool> ();
		specimenDetails [1001] ["Blood Sample"] = false;
		specimenDetails [1002] = new Dictionary<string,bool> ();
		specimenDetails [1002] ["Blood Sample"] = false;
		specimenDetails [1003] = new Dictionary<string,bool> ();
		specimenDetails [1003] ["Blood Sample"] = false;

	}
	
	// Update is called once per frame
	void Update () {
		Display ();
	}

	void Display(){
		i = 0;
		foreach (long patientId in patientNames.Keys) {
			workFlowEntries[i].transform.Find ("IdText").GetComponent<Text> ().text = patientId.ToString();
			workFlowEntries[i].transform.Find ("NameText").GetComponent<Text> ().text = patientNames[patientId];
			Dictionary<string,bool> test = specimenDetails [patientId];
			foreach(string testName in test.Keys){
				workFlowEntries[i].transform.Find ("SampleText").GetComponent<Text> ().text = testName;
				if(test [testName])
					workFlowEntries[i].GetComponentInChildren<Toggle> ().isOn = true;
			}
			++i;
		}
	}

	void UpdateCompleted(long patientId){
		Dictionary<string,bool> test = specimenDetails [patientId];
		foreach (string testName in test.Keys) {
			test [testName] = true;
		}
	}

	void PrintDetails(long patientId){
		string name = patientNames [patientId];
		Dictionary<string,bool> test = specimenDetails [patientId];
		foreach (string testName in test.Keys) {
			test [testName] = true;
		}
	}
}
