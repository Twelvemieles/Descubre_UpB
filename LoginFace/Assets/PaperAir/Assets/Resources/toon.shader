Shader "Custom/toon" {
	Properties{
		_Color("Main Color", Color) = (0.5,0.5,0.5,1)
		_DispColor("Displacement Color", Color) = (0.5,0.5,0.5,1)
		_MainTex("Base (RGB)", 2D) = "white" {}
	_Size("DispSize",Range(0,10)) = 1.0
	_DispText("displacement texture",2D) = "white"{}
	_Displacement("Max Displacement",Range(0,0.008)) = 0.1
	_Ramp("Toon Ramp (RGB)", 2D) = "gray" {}
	}

		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
#pragma surface surf ToonRamp vertex:vert addshadow

		
		float _Displacement,_Size;
		sampler2D _Ramp;
		

	// custom lighting function that uses a texture ramp based
	// on angle between light direction and normal
#pragma lighting ToonRamp exclude_path:prepass
	inline half4 LightingToonRamp(SurfaceOutput s, half3 lightDir, half atten)
	{
#ifndef USING_DIRECTIONAL_LIGHT
		lightDir = normalize(lightDir);
#endif

		half d = dot(s.Normal, lightDir)*0.5 + 0.5;
		half3 ramp = tex2D(_Ramp, float2(d,d)).rgb;

		half4 c;
		c.rgb = s.Albedo * _LightColor0.rgb * ramp * (atten * 2);
		c.a = 0;
		return c;
	}
	sampler2D _DispText;
	float4 _DispColor;
	sampler2D _MainTex;
	float4 _Color;

	struct Input {
		float2 uv_MainTex : TEXCOORD0;
		float4 dispTex;
	};

	void vert(inout appdata_full v, out Input o)
	{
		float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
		half4 d = tex2Dlod(_DispText,float4(worldPos.x,worldPos.y * _Size + _Time.y,0,0));
		UNITY_INITIALIZE_OUTPUT(Input, o);
		v.vertex.xyz += _Displacement * v.normal * d;
		
		o.dispTex = d;
		
	}

	void surf(Input IN, inout SurfaceOutput o) {
		half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		
		o.Albedo = c.rgb + (IN.dispTex * _DispColor);
		o.Alpha = c.a;
	}
	ENDCG

	}

		Fallback "Diffuse"
}