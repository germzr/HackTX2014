using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

abstract class SpeechToAction : MonoBehaviour {
	
	private Dictionary<string, Func<string[],bool>> _actions;

	public void Start(){
		this.Register ();
	}

	public abstract void RegisterActions();

	private void Register(){
		_actions = new Dictionary<string, Func<string[], bool>> ();
		this.RegisterActions();
	}

	public void ExecuteAction(string action, string[] args = null){
		if (!_actions.ContainsKey(action)) {
			return;
		}

		_actions[action](args);
	}
}
