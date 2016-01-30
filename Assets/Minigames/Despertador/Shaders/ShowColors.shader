Shader "Diplomado/ShowColors" 
{
	Properties
	{
		_StartColor("Start Color", Color) = (0,0,0,1)
		_EndColor("End Color", Color) = (0,0,0,1)
	}
	
	
	SubShader 
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};
			
			struct v2f //vertex to fragment
			{
				float4 pos : SV_POSITION;
				fixed4 color : COLOR;
			};
			
			v2f vert(appdata v)
			{
				v2f o;
				
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);//MVP = MODEL VIEW PROJECTION
				o.color.xyz = (v.normal * 0.5) + float3(0.5, 0.5, 0.5);
				o.color.w = 1.0;
				
				return o;
			}
			
			fixed4 frag(v2f i) : Color0
			{				
				return i.color;
				//return fixed4(1,0,0,1);
			}	
					
			ENDCG
		}
	}
	
	Fallback "Diffuse"
}
