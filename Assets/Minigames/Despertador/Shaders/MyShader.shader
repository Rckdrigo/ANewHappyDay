Shader "Diplomado/Diffuse"
{
	Properties
	{
	//NOMBRES DE VARIABLES
		_MainTex("Componentes RVA", 2D) =  "white"{}
		//_Color("Color base", Color) = (1,1,1)
	}
	
	Subshader //o SubShader
	{
		//CUERPO DEL SHADER
		Tags { "RenderType"="Opaque" }
		
		Pass
		{
			Material
			{
				Diffuse[_Color]				
			}
			Lighting On
			SetTexture[_MainTex]
			{
				combine previous * texture
			}
		}
	}
	
	FallBack "Diffuse"
}