Shader "Diplomado/CustomLighting"
{
	Properties
	{
		_MainTex ("Base", 2D) = "white"{}
		_Color("Color base", Color) = (1,1,1)
	}
	
	SubShader
	{
		Tags {"RenderType"="Opaque"}
		
		CGPROGRAM
		#pragma surface surf1 BasicDiffuse
		
		sampler2D _MainTex;
		
		struct Input
		{
			float2 uv_MainTex;
		};
		
		inline float4 LightingBasicDiffuse(SurfaceOutput s, fixed3 lightDir, fixed atten)
		{
			float difLight = max(0, dot(s.Normal, lightDir));
			float hLambert = difLight * 0.5 + 0.5;
			float4 col;
			col.rgb = s.Albedo * _LightColor0.rgb * (hLambert * atten * 2);
			col.a = s.Alpha;
			
			return col;
		}
		
		void surf1 (Input IN, inout SurfaceOutput o)
		{
			half4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	
	FallBack "Diffuse"
}