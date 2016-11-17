using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[IntegrationTest.DynamicTestAttribute("testScene")]
// [IntegrationTest.Ignore]
[IntegrationTest.ExpectExceptions(false, typeof(ArgumentException))]
[IntegrationTest.SucceedWithAssertions]
[IntegrationTest.TimeoutAttribute(1)]
[IntegrationTest.ExcludePlatformAttribute(RuntimePlatform.Android, RuntimePlatform.LinuxPlayer)]




public class teste_dropDownMenu : MonoBehaviour
{
	GameObject obj;		
	public static class WaitFor{
    	public static IEnumerator Frames(int frameCount){
   
        while (frameCount > 0){
            frameCount--;
            yield return null;
        }
    }
}

	public IEnumerator ativar_menu(){
			obj = GameObject.Find("DropdownMenu");
			ClickAnimationControl component = obj.GetComponent<ClickAnimationControl>();		
			Debug.Log("Int Teste 1: Estado 1");
	    	component.OnMouseEnter();
			component.fakeClick(false);		
	    	yield return WaitFor.Frames(2); 
	    	//yield return new WaitForSeconds( 1.0f );
	    	Debug.Log("Int Teste 1: Estado 2");
			component.fakeClick(true);
			component.OnMouseExit();
	}


	public IEnumerator desativar_som(){
			obj = GameObject.Find("VolumeControlButton");
			VolumeButtonAnim component = obj.GetComponent<VolumeButtonAnim>();
			Debug.Log("Int Teste 1: Estado 3");    	

	    	yield return WaitFor.Frames(100);     	

	    	component.OnMouseEnter();
			component.fakeClick(false);		

			
			yield return WaitFor.Frames(2); 

	    	Debug.Log("Int Teste 1: Estado 4");
			component.fakeClick(true);
			component.OnMouseExit();
			

			yield return WaitFor.Frames(20); 

			component.OnMouseEnter();
			component.fakeClick(false);		
			
			yield return WaitFor.Frames(2); 


	    	Debug.Log("Int Teste 1: Estado 5");
			component.fakeClick(true);
			component.OnMouseExit();

			if(AudioListener.pause){				
				IntegrationTest.Pass(gameObject);
			}else{
				IntegrationTest.Fail(gameObject);
				Debug.Log("Falha: Sistema de som inativo");
			}

			yield return WaitFor.Frames(100); 

			IntegrationTest.Pass(gameObject);
		
	}
		

    public void Start()
    {
    	
		StartCoroutine(ativar_menu());		
		StartCoroutine(desativar_som());		
    }
}
