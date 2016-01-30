Shader "Diplomado/DepthOrder" 
{
	Properties 
	{	
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	
	SubShader 
	{
		//Background - 1000
		//Geometry - 2000
		//AlphaTest - 2450
		//Transparent - 3000
		//Overlay - 4000
		Tags { "Queue"="Geometry+20" }
		ZWrite OFF
				
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;

		struct Input 
		{
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) 
		{
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	
	FallBack "Diffuse"
}
