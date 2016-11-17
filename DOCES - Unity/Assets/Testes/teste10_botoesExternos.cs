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




public class teste10_botoesExternos : MonoBehaviour
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

	public IEnumerator checa_acesso_creditos(){
			obj = GameObject.Find("CreditsButton");
			ClickAnimationControl component = obj.GetComponent<ClickAnimationControl>();		
			Debug.Log("Int Teste 10: Estado 1");
	    	component.OnMouseEnter();
			component.fakeClick(false);		
	    	yield return WaitFor.Frames(2); 	    	
	    	Debug.Log("Int Teste 10: Estado 2");
			component.fakeClick(true);
			component.OnMouseExit();
			IntegrationTest.Pass(gameObject);
	}

	public IEnumerator checa_acesso_projeto(){
			obj = GameObject.Find("ProjectPageButton");
			ClickAnimationControl component = obj.GetComponent<ClickAnimationControl>();		
			Debug.Log("Int Teste 10: Estado 3");
	    	component.OnMouseEnter();
			component.fakeClick(false);		
	    	yield return WaitFor.Frames(2); 	    	
	    	Debug.Log("Int Teste 10: Estado 4");
			component.fakeClick(true);
			component.OnMouseExit();
			IntegrationTest.Pass(gameObject);
	}

	

    public void Start()
    {
    	
		StartCoroutine(checa_acesso_creditos());				
		StartCoroutine(checa_acesso_projeto());	
    }
}
