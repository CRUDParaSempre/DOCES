using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

[IntegrationTest.DynamicTestAttribute("testScene")]
// [IntegrationTest.Ignore]
[IntegrationTest.ExpectExceptions(false, typeof(ArgumentException))]
[IntegrationTest.SucceedWithAssertions]
[IntegrationTest.TimeoutAttribute(10)]
[IntegrationTest.ExcludePlatformAttribute(RuntimePlatform.Android, RuntimePlatform.LinuxPlayer)]




public class teste07_quiz : MonoBehaviour
{
	GameObject obj, obj2, next;		
	public static class WaitFor{
    	public static IEnumerator Frames(int frameCount){
   
        while (frameCount > 0){
            frameCount--;
            yield return null;
        }
    }
}

	public IEnumerator testa_botoes(){

		obj = GameObject.Find("GameStateManager");
		GameStateManager _gsm = obj.GetComponent<GameStateManager>();
		

		yield return WaitFor.Frames(30);
		obj = GameObject.Find("GameScene");
		if(!obj){ 
			obj.SetActive(true);
			yield return WaitFor.Frames(10);	
		}
		obj = GameObject.Find("Main Camera");
		Vector3 ponto = new Vector3(69, 600, -10);
		SetCameraPosition _set = obj.GetComponent<SetCameraPosition>();
		_set.moveCameraTo(ponto, 0.5f);
		yield return WaitFor.Frames(30);
		

		_gsm.newClient();
		obj = GameObject.Find("DoorButton");
		ClickAnimationControl component = obj.GetComponent<ClickAnimationControl>();		
		
		Debug.Log("Int Teste 14: Estado 10");
		component.OnMouseEnter();
		component.fakeClick(false);		
		yield return WaitFor.Frames(2); 
		Debug.Log("Int Teste 14: Estado 11");
		component.fakeClick(true);
		component.OnMouseExit();
		yield return WaitFor.Frames(230);


		next = GameObject.Find("Project Dialogue/Next Button");
		
		
		obj = GameObject.Find("Project Request Canvas");
		ClientManager clm = obj.GetComponent<ClientManager>();	
		for(int i = 0; i < 10 ; i++){
			Debug.Log("Int Teste 14: Estado 12");
			if(!next.GetComponent<CircleCollider2D> ().enabled) break;
			clm.nextPage();
			yield return WaitFor.Frames(40);
		}
		yield return WaitFor.Frames(140);

		obj = GameObject.Find("Project Request Canvas/Flowchart");
		Fungus.Flowchart flowchart = obj.GetComponent<Flowchart>();	
		flowchart.ExecuteBlock("YesButtonBlock");

		yield return WaitFor.Frames(140);




		 IntegrationTest.Pass(gameObject);
			

		

	}


    public void Start()
    {
		StartCoroutine(testa_botoes());			
    }
}
