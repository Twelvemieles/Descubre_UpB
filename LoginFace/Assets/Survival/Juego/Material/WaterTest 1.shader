Shader "Unlit/WaterTest 1" {
    Properties {
        _waters ("waters", 2D) = "white" {}
        _Velocity ("Velocity", Range(-3, 3)) = 2.589744
        _front ("front", 2D) = "white" {}
        _Velocity2 ("Velocity2", Range(-3, 3)) = 1.102564
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 100
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
         
            #include "UnityCG.cginc"
         
            uniform float4 _LightColor0;
            uniform sampler2D _front; uniform float4 _front_ST;
            uniform sampler2D _waters; uniform float4 _waters_ST;
            uniform float _Velocity;
            uniform float _Velocity2;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = 1;
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 node_6068 = _Time;
                float2 node_9165 = (i.uv0+(node_6068.g*_Velocity)*float2(1,0));
                float4 _waters_var = tex2D(_waters,TRANSFORM_TEX(node_9165, _waters));
                float2 node_4546 = (i.uv0+(node_6068.g*_Velocity2)*float2(1,0));
                float4 _front_var = tex2D(_front,TRANSFORM_TEX(node_4546, _front));
                float node_1670 = (_waters_var.r+_front_var.r);
                float3 diffuseColor = (i.vertexColor.rgb*saturate(node_1670));
                float3 diffuse = diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor,(i.vertexColor.a*node_1670));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }

       
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

