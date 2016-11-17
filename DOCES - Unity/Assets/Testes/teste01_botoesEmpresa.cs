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




public class teste01_botoesEmpresa : MonoBehaviour
{
	GameObject obj, obj2, gsm;		
	public static class WaitFor{
    	public static IEnumerator Frames(int frameCount){
   
        while (frameCount > 0){
            frameCount--;
            yield return null;
        }
    }
}

	public IEnumerator testa_botoes(){
		obj = GameObject.Find("CompSelectScene");
	 //    if(!obj){ 
	 //    	obj = GameObject.Find("teste01_testandoBotoes");
	 //    	teste01_testandoBotoes code = obj.GetComponent<teste01_testandoBotoes>();
	 //    	code.Start();
		//  	yield return WaitFor.Frames(20);
	 //    	obj = GameObject.Find("teste02_botaoPronto");
	 //    	teste02_botaoPronto code2 = obj.GetComponent<teste02_botaoPronto>();
	 //    	code2.Start();
			
		// }
		yield return WaitFor.Frames(30);
		obj = GameObject.Find("setinhaLogo_D");
		ClickAnimationControl component = obj.GetComponent<ClickAnimationControl>();		
		for(int i = 0; i < 5; i++){
			Debug.Log("Int Teste 11: Estado 1");
		 	component.OnMouseEnter();
			component.fakeClick(false);		
		 	yield return WaitFor.Frames(2); 
		 	Debug.Log("Int Teste 11: Estado 2");
			component.fakeClick(true);
			component.OnMouseExit();
		 	yield return WaitFor.Frames(30);
		}

		obj = GameObject.Find("setinhaLogo_E");
		component = obj.GetComponent<ClickAnimationControl>();		
		for(int i = 0; i < 3; i++){
			Debug.Log("Int Teste 11: Estado 3");
		 	component.OnMouseEnter();
			component.fakeClick(false);		
		 	yield return WaitFor.Frames(2); 
		 	Debug.Log("Int Teste 11: Estado 4");
			component.fakeClick(true);
			component.OnMouseExit();
		 	yield return WaitFor.Frames(30);
		}

		obj = GameObject.Find("botaoProntoEmpresa");

		component = obj.GetComponent<ClickAnimationControl>();		
		Debug.Log("Int Teste 11: Estado 7");
	 	component.OnMouseEnter();
		component.fakeClick(false);		
	 	yield return WaitFor.Frames(2); 
	 	Debug.Log("Int Teste 11: Estado 6");
		component.fakeClick(true);
		component.OnMouseExit();
	 	yield return WaitFor.Frames(150);

	 	obj = GameObject.Find("CompSelectScene");

		if(!obj){ //Checa se tela mudou, pois nao deveria. Nome
			// nao preenchido
			Debug.Log("Int Teste Falhou, Tela de jogo deveria estar inativa");
			IntegrationTest.Fail(gameObject);
		}


		obj = GameObject.Find("Warning Message/Flowchart");

		Fungus.Flowchart flowchart = obj.GetComponent<Flowchart>();	
		flowchart.ExecuteBlock("OkButtonBlock");
		Debug.Log("Int Teste 11: Estado 8");
		yield return WaitFor.Frames(140);


		obj = GameObject.Find("CompNameCanvas/InputField");
		InputField text = obj.GetComponent<InputField>();
		text.text = "Sou um teste de Integracao";
		
		obj = GameObject.Find("botaoProntoEmpresa");
		component = obj.GetComponent<ClickAnimationControl>();		
		Debug.Log("Int Teste 11: Estado 9");
	 	component.OnMouseEnter();
		component.fakeClick(false);		
	 	yield return WaitFor.Frames(2); 
	 	Debug.Log("Int Teste 11: Estado 10");
		component.fakeClick(true);
		component.OnMouseExit();
	 	yield return WaitFor.Frames(150);

	 	obj = GameObject.Find("GameScene");

		if(!obj){ //Checa se tela mudou, pois deveria.
			Debug.Log("Int Teste Falhou, Tela de jogo deveria estar ativa");
			IntegrationTest.Fail(gameObject);
		}

		yield return WaitFor.Frames(60);

		IntegrationTest.Pass(gameObject);
			

		

	}


    public void Start()
    {
		StartCoroutine(testa_botoes());			
    }
}
