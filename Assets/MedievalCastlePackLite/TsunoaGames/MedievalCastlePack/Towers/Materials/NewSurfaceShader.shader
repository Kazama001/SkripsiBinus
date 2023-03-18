Shader "Custom/SkyboxWithClouds" {
    Properties {
        _MainTex ("Skybox Cubemap", Cube) = "gray" {}
        _CloudColor ("Cloud Color", Color) = (1,1,1,1)
        _CloudCover ("Cloud Cover", Range(0,1)) = 0.5
        _CloudSpeed ("Cloud Speed", Range(0,5)) = 1
        _CloudDensity ("Cloud Density", Range(0,2)) = 0.5
        _CloudSharpness ("Cloud Sharpness", Range(0,1)) = 0.5
    }

    SubShader {
        Tags {"Queue"="Background" "RenderType"="Background"}
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            samplerCUBE _MainTex;
            float4 _CloudColor;
            float _CloudCover;
            float _CloudSpeed;
            float _CloudDensity;
            float _CloudSharpness;

            struct appdata {
                float4 vertex : POSITION;
            };

            struct v2f {
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD0;
                float3 worldNormal : TEXCOORD1;
            };

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.worldNormal = UnityObjectToWorldNormal(v.vertex).xyz;
                return o;
            }

            float3 GetNoise(float3 p) {
                float3 n = float3(
                    dot(p, float3(127.1, 311.7, 74.7)),
                    dot(p, float3(269.5, 183.3, 246.1)),
                    dot(p, float3(113.5, 271.9, 124.6))
                );
                return frac(sin(n) * 43758.5453);
            }

            float3 GetCloudColor(float3 p, float3 noise) {
                float3 cloudColor = lerp(_CloudColor.rgb, float3(1,1,1), _CloudCover * noise.z);
                return cloudColor;
            }

            float4 frag (v2f i) : SV_Target {
                float4 bg = texCUBE(_MainTex, float4(i.worldPos,1));
                float cloudNoise = dot(GetNoise(i.worldPos * _CloudDensity), float3(1,2,4));
                float3 cloudColor = GetCloudColor(i.worldPos, GetNoise(i.worldPos * _CloudSpeed + cloudNoise));
                float3 mixColor = lerp(bg.rgb, cloudColor, pow(cloudNoise, _CloudSharpness) * _CloudCover);
                return float4(mixColor, bg.a);
            }
            ENDCG
        }
    }
    FallBack "Skybox/Cubemap"
}
