Shader "Diplomado/CustomShader" 
{
	Properties
	{
		//TEXTURAS
		_MainTex("Base (RGBA)", 2D) = "white" {}
		_SpecTex("Specular (RGBA)", 2D) = "white" {}
		_NormalTex("Normal Map", 2D) = "bump" {}
		
		_MainTint("Color Tint", Color) = (1,1,1,1)
		_EmissionColor("Emission Color", Color) = (1,1,1,1)
		_SpecularColor ("Specular Color", Color) = (1,1,1,1)
		_SpecPower("Specular Power", Range(0, 30)) = 1
	}
	
	SubShader
	{
		CGPROGRAM
		#pragma surface surf MyPhong
		
		sampler2D _MainTex;
		sampler2D _NormalTex;
		sampler2D _SpecTex;
		float _SpecPower;
		float4 _MainTint;
		float4 _SpecularColor;
		float4 _EmissionColor;
		
		struct Input
		{
			float2 uv_MainTex;
			float2 uv_NormalTex;
			float2 uv_SpecTex;
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
			float3 finalSpec = _EmissionColor * spec * s.SpecularColor;
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
			//fixed3 s = _SpecularColor
			fixed3 e = _SpecularColor * tex2D(_SpecTex, IN.uv_SpecTex).a;
			o.Emission = e;			
			float3 n = UnpackNormal(tex2D(_NormalTex, IN.uv_NormalTex));
			o.Normal = n.rgb;
		}
		ENDCG
	}
	
	FallBack "Diffuse"
}
