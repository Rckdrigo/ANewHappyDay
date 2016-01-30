Shader "Diplomado/VertexAnimation" 
{
	Properties
	{
		_MainTex("Base", 2D) = "white" {}
		_FlowSpeed("Flow Speed", Range(0.1, 10)) = 0.1
		_Speed("Wave Speed", Range(0.1, 80)) = 5
		_Frequency("Frequency", Range(0, 5)) = 2
		_Amplitude("Amplitude", Range(-1, 1)) = 1
	}
	
	SubShader
	{
		CGPROGRAM
		#pragma surface surf Lambert vertex:vert
		
		sampler2D _MainTex;
		float _FlowSpeed;
		float _Speed;
		float _Frequency;
		float _Amplitude;
		
		struct Input
		{
			float2 uv_MainTex;			
			float3 vertColor;
		};
		
		void vert(inout appdata_full v, out Input o)
		{
			UNITY_INITIALIZE_OUTPUT(Input,o);
			float time = _Time * _Speed;
			float seno = sin(_FlowSpeed * _Time);//rotar uv
            float coseno = cos(_FlowSpeed * _Time);//rotar uv
			float wave = sin(time + v.vertex.x * _Frequency) * _Amplitude;
			float2x2 matriz = float2x2(coseno, -seno, seno, coseno); //rotar uv           
            			
			v.vertex.xyz = float3(v.vertex.x, v.vertex.y + wave, v.vertex.z);
			v.normal = normalize(float3(v.normal.x + wave, v.normal.y, v.normal.z));
			v.texcoord.xy = mul(v.texcoord.xy, matriz);//rotar uv
			o.vertColor = float3(1, 1, 1);
		}
		
		void surf(Input IN, inout SurfaceOutput o)
		{
			half4 c = tex2D(_MainTex, IN.uv_MainTex);
			float3 tintColor = IN.vertColor;
			o.Albedo = c.rgb * tintColor;
			o.Alpha = c.a;
		}
		ENDCG
	}
	
	Fallback "Diffuse"
}
