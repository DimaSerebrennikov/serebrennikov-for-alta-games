Shader "Custom/URP/UnlitGradientTransparent"
{
    Properties
    {
        _ColorA ("Color A", Color) = (1, 0, 0, 1)
        _ColorB ("Color B", Color) = (0, 0, 1, 1)
        _Axis   ("Axis (0 = Horizontal, 1 = Vertical)", Float) = 1
        _Offset ("Offset", Float) = 0
        _Width  ("Width", Float) = 1
    }

    SubShader
    {
        Tags
        {
            "RenderPipeline"="UniversalPipeline"
            "RenderType"="Transparent"
            "Queue"="Transparent"
        }

        Pass
        {
            Name "Unlit"
            Tags { "LightMode"="UniversalForward" }

            ZWrite Off
            Cull Back
            Blend SrcAlpha OneMinusSrcAlpha

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv         : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv          : TEXCOORD0;
            };

            CBUFFER_START(UnityPerMaterial)
                float4 _ColorA;
                float4 _ColorB;
                float _Axis;
                float _Offset;
                float _Width;
            CBUFFER_END

            Varyings vert(Attributes input)
            {
                Varyings output;
                output.positionHCS = TransformObjectToHClip(input.positionOS.xyz);
                output.uv = input.uv;
                return output;
            }

            float4 frag(Varyings input) : SV_Target
            {
                float gradientCoord;

                if (_Axis < 0.5)
                    gradientCoord = input.uv.x;
                else
                    gradientCoord = input.uv.y;

                float t = (gradientCoord - 0.5 + _Offset) / _Width + 0.5;
                t = saturate(t);

                float4 result = lerp(_ColorA, _ColorB, t);

                return result; // alpha now properly blended
            }
            ENDHLSL
        }
    }
}
