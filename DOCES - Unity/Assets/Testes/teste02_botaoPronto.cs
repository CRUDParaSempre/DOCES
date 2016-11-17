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



//Falha no timeout
public class teste02_botaoPronto : MonoBehaviour
{
	GameObject obj, obj2, gsm;
	ClickAnimationControl component;		
	public static class WaitFor{
    	public static IEnumerator Frames(int frameCount){
   
        while (frameCount > 0){
            frameCount--;
            yield return null;
        }
    }
}

	public IEnumerator click_botao(){
		obj = GameObject.Find("CharSelectScene");
	    if(!obj){ 
			obj = GameObject.Find("NewGameButton");
			component = obj.GetComponent<ClickAnimationControl>();		
			Debug.Log("Int Teste 10: Estado 1");
	 	    component.OnMouseEnter();
			component.fakeClick(false);		
	 	    yield return WaitFor.Frames(2); 
	 	    Debug.Log("Int Teste 10: Estado 2");
			component.fakeClick(true);
			component.OnMouseExit();
	 	    yield return WaitFor.Frames(150);
		}

		obj = GameObject.Find("botaoPronto");
		component = obj.GetComponent<ClickAnimationControl>();		
		Debug.Log("Int Teste 10: Estado 3");
	 	component.OnMouseEnter();
		component.fakeClick(false);		
	 	yield return WaitFor.Frames(2); 
	 	Debug.Log("Int Teste 10: Estado 4");
		component.fakeClick(true);
		component.OnMouseExit();
	 	yield return WaitFor.Frames(150);
		
		obj = GameObject.Find("CompSelectScene");
		if(obj){ //Checa se tela mudou, pois nao deveria. Nome
			// nao preenchido
			Debug.Log("Int Teste Falhou, Bloqueio por falta de nome inativo");
			IntegrationTest.Fail(gameObject);
		}

		obj = GameObject.Find("Warning Message/Flowchart");

		Fungus.Flowchart flowchart = obj.GetComponent<Flowchart>();	
		flowchart.ExecuteBlock("OkButtonBlock");
		Debug.Log("Int Teste 10: Estado 5");
		yield return WaitFor.Frames(240);


		obj = GameObject.Find("CharNameCanvas/InputField");
		InputField text = obj.GetComponent<InputField>();
		text.text = "Sou um teste de Integracao";
		
		obj = GameObject.Find("botaoPronto");
		component = obj.GetComponent<ClickAnimationControl>();		
		Debug.Log("Int Teste 10: Estado 6");
	 	component.OnMouseEnter();
		component.fakeClick(false);		
	 	yield return WaitFor.Frames(2); 
	 	Debug.Log("Int Teste 10: Estado 7");
		component.fakeClick(true);
		component.OnMouseExit();
	 	yield return WaitFor.Frames(150);
		
		obj = GameObject.Find("CompSelectScene");
		if(!obj){ //Checa se tela mudou, pois deveria.
			Debug.Log("Int Teste Falhou, Botao Pronto Falhou");
			IntegrationTest.Fail(gameObject);
		}

		yield return WaitFor.Frames(20);

		IntegrationTest.Pass(gameObject);
		

	}


    public void Start()
    {
		StartCoroutine(click_botao());			
    }
}
