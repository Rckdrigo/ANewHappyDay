Shader "Diplomado/TextureAnimationShader" 
{
	Properties
	{
		_MainTex("Base", 2D) = "white" {}
		_Speed("Flow Speed", Range(0.1, 80)) = 5
		_TransVal("Transparency", Range(0, 1)) = 0.5
	}
	
	SubShader
	{
		CGPROGRAM
		#pragma surface surf Lambert vertex:vert
		
		sampler2D _MainTex;
		float _Speed;
		float _TransVal;
		
		struct Input
		{
			float2 uv_MainTex;			
			//float3 vertColor;
		};
		
		void vert(inout appdata_full v, out Input o)
		{
			UNITY_INITIALIZE_OUTPUT(Input,o);
			float seno = sin(_Speed * _Time);//rotar uv
            float coseno = cos(_Speed * _Time);//rotar uv
			float2x2 matriz = float2x2(seno, -coseno, coseno, seno); //rotar uv           
            			
			v.texcoord.xy = mul(v.texcoord.xy, matriz);
		}
		
		void surf(Input IN, inout SurfaceOutput o)
		{
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.r * _TransVal;
		}
		ENDCG
	}
	
	Fallback "Diffuse"
}
