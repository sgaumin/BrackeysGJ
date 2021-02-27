Shader "Custom/Rat"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // include file that contains UnityObjectToWorldNormal helper function
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                half3 worldNormal : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;

                // Head Movements
                if(v.vertex.y < -0.002)
                {
                  v.vertex.x += sin(_Time * 500 + v.vertex.y * 50) * 0.002;
                  v.vertex.z += sin(_Time * 200 + v.vertex.y * 50) * 0.002;
                }

                // Tail Movements
                if(v.vertex.y > 0.03)
                  v.vertex.x += sin(_Time * 300 + v.vertex.y * 50) * 0.01;

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                half litp = 1-saturate(dot(normalize(_WorldSpaceLightPos0), i.worldNormal));

                fixed4 col = 0;
                if(litp < 0.7)
                  col = tex2D(_MainTex, i.uv);
                
                return col;
            }
            ENDCG
        }
    }
}
