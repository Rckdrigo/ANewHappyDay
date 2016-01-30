Shader "Diplomado/MaskingSpecular" 
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_MainTint("Color Tint", Color) = (1,1,1,1)
		_SpecularColor ("Specular Color", Color) = (1,1,1,1)
		_SpecPower("Specular Power", Range(0, 30)) = 1
	}
	
	SubShader
	{
		CGPROGRAM
		#pragma surface surf MyPhong
		
		sampler2D _MainTex;
		float _SpecPower;
		float4 _MainTint;
		float4 _SpecularColor;
		
		struct Input
		{
			float2 uv_MainTex;
		};
		
		struct SurfaceCustomOutput
		{
			fixed3 Albedo;
			fixed3 Normal;
			fixed3 Emission;
			fixed SpecularColor;
			half Specular;
			fixed Gloss;
			fixed Alpha;
		};
		
		inline float4 LightingMyPhong(SurfaceCustomOutput s, fixed3 lightDir, half3 viewDir, fixed atten)
		{
			float diff = dot(s.Normal, lightDir);
			float3 reflectionVector = normalize(2.0 * s.Normal * diff - lightDir);
			float spec = pow(max(0, dot(reflectionVector, viewDir)), _SpecPower);
			float3 finalSpec = _SpecularColor * spec * s.SpecularColor;
			fixed4 c;
			//c.rg = COMPONENTE_DIFUSA + COMPONENTE_ESPECULAT
			c.rgb = (s.Albedo * _LightColor0.rgb * 2.0 * diff * atten) + (_LightColor0.rgb * finalSpec);
			c.a = 1.0;
			
			return c;
		}
		
		void surf(Input IN, inout SurfaceCustomOutput o)
		{
			half4 c = tex2D(_MainTex, IN.uv_MainTex) * _MainTint;
			o.Specular = _SpecPower;
			o.SpecularColor = c.a;
			o.Gloss = 1.0;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
			fixed3 e = half3(0,0,1) * c.a;
			o.Emission = e;
		}
		ENDCG
	}
	
	FallBack "Diffuse"
}
