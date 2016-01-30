Shader "Diplomado/LevelShader" 
{
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
				
				float3 worldPos = mul(_Object2World, v.vertex).xyz;//_Object2World coordenadas globales
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);//MVP = MODEL VIEW PROJECTION
					
				if (worldPos.y < 0)
					o.color.xyz = fixed4(1,0,0,1);
				else if (worldPos.y > 0)
					o.color.xyz = fixed4(0,0,1,1);
				//else
				//	o.color.xyz = fixed4(0,1,0,1);
				
				o.color.w = 1.0;
											
				return o;
			}
			
			fixed4 frag(v2f i) : Color0
			{				
				return i.color;
			}	
					
			ENDCG
		}
	}
	
	Fallback "Diffuse"
}
