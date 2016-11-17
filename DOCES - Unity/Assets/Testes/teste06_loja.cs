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




public class teste06_loja : MonoBehaviour
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
		obj = GameObject.Find("ShopButton");
		ClickAnimationControl component = obj.GetComponent<ClickAnimationControl>();		
		
		Debug.Log("Int Teste 14: Estado 1");
		component.OnMouseEnter();
		component.fakeClick(false);		
		yield return WaitFor.Frames(2); 
		Debug.Log("Int Teste 14: Estado 2");
		component.fakeClick(true);
		component.OnMouseExit();
		yield return WaitFor.Frames(30);
		
		obj = GameObject.Find("Shop/Board/setinhaD");
		ArrowRightBoardScript component2 = obj.GetComponent<ArrowRightBoardScript>();		
		for(int i = 0; i < 5; i++){
			Debug.Log("Int Teste 14: Estado 3");
		 	component2.OnMouseDown();
		 	yield return WaitFor.Frames(30);
		}
		obj = GameObject.Find("Shop/Board");
		BoardScript component3 = obj.GetComponent<BoardScript>();	
		component3.selecionaItem(2);
		yield return WaitFor.Frames(30);

		obj = GameObject.Find("botaoOk");
		component = obj.GetComponent<ClickAnimationControl>();		
		
		Debug.Log("Int Teste 14: Estado 4");
		component.OnMouseEnter();
		component.fakeClick(false);		
		yield return WaitFor.Frames(2); 
		Debug.Log("Int Teste 14: Estado 5");
		component.fakeClick(true);
		component.OnMouseExit();
		yield return WaitFor.Frames(30);

		
		obj = GameObject.Find("Buttons/Flowchart");
		Fungus.Flowchart flowchart = obj.GetComponent<Flowchart>();	
		flowchart.ExecuteBlock("EmployeesButtonBlock");
		Debug.Log("Int Teste 10: Estado 6");
		yield return WaitFor.Frames(100);

		obj = GameObject.Find("Shop/Board");
		component3 = obj.GetComponent<BoardScript>();	
		component3.selecionaItem(3);
		yield return WaitFor.Frames(30);

		obj = GameObject.Find("botaoOk");
		component = obj.GetComponent<ClickAnimationControl>();		
		
		Debug.Log("Int Teste 14: Estado 6");
		component.OnMouseEnter();
		component.fakeClick(false);		
		yield return WaitFor.Frames(2); 
		Debug.Log("Int Teste 14: Estado 7");
		component.fakeClick(true);
		component.OnMouseExit();
		yield return WaitFor.Frames(130);

		obj = GameObject.Find("ShopButton");
		component = obj.GetComponent<ClickAnimationControl>();		
		
		Debug.Log("Int Teste 14: Estado 8");
		component.OnMouseEnter();
		component.fakeClick(false);		
		yield return WaitFor.Frames(2); 
		Debug.Log("Int Teste 14: Estado 9");
		component.fakeClick(true);
		component.OnMouseExit();
		yield return WaitFor.Frames(130);





		 IntegrationTest.Pass(gameObject);
			

		

	}


    public void Start()
    {
		StartCoroutine(testa_botoes());			
    }
}
