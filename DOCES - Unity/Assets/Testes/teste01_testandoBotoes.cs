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
[IntegrationTest.TimeoutAttribute(1)]
[IntegrationTest.ExcludePlatformAttribute(RuntimePlatform.Android, RuntimePlatform.LinuxPlayer)]




public class teste01_testandoBotoes : MonoBehaviour
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

	public IEnumerator botoes_faixaEsquerda(){
		obj = GameObject.Find("CharSelectScene");
	    if(!obj){ 
			obj = GameObject.Find("NewGameButton");
			ClickAnimationControl component = obj.GetComponent<ClickAnimationControl>();		
			Debug.Log("Int Teste 5: Estado 1");
	 	    component.OnMouseEnter();
			component.fakeClick(false);		
	 	    yield return WaitFor.Frames(2); 
	 //  //   	//yield return new WaitForSeconds( 1.0f );
	 	    Debug.Log("Int Teste 5: Estado 2");
			component.fakeClick(true);
			component.OnMouseExit();
	 	    yield return WaitFor.Frames(150);
		}

		obj = GameObject.Find("Flowchart_panel1");
		
		Fungus.Flowchart flowchart = obj.GetComponent<Flowchart>();	
		flowchart.ExecuteBlock("WomanButtonBlock");
		Debug.Log("Int Teste 5: Estado 3");

		gsm = GameObject.Find("GameStateManager");
		GameStateManager _gsm = gsm.GetComponent<GameStateManager>();

		yield return WaitFor.Frames(2); 

		if(_gsm.getGender() != 1){ // 1 == mulher
			Debug.Log("Int Teste falhou ao setar Genero para Feminino");
			IntegrationTest.Fail(gameObject);
		}

		yield return WaitFor.Frames(60); 

		flowchart.ExecuteBlock("ManButtonBlock");

		if(_gsm.getGender() != 0){ // 0 == homem
			Debug.Log("Int Teste falhou ao setar Genero para Masculino");
			IntegrationTest.Fail(gameObject);
		}

		yield return WaitFor.Frames(60); 

		


		obj = GameObject.Find("frascoL/botãoMais");
		ClickAnimationControl ac = obj.GetComponent<ClickAnimationControl>();
		for(int i = 0; i < 10; i++){
			ac.OnMouseEnter();
			ac.fakeClick(false);		
	    	yield return WaitFor.Frames(15); 
	    	Debug.Log("Int Teste 5: Estado 4");
			ac.fakeClick(true);
			ac.OnMouseExit();
			yield return WaitFor.Frames(5); 
		}
		obj = GameObject.Find("frascoL/botãoMenos");
		ac = obj.GetComponent<ClickAnimationControl>();
		for(int i = 0; i < 5; i++){
			ac.OnMouseEnter();
			ac.fakeClick(false);		
	    	yield return WaitFor.Frames(15); 
	    	Debug.Log("Int Teste 5: Estado 5");
			ac.fakeClick(true);
			ac.OnMouseExit();
			yield return WaitFor.Frames(5); 
		}
		obj = GameObject.Find("frascoO/botãoMais");
		ac = obj.GetComponent<ClickAnimationControl>();
		for(int i = 0; i < 10; i++){
			ac.OnMouseEnter();
			ac.fakeClick(false);		
	    	yield return WaitFor.Frames(15); 
	    	Debug.Log("Int Teste 5: Estado 6");
			ac.fakeClick(true);
			ac.OnMouseExit();
			yield return WaitFor.Frames(5); 
		}
		obj = GameObject.Find("frascoO/botãoMenos");
		ac = obj.GetComponent<ClickAnimationControl>();
		for(int i = 0; i < 4; i++){
			ac.OnMouseEnter();
			ac.fakeClick(false);		
	    	yield return WaitFor.Frames(15); 
	    	Debug.Log("Int Teste 5: Estado 7");
			ac.fakeClick(true);
			ac.OnMouseExit();
			yield return WaitFor.Frames(5); 
		}
		obj = GameObject.Find("frascoC/botãoMais");
		ac = obj.GetComponent<ClickAnimationControl>();
		for(int i = 0; i < 6; i++){
			ac.OnMouseEnter();
			ac.fakeClick(false);		
	    	yield return WaitFor.Frames(15); 
	    	Debug.Log("Int Teste 5: Estado 8");
			ac.fakeClick(true);
			ac.OnMouseExit();
			yield return WaitFor.Frames(5); 
		}

		
		yield return WaitFor.Frames(150); 

		IntegrationTest.Pass(gameObject);		
	}

	public IEnumerator botoes_faixaDireita(){
	 	yield return WaitFor.Frames(150);
	 	obj2 = GameObject.Find("Board2/Flowchart");
		
		Fungus.Flowchart flowchart = obj2.GetComponent<Flowchart>();	
		flowchart.ExecuteBlock("SkinButtonBlock");
		Debug.Log("Int Teste 9: Estado 1");
		yield return WaitFor.Frames(40);

		flowchart.ExecuteBlock("HairButtonBlock");
		Debug.Log("Int Teste 9: Estado 2");
		yield return WaitFor.Frames(40);

		flowchart.ExecuteBlock("EyesButtonBlock");
		Debug.Log("Int Teste 9: Estado 3");
		yield return WaitFor.Frames(40);

		flowchart.ExecuteBlock("ShirtButtonBlock");
		Debug.Log("Int Teste 9: Estado 4");
		yield return WaitFor.Frames(40);

		flowchart.ExecuteBlock("PantsButtonBlock");
		Debug.Log("Int Teste 9: Estado 5");
		yield return WaitFor.Frames(40);

		flowchart.ExecuteBlock("ShoesButtonBlock");
		Debug.Log("Int Teste 9: Estado 6");
		yield return WaitFor.Frames(40);


		obj2 = GameObject.Find("ColorHuePicker");
		Draggable drag = obj2.GetComponent<Draggable>();
		ColorHuePicker chp = obj2.GetComponent<ColorHuePicker>();
		Vector3 point = new Vector3(0,0);
		for (int i = 0; i < 20; i++){
			point.x += 0.04f;
			drag.SetDragPoint(point);
			chp.OnDrag(point);
			yield return WaitFor.Frames(15);
		}
		for (int i = 0; i < 10; i++){
			point.x -= 0.02f;
			drag.SetDragPoint(point);
			chp.OnDrag(point);
			yield return WaitFor.Frames(15);
		}

		

	}


    public void Start()
    {
		StartCoroutine(botoes_faixaEsquerda());	
		StartCoroutine(botoes_faixaDireita());		
    }
}
